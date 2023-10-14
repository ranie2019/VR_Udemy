using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoginManager : MonoBehaviourPunCallbacks
{
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion


    #region UI CallBack Methods
    public void ConnectAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    #endregion


    #region Photon Callback Methods
    public override void OnConnected()
    {
        Debug.Log("Conectado e ligando. O servidor esta abilitado");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao Servidor Master");
    }

    #endregion
}
