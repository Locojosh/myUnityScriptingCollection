using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    private void Start() 
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects game to the Photon master server
        
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connection made to " + PhotonNetwork.CloudRegion + " server."); //What server region connected to
    }
}
