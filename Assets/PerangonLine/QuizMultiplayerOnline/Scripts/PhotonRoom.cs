using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum GameState
{
    waiting,
    started,
    ended
}
public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public static PhotonRoom instance;

    public int NumOfWrongAnswerPlayer = 0;

    [SerializeField]
    private Hashtable players = new Hashtable();

    public int[] playerScore;// = new int[GameSettings.instance.MaxPlayers];


    private GameState gameState;

    private int numberOfPlayers;

    [SerializeField]
    private PhotonView _photonView;

    
    public Hashtable Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }

        

 

        gameState = GameState.waiting;
        DontDestroyOnLoad(this);

        playerScore = new int[2];

    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }



    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        numberOfPlayers = PhotonNetwork.PlayerList.Length;
        string name = PlayerPrefs.GetString("PlayerName");
        PhotonNetwork.NickName = name;

        CheckPlayer();

        _photonView.RPC("RPC_UpdateNumberPlayers", RpcTarget.All);


    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        numberOfPlayers = PhotonNetwork.PlayerList.Length;

        

        
        if(numberOfPlayers == GameSettings.instance.MaxPlayers)
        {

        }

        CheckPlayer();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        //PhotonNetwork.ReconnectAndRejoin();

        if(GameUIController.instance != null)
          GameUIController.instance.ShowResult((int)GameUIController.ResultType.Disconnected);
    }



    private void CheckPlayer()
    {


        if (!PhotonNetwork.IsMasterClient)
            return;

        if (numberOfPlayers == GameSettings.instance.MaxPlayers)
        {
            StartGame();
        }
    }


    private void StartGame()
    {
        gameState = GameState.started;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        SceneManager.LoadScene(GameSettings.instance.GameScene);

         
        _photonView.RPC("LoadPlayers", RpcTarget.All);


    }


    private bool PlayerCreated = false;

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == GameSettings.instance.GameScene)
        {
            if( ! PlayerCreated)
            {
                RPC_CreatePlayer();
                PlayerCreated = true;
            }
            
        }
    }

    [PunRPC]
    public void RPC_UpdateScore(string PlayerName, int Points)
    {
        int _score = 0;
        foreach (DictionaryEntry entry in players)
        {
            if (entry.Key as string == PlayerName)
            {
                Debug.Log(entry.Key);
                _score = (int)entry.Value + Points;
                players[entry.Key] = _score;


                break;
            }
        }

        foreach (DictionaryEntry entry in players)
        {

            GameUIController.instance.UpdateScore(entry.Key.ToString(), (int)entry.Value);


        }
    }

    [PunRPC]
    public void StopTimerAnswerAllPlayer()
    {
        Player[] _players = PhotonNetwork.PlayerList;
        for (int i = 0; i < _players.Length; i++)
        {


            GameUIController.instance.StopAnswerTimer();
            GameUIController.instance.PlayerBellNotif[i].SetActive(false);

        }

         
            
    }

    [PunRPC]
    public void RingBellNotifOnPlayer(string PlayerName)
    {
        Player[] _players = PhotonNetwork.PlayerList;
        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i].NickName == PlayerName)
            {

                
                GameUIController.instance.BellNotifOn(PlayerName);
               

            }
        }

        
    }

    [PunRPC]
    public void setHurryUpToAll(bool newVal)
    {
        GameUIController.instance.HurryUp = newVal;
    }


    public void AddScore(string PlayerName, int Points)
    {

        Player[] _players = PhotonNetwork.PlayerList;

        for (int i = 0; i < _players.Length; i++)
        {
           if (_players[i].NickName  == PlayerName)
            {

                playerScore[i] += Points;
                GameUIController.instance.UpdateScore(PlayerName, playerScore[i]);

            }
        }

       


        /*
        int _score = 0;
        foreach (DictionaryEntry entry in players)
        {
            if (entry.Key as string == PlayerName)
            {
                Debug.Log(entry.Key);
                _score = (int)entry.Value + Points;
                players[entry.Key] = _score;


                break;
            }
        }


        GameUIController.instance.UpdateScore(PlayerName, _score);
        */

        //_photonView.RPC("RPC_UpdateScore", RpcTarget.Others, PlayerName, Points);



    }

    [PunRPC]
    public void RPC_CreatePlayer()
    {
        GameObject obj = PhotonNetwork.Instantiate("prefabs/PlayerObject", Vector3.zero, Quaternion.identity);
    }

    [PunRPC]
    public void RPC_UpdateNumberPlayers()
    {
        if (SceneManager.GetActiveScene().buildIndex != GameSettings.instance.GameScene)
            UIController.instance.ShowMessage("Procurando Jogador\n" + numberOfPlayers + "/" + GameSettings.instance.MaxPlayers);
    }

    [PunRPC]
    public void LoadPlayers()
    {
        Player[] _players = PhotonNetwork.PlayerList;

        for (int i = 0; i < _players.Length; i++)
        {
            Debug.Log("added player: " + _players[i].NickName);
            players.Add(_players[i].NickName, 0);
        }
       
    }

    public void LeaveRoom()
    {
        


      


        PhotonNetwork.LeaveRoom(); /// With only this line, local player will leaveRoom and join MasterServer, which I don't want. (In this example, he will reconnect to the room)
        //PhotonNetwork.Disconnect();
        GameUIController.instance.ShowResult((int)GameUIController.ResultType.PlayerLeave, "", PlayerPrefs.GetString("PlayerName"));

    }

    override
    public void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("PhotonPlayer left the room : " + otherPlayer.NickName);

        if( QuestionController.instance.QuestionIndex < QuestionController.instance._questions.Count )
            GameUIController.instance.ShowResult( (int)  GameUIController.ResultType.PlayerLeave, "", otherPlayer.NickName);
        else if (QuestionController.instance.QuestionIndex >= QuestionController.instance._questions.Count)
            GameUIController.instance.ShowResult((int)GameUIController.ResultType.AllAnswered);

        /*
        if (instance != null)
            Destroy(instance);

        

        if (CanvasLoadingPhoton.instance != null)
            Destroy(CanvasLoadingPhoton.instance.gameObject);

    */


    }



    public  void OnPhotonPlayerConnected(Player newPlayer)
    {
        Debug.Log("PhotonPlayer entered the room : " + newPlayer.UserId);
    }

    public  void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected from Photon");
        PhotonNetwork.ReconnectAndRejoin();
    }

    public void OnPhotonPlayerDisconnected(Player otherPlayer)
    {
        Debug.Log("OnPhotonPlayerDisconnected   : " + otherPlayer.NickName);
        
    }

    void OnApplicationQuit()
    {

       // this.SendQuitEvent();
    }

    // optional
    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
           // this.SendQuitEvent();
        }
    }

    // optional
    void OnApplicationFocus(bool focused)
    {
        if (!focused)
        {
            //this.SendQuitEvent();
        }
    }

    

    public void SendQuitEvent()
    {
       // PhotonNetwork.Disconnect();

       // // send event, add your code here
       // GameUIController.instance.ShowResult();
       // PhotonNetwork.SendAllOutgoingCommands(); // send it right now
    }
}