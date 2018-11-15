using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //Method 1: Use Unity's API? 
using System;
using System.IO;
//using System.Web;
//using System.Web.Script.Serialization;
using System.Net;
using System.Net.Sockets; //Method 2: Use C# standard networking library?  

public class Networking_Test : MonoBehaviour {
    public bool isAtStartup = true;
   // NetworkClient myClient;
    ClientSocket myClient;
    // Use this for initialization
    void Start () {
        myClient = new ClientSocket("127.0.0.1", 6789); //6789 is set, but IP address is different 
        
    }
	
	// Update is called once per frame
	void Update () {
        myClient.Send();   
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

class ClientSocket
{
    //private TcpClient Client;
    //private NetworkStream Stream;
    Socket Client;
    private Byte[] Data;

    public ClientSocket(string address, int port)
    {
        //Client = new TcpClient();
        //Client.Connect(address, port);

        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6789);

        Socket Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            Client.Connect(ip);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Unable to connect to server.");
            return;
        }

    }

    public void Send()
    {
        string toSend = "Hello!";

        // Sending
        int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
        byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
        byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
        //Client.Send(toSendLenBytes);
        Client.Send(toSendBytes);

        // Receiving
       /* byte[] rcvLenBytes = new byte[4];
        Client.Receive(rcvLenBytes);
        int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
        byte[] rcvBytes = new byte[rcvLen];
        Client.Receive(rcvBytes);
        String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

        Console.WriteLine("Client received: " + rcv);
        */
        Client.Close();
    }
};