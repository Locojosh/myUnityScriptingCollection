using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] 
    private Text buttonText;
    [SerializeField]
    private int roomSize;
    private bool connected, starting;
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        connected = true;
        buttonText.text = "Comenzar Juego";
    }
    public void GameButton()
    {
        if(connected)
        {
            if(!starting)
            {
                starting = true;
                buttonText.text =  "Juego Comenzando.. Vuelve a Presionar para Cancelar";
                PhotonNetwork.JoinRandomRoom(); // Attempt joining a room
            }
            else
            {
                starting = false;
                buttonText.text = "Comenzar Juego";
                PhotonNetwork.LeaveRoom(); //Cancel the request
            }
        }
        else
            Debug.Log("Not connected to server!");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room... creating a room");
        CreateRoom();
    }
    private void CreateRoom()
    { 
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();
    }
}
