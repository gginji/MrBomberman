using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class VertHandler : MonoBehaviour 
{
    Mesh mesh;
    Vector3[] verts;
    GameObject[] handles;
	Hashtable verticesByPosition = new Hashtable();
 
    void OnEnable()
    {
		mesh = GetComponent<MeshFilter>().mesh;
		
		handles = new GameObject[mesh.vertices.Length];
		
		verts = mesh.vertices;
		for(int i=0; i<mesh.vertices.Length; i++)
		{
			Vector3 vert = mesh.vertices[i];
			Vector3 vertPos = transform.TransformPoint(vert);
			GameObject handle = new GameObject("handle");
			handle.transform.position = vertPos;
			handle.transform.parent = transform;
			handle.tag = "handle";
			//handle.AddComponent<Gizmo_Sphere>();
		 	
			if(verticesByPosition[vert.ToString()] != null)
			{
				//handle.transform.parent = handles[(int)verticesByPosition[vert.ToString()]].transform;
				handle.name = "handle_"+vert.ToString();
			}
			else
			{
				verticesByPosition.Add(vert.ToString(), i);
				handle.name = "handle_"+vert.ToString();
			}
			
			handles[i] = handle;
			
			print (vert.ToString());
		}
    }
 
    void OnDisable()
    {
       GameObject[] handles = GameObject.FindGameObjectsWithTag("handle");
       foreach(GameObject handle in handles)
       {
         DestroyImmediate(handle);    
       }
    }
 
    void Update()
    {
       for(int i = 0; i < verts.Length; i++)
       {
         verts[i] = handles[i].transform.localPosition;   
       }
       mesh.vertices = verts;
       mesh.RecalculateBounds();
       mesh.RecalculateNormals();
    }
}
