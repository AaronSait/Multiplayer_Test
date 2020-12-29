using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScript : MonoBehaviour
{

    public int listeningPort = 25002;
    public int maxNumOfPlayers = 5;
    // Use this for initialization

    private const string gameType = "Arcae Racing", gameName = "Cars", comment = "Come have Fun";
    void Awake()
    {

        MasterServer.ipAddress = "127.0.0.1";
        MasterServer.port = 23466;
        Network.natFacilitatorIP = "127.0.0.1";
        Network.natFacilitatorPort = 50005;
        // StartServer();
        // StopServer();
    }

    //Useed for GUI Creation
    private void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            if (!Network.isClient && !Network.isServer)
            {
            
                if (GUI.Button(new Rect(100, 100, 250, 100), "START the  server"))
                    StartServer();
            }
            
        }
        else
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "STOP the  server"))
                StopServer();
        }
        /*
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            GUI.Label(new Rect(11, 11, 250, 20), "The Network Server is not running...");
            if (GUI.Button(new Rect(20, 100, 200, 20), "START the network server"))
            {
                StartServer();
            }
        }
        else if (Network.peerType == NetworkPeerType.Connected)
        {
            GUI.Label(new Rect(11, 11, 250, 20), "The Network Server is running...");
            ServerInformation();
            ClientInformation();
            if (GUI.Button(new Rect(20, 100, 200, 20), "STOP the network server"))
            {
                StopServer();
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartServer()
    {
        Network.InitializeServer(maxNumOfPlayers, listeningPort, true);
        MasterServer.RegisterHost(gameType, gameName, comment);
        Debug.Log("SERVER RUNNING");
    }
    private void OnServerInitialized()
    {
        Debug.Log("SERVER UP");
    }

    void StopServer()
    {
        Network.Disconnect();
        Debug.Log("SERVER NOT RUNNING");
    }


    void ServerInformation()
    {
        GUI.Label(new Rect(61, 31, 200, 20), "IP: " + Network.player.ipAddress + " \nPort: " + Network.player.port);
    }
    void ClientInformation()
    {
        GUI.Label(new Rect(11, 71, 200, 20), "Clients: " + Network.connections.Length + "/" + maxNumOfPlayers);
        if (Network.connections.Length > 0)
        {
            for (int i = 0; i < Network.connections.Length; i++)
            {
                GUI.Label(new Rect(11, 101 + ((i + 1) * 30), 250, 20), "Players From IP/Port: " + Network.connections[i].ipAddress + " : " + Network.connections[i].port);
                Debug.Log(i);
            }
        }
    }


}
