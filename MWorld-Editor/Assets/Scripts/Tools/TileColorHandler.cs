using UnityEngine;
using System.Collections;

public class TileColorHandler : MonoBehaviour {
	
	float DEFAULT_TILE_SIZE = 2; //it is alway 2...
	
	public void paint(Vector3 point, Vector4 color, float brushSize, float intensity)
	{
	    Texture2D texture = new Texture2D(128, 128);
		
		texture.SetPixels(((Texture2D)renderer.material.mainTexture).GetPixels());
		
		renderer.material.mainTexture = texture;
		
        for(int x=0; x<texture.width; x++)
		{
			for(int y=0; y<texture.height; y++)
			{
				//Warning! x and y are inverted in the texture!!!
				float localZcoords = -(((float)x/(float)texture.width)*DEFAULT_TILE_SIZE-DEFAULT_TILE_SIZE/2); //we need to take in account the fact that the mesh is centered
				float localXcoords = -(((float)y/(float)texture.height)*DEFAULT_TILE_SIZE-DEFAULT_TILE_SIZE/2); //we need to take in account the fact that the mesh is centered
				
				Vector3 pixelWorldPosition = transform.TransformPoint(new Vector3(localXcoords, point.y, localZcoords));
				
				float distance = Vector3.Distance(pixelWorldPosition, point);
				float relativeIntensity = (1-distance/brushSize)*intensity;
				
				if(relativeIntensity>intensity)
				relativeIntensity = intensity;
			
				if(relativeIntensity>0) //if i am in brush range
				{
					Color lastColor = texture.GetPixel(x, y);
					Color newColor = new Color(lastColor.r+color.x*relativeIntensity, lastColor.g+color.y*relativeIntensity, lastColor.b+color.z*relativeIntensity, lastColor.a+color.w*relativeIntensity);
					texture.SetPixel(x, y, newColor);
				}
			}
		}
		
        texture.Apply();
	}
}
