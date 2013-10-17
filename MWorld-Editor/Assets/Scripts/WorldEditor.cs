using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BrushType
{
	selection, sculpt, paint, texturePaint
}

public class WorldEditor : MonoBehaviour {
	
	public BrushType brushType;
	public float brushSize = 1;
	public float brushIntensity = 1;
	
	//for sculpt brush only...
	public Vector3 brushDirection = new Vector3(0, 1, 0);
	public float maxHeight = 50;
	
	//for paint brush only...
	public Vector4 brushColor = new Vector4(0, 0, 0, -1);
	public float maxTransparency = 1;
	
	//for texture brush only...
	public Texture2D brushTexture;
	
	//Terrain assets...
	public GameObject defaultTextureTile;
	public GameObject defaultColorTile;
	
	public Material[] terrainTextures;
	public GameObject[] doodads;
	
	int DEFAULT_TILE_STEP=2;
	
	Hashtable world;
	
	// Use this for initialization
	void Start () {
		drawEmptyMap(new Vector2(10, 10));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			if(brushType==BrushType.selection)
			{
				//todo: show selection's properties
			}
			else
			{
				Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
		
				RaycastHit hitFloor2;
				if (Physics.Raycast (ray.origin, ray.direction, out hitFloor2, 100f)) 
				{
					List<string> testBrush = getTilesAroundPoint(hitFloor2.point, (int)Mathf.Ceil(brushSize*3));
					foreach(string s in testBrush)
					{
						
						if(brushType==BrushType.sculpt)
						{
							((GameObject)((Hashtable)world[s])["textureTile"]).GetComponent<VerticlesIndexer>().applySmoothTranslationToVerticles(hitFloor2.point, brushDirection, brushSize, brushIntensity, maxHeight);
							((GameObject)((Hashtable)world[s])["colorTile"]).GetComponent<VerticlesIndexer>().applySmoothTranslationToVerticles(hitFloor2.point, brushDirection, brushSize, brushIntensity, maxHeight);
						}
						
						if(Vector3.Distance(((GameObject)((Hashtable)world[s])["textureTile"]).transform.position, hitFloor2.point)<brushSize*DEFAULT_TILE_STEP)
						{
							if(brushType==BrushType.paint)
								((GameObject)((Hashtable)world[s])["colorTile"]).GetComponent<TileColorHandler>().paint(hitFloor2.point, brushColor, brushSize, brushIntensity, maxTransparency);
							
							if(brushType==BrushType.texturePaint)
								((GameObject)((Hashtable)world[s])["textureTile"]).GetComponent<TileColorHandler>().paintTexture(hitFloor2.point, brushTexture, brushSize, brushIntensity, maxTransparency);
						}
					}
				}
			}
		}
	}
	
	//render an empty map with default grass texture.
	public void drawEmptyMap(Vector2 mapSize)
	{
		world = new Hashtable();
		
		for(int i=0; i<mapSize.x; i++)
		{
			for(int j=0; j<mapSize.y; j++)
			{
				addTile(new Vector3(i*DEFAULT_TILE_STEP, 0, j*DEFAULT_TILE_STEP));
			}
		}
	}
	
	public void addTile(Vector3 position)
	{
		//the color tile always comes first.
		GameObject textureTile = (GameObject) Instantiate(defaultTextureTile, position, Quaternion.identity);
		GameObject colorTile = (GameObject) Instantiate(defaultColorTile, position+new Vector3(0, 0.01f, 0), Quaternion.identity);
				
		string id = getIdWithPosition(textureTile.transform.position, DEFAULT_TILE_STEP);
		
		Hashtable tileInfos = new Hashtable();
		tileInfos.Add("id", id);
		tileInfos.Add("x", textureTile.transform.position.x);
		tileInfos.Add("y", textureTile.transform.position.y);
		tileInfos.Add("z", textureTile.transform.position.z);
		
		//we keep a reference to the tile's gameobjects
		tileInfos.Add("textureTile", textureTile); 
		tileInfos.Add("colorTile", colorTile);
		
		world.Add(id, tileInfos);
	}
	
	public List<string> getTilesAroundPoint(Vector3 point, int radius)
	{
		List<string> tiles = new List<string>();
		//to avoid looping around every tile in the maps, we use the indexed ids
		for(int i=-radius; i<radius; i++)
		{
			for(int j=-radius; j<radius; j++)
			{
				Vector3 tmpTilePosition = point+new Vector3(i*DEFAULT_TILE_STEP, 0, j*DEFAULT_TILE_STEP);
				string tmpId = getIdWithPosition(tmpTilePosition, DEFAULT_TILE_STEP);
				
				if(world[tmpId]!=null)
				{
					//tile exists, add it to the list...
					tiles.Add(tmpId);
				}
			}	
		}
		
		return tiles;
	}
	
	public string getIdWithPosition(Vector3 position, float defaultStep)
	{
		return smash(position, defaultStep).ToString();
	}

    public Vector3 smash(Vector3 position, float factor)
    {
        return new Vector3((float)Mathf.Floor(position.x / factor) * factor, (float)Mathf.Floor(position.y / factor) * factor, (float)Mathf.Floor(position.z / factor) * factor);
    }

    public Vector3 smash(Vector3 position, Vector3 factorAsVector)
    {
        return new Vector3((float)Mathf.Floor(position.x / factorAsVector.x) * factorAsVector.x, (float)Mathf.Floor(position.y / factorAsVector.y) * factorAsVector.y, (float)Mathf.Floor(position.z / factorAsVector.z) * factorAsVector.z);
    }
}
