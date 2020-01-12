using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour
{
    const string Host = "192.168.0.107";
    const int Port = 41234;

    UdpClient udpClient = new UdpClient();
    protected virtual void Start()
    {
        udpClient.Connect(Host, Port);
    }

    void sendMessage(UdpMessage message){

        string jsonMessage = message.ToJson(); 

        Debug.Log(jsonMessage);

        Byte[] sendBytes = Encoding.ASCII.GetBytes(jsonMessage);

        udpClient.Send(sendBytes, sendBytes.Length);
    }

    protected virtual void OnDestroy() {
        udpClient.Close();
    }
}
