using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;

public class Client : MonoBehaviour {
    public string m_IPAdress = "192.168.0.6";
    public const int kPort = 1667;
    private static Client singleton;
    private Socket m_Socket;
    void Awake()
    {
        m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // System.Net.PHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
        // System.Net.IPAddress remoteIPAddress = ipHostInfo.AddressList[0];
        System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(m_IPAdress);

        System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, kPort);

        singleton = this;
        m_Socket.Connect(remoteEndPoint);
    }
    void OnApplicationQuit()
    {
        m_Socket.Close();
        m_Socket = null;
    }
    
    public void Send(string msgData)
    {
        if (singleton.m_Socket == null)
            return;

        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        byte[] sendData = encoding.GetBytes(msgData);
        byte[] prefix = new byte[1];
        prefix[0] = (byte)sendData.Length;
        m_Socket.Send(sendData);
    }
    // Use this for initialization
    void Start () {
        Send("hello");
    }
	
	// Update is called once per frame
	void Update () {

	}
    
}
