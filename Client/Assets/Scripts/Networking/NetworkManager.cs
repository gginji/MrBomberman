using UnityEngine;
using System.Collections;

public enum ServerEventType
{
	ping=0, position=1, chat=2, pm=3, joinGame=4, joinChannel=5, custom=6
}

public class NetworkManager : MonoBehaviour 
{
	public UICore core;
	
	public void connect(string server, string port)
	{
		Network.Connect(server, int.Parse(port));
	}
	
	//this function is used to send data to the server
	public void send(byte eventType, System.Object parameters)
	{
		object[] data = new object[]
		{
			eventType, parameters
		};
		networkView.RPC("onClientEvent",RPCMode.Server, data);
	}
	
	//this function is used to handle data coming from the server
	[RPC]
	void OnServerEvent(byte eventType, System.Object parameters)
	{
		if(eventType==(byte)ServerEventType.ping)
		{
			
		}
	}
	
	void OnFailedToConnect(NetworkConnectionError error) 
	{
		core.startScreen.show();
	    Debug.Log("Could not connect to server: " + error);
	    core.errorInterface.showMessage("Connection failed: " + error, Color.red, true);
    }
	
	void OnConnectedToServer() 
	{
		core.startScreen.hide();
		core.lobby.Visible = true;
		
        Debug.Log("Connected to server");
		core.errorInterface.showMessage("Success!", Color.green, true);
    }
}
