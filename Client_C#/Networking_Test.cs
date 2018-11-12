using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //Method 1: Use Unity's API? 
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Sockets; //Method 2: Use C# standard networking library?  

public class Networking_Test : MonoBehaviour {
    public bool isAtStartup = true;
   // NetworkClient myClient;
    TCPClient myClient;
    // Use this for initialization
    void Start () {
        myClient = new TCPClient("127.0.0.1", 6789); //6789 is set, but IP address is different 
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    // Create a client and connect to the server port
    //public void SetupClient()
    //{
    //    myClient = new NetworkClient();
    //    myClient.RegisterHandler(MsgType.Connect, OnConnected);
    //    myClient.Connect("127.0.0.1", 6789); //using port 6789, IP address will change when server restarts 
    //    isAtStartup = false;
    //}

    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}

class TCPClient
{
private TcpClient Client;
private NetworkStream Stream;

private Byte[] Data;

public TCPClient(string address, int port)
{
    Client = new TcpClient();
    Client.Connect(address, port);

}

};