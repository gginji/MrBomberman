using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Network.InitializeSecurity();
		Network.InitializeServer(int.MaxValue, 9999);
	}
	
	//used to handle client requests
	[RPC]
	void onClientEvent(object[] parameters)
	{
		
	}
}
