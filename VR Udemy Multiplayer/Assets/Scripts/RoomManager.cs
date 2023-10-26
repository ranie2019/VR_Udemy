using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;

    public TextMeshProUGUI OccupancyRateText_forSchool;
    public TextMeshProUGUI OccupancyRateText_forOutdoor;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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

    public void OnEnterButtonClicked_Outdoor()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_School()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
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
        Debug.Log("O Jogador: " + PhotonNetwork.NickName+ "Juntou-se a " + PhotonNetwork.CurrentRoom.Name + " Numero de Jogadores " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType))
            {
                Debug.Log("Entrou na Sala Com o Mapa: " + (string)mapType);
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL)
                {
                    // carega a cena da escola
                    PhotonNetwork.LoadLevel("World_School");
                }
                else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR)
                {
                    // carega a cena do ar live
                    PhotonNetwork.LoadLevel("World_Outdoor");
                }

            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "Juntou-se a" + "Numero de Jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0)
        {
            // não há espaço algum
            OccupancyRateText_forSchool.text = 0 + " / " + 20;
            OccupancyRateText_forOutdoor.text = 0 + " / " + 20;
        }

        foreach (RoomInfo room in roomList)
        {
            Debug.Log(room.Name);
            if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR))
            {
                //atualizar uma sala ao ar livre ocupação campo

                Debug.Log("A Sala é um Mapa Ar Livre. A Contagem de Jogadores é: " + room.PlayerCount);
                OccupancyRateText_forOutdoor.text = room.PlayerCount + " / " + 20;

            }else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL))
            {
                Debug.Log("A Sala é um Mapa Escolar. A Contagem de Jogadores é: " + room.PlayerCount);
                OccupancyRateText_forSchool.text = room.PlayerCount + " / " + 20;
            }
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Juntou-se ao Lobby");
    }
    #endregion

    #region
    private void CreatedAndJoinRoom()
    {
        string randomRoonName = "Sala_" + mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;


        string[] roomPropsInlobby = { MultiplayerVRConstants.MAP_TYPE_KEY };

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType} };

        roomOptions.CustomRoomPropertiesForLobby = roomPropsInlobby;
        roomOptions.CustomRoomProperties = customRoomProperties;


        PhotonNetwork.CreateRoom(randomRoonName, roomOptions);
    }
    #endregion
}