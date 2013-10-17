using UnityEngine;
using System.Collections;

//this is used for tests...
public class MeshManager : MonoBehaviour 
{
	
	public Vector3[] vertices;
	MeshFilter myFilter;
	// Use this for initialization
	void Start () 
	{
		myFilter = GetComponent<MeshFilter>();
		vertices = myFilter.mesh.vertices;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myFilter.mesh.vertices = vertices;
		myFilter.mesh.RecalculateBounds();
		myFilter.mesh.RecalculateNormals();
	}
}
