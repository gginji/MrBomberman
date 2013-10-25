using UnityEngine;
using System.Collections;

public class levier1 : MonoBehaviour {

	// variable pour triggers levier
	GameObject Mur;
	GameObject Player;
	GameObject Levier;
	GameObject camera;
	bool active;
	

	
	// variable pour trigger de position
	GameObject Zone;
	GameObject Dalle;
	bool DalleDown;
	
	
	
	//Variable pour trigger avec clé
	GameObject Mur2;
	GameObject Cle;
	bool PossessionCle;
	
	
	// Use this for initialization
	void Start () {
		
		Mur=GameObject.FindGameObjectWithTag("Mur");
		Player=GameObject.FindGameObjectWithTag("Player");
		active=false;
		
		
		camera=GameObject.FindGameObjectWithTag("MainCamera");
		
		
		Zone=GameObject.FindGameObjectWithTag("Zone");
		Dalle=GameObject.FindGameObjectWithTag("Dalle");
		DalleDown=false;
		
		
		
		Mur2=GameObject.FindGameObjectWithTag("Mur2");
		Cle=GameObject.FindGameObjectWithTag("Cle");
		PossessionCle=false;
	}
	
	// Update is called once per frame
	void Update () {
		
	
		
	}
	
	
	void OnTriggerEnter( Collider info)
	{
		/****************************activation de levier pour ouvrir une porte*/

		if (info.gameObject.tag=="levier" && active==false)
		{
	
		Debug.Log("Click principal pour ouvrir la porte");
			
			if (active==false)
			{
				
			Debug.Log ("le levier est activable");	
			}else {
			Debug.Log ("le levier est deja activé");	
			}
			
		}
		/********************FIN ACTIVATION LEVIER****************************************/
		
		
		/********************************Trigger avec clé *********************************/
		
		if (info.gameObject.tag=="Cle")
		{
		PossessionCle=true;	
			Debug.Log ("Vous avez rammassez une petite clé");
		}
		
		/**********************FIN DU TRIGGER AVEC CLE**************************************/

		
	}
	
	void OnTriggerStay (Collider info)
	{
		/****************************activation de levier pour ouvrir une porte*/

		if (info.gameObject.tag=="levier"){
	
		if (Input.GetKey(KeyCode.E)&& active==false)
			{
			Mur.transform.Translate(20,0,0);	
			info.transform.Rotate(0,0,-40);
			active=true;
			}
			
		}
		/********************FIN ACTIVATION LEVIER****************************************/
		
		
		
		/***********************Trigers de déplacement **************************************/
		
		if (info.gameObject.tag=="Zone" && DalleDown==false)
		{
		
		Dalle.transform.Translate(0,-14,0);
			
		DalleDown=true;
			
		Debug.Log("Vous etes mort");
			
		}
		
		/***************************FIN DU TRIGGERS DE DEPLACEMENT****************************/
		
		/********************************Trigger avec clé *********************************/
		if (info.gameObject.tag=="Mur2" && PossessionCle==true)
		{
			
		Mur2.transform.Translate(0,10,0);	
		PossessionCle=false;
			
		}else {
			if (info.gameObject.tag=="Mur2" && PossessionCle==false)
			{
			Debug.Log("Il vous faut une clé pour ouvrir la porte");	
			}
			
		}
		
		
		/**********************FIN DU TRIGGER AVEC CLE**************************************/
	}
	
}