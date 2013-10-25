using UnityEngine;
using System.Collections;

public class BombeScript : MonoBehaviour {
	
	[SerializeField]
	private Transform _pad1;
	
	float Temps_Avant_Explosion;
	
	GameObject Bombe;
	
	GameObject bobombe;
	
	public Transform pad1
	{
		get {return _pad1;}
		set { _pad1=value;}
	}
	
	// Use this for initialization
	void Start () {
		
		Temps_Avant_Explosion=Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			Bombe=GameObject.CreatePrimitive(PrimitiveType.Sphere);	
			Bombe.transform.position=_pad1.transform.position;
			
			//bobombe = (GameObject) Instantiate(Resources.Load("Bombe")); 
		}
		
	if (Time.deltaTime-5.0f == Temps_Avant_Explosion)
		{
			//Destroy(this.bobombe);
			Destroy(this.Bombe);
		}
	}
}
