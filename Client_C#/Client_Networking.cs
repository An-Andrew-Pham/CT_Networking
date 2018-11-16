using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Sockets;

public class Client_Networking : MonoBehaviour {
    
    ClientSocket mySocket;
    public Button Login_Button;
    public GameObject Username;
    public GameObject Password;
    private String inputusername;
    private String inputpassword;

	// Use this for initialization
	void Start () {
        //Establish Connection
        mySocket = new ClientSocket();

    }
	
    void TaskOnClick()
    {
        inputusername = Username.GetComponent<InputField>().text;
        inputpassword = Password.GetComponent<InputField>().text;
        mySocket.Send(inputusername, inputpassword); //sends Data per click
        Debug.Log("You have clicked the button!");
      
    }

	// Update is called once per frame
	void Update () {
        Login_Button.onClick.AddListener(TaskOnClick);
        
    }
}

class ClientSocket
{
    Socket clientSocket;

    public ClientSocket()
    {

        IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("10.26.75.211"), 6789);

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(serverAddress);

    }

    public void Send(String username, String password)
    {
        String toSend = username + "," + password;

        // Sending
        int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
        byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
        byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
        clientSocket.Send(toSendLenBytes);
        clientSocket.Send(toSendBytes);

        // Receiving
        byte[] rcvLenBytes = new byte[4];
        clientSocket.Receive(rcvLenBytes);
        int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
        byte[] rcvBytes = new byte[rcvLen];
        clientSocket.Receive(rcvBytes);
        String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

        Debug.Log("Client received: " + rcv);

        //clientSocket.Close();
    }

}