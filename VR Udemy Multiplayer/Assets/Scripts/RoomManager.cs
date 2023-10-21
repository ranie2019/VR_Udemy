using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI CallBack Methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreatedAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A Sala Esta Criada Com o Nome: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("O Jogador: " + PhotonNetwork.NickName+ "Juntou-se a " + PhotonNetwork.CurrentRoom.Name + "Numero de Jogadores " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "Juntou-se a" + "Numero de Jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    #region
    private void CreatedAndJoinRoom()
    {
        string randomRoonName = "Sala_" + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        PhotonNetwork.CreateRoom(randomRoonName, roomOptions);
    }
    #endregion
}