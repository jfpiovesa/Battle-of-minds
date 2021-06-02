using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ExitGames.Client.Photon;

namespace Perangonline.PhotonQuis.Controlelrs
{
    public class PlayerRPCHandler : MonoBehaviour, IOnEventCallback
    {

        public float StartDelay = 1.5f;
        [SerializeField]
        private PhotonView _photonView;

        private GPlayer _player;
        private bool _canAnswer = false;
        private bool _answered = false;


        private readonly byte RequestAnswer = 0;
        private readonly byte RightAnswer = 1;
        private readonly byte WrongAnswer = 2;

        private bool masterNext = false;

        public bool CanAnswer
        {
            get
            {
                return _canAnswer;
            }

            set
            {
                _canAnswer = value;
            }
        }

        private void Start()
        {
            

            _player = GetComponent<GPlayer>();

            if (_photonView.IsMine)
                _photonView.RPC("SetPlayer", RpcTarget.All, PlayerPrefs.GetString("PlayerName"));

            if (PhotonNetwork.IsMasterClient)
            {
                PreparePlayers();
                _photonView.RPC("PreparePlayers", RpcTarget.Others);
            }

        }

    
        public void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }


        public void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        [PunRPC]
        public void SetPlayer(string name)
        {
            if (_player == null)
                _player = GetComponent<GPlayer>();

            _player.PlayerName = name;
        }

 

        [PunRPC]
        public void PreparePlayers()
        {
            GameUIController.instance.PreparePlayers(PhotonNetwork.PlayerList);


            QuestionController.instance.LoadQuestions();

            

              


            StartCoroutine(WaitStart(StartDelay));
        }



        private IEnumerator WaitStart(float delay)
        {
            yield return new WaitForSeconds(delay);

            // QuestionController.instance.Next();
            QuestionController.instance.questionIndex = 0;
            QuestionController.instance.Next(0);

            if (PhotonNetwork.IsMasterClient)
                QuestionController.instance.Next(0);

            
            CanAnswer = true;
        }


        IEnumerator hideWrongAnswerNotif()
        {
            yield return new WaitForSeconds(2);
            GameUIController.instance.WrongAnswerNotif.SetActive(false);
        }
        

        public void OnEvent(EventData photonEvent)
        {

            Debug.Log("OnEvent code: " + photonEvent.Code);

            if (!_photonView.IsMine)
                return;

            if (photonEvent.Code > 3)
                return;


            string playerName = ((object[])photonEvent.CustomData)[0] as string;
            
            switch (photonEvent.Code)
            {
                case 0: 

                    Player[] players = PhotonNetwork.PlayerList;

                    for (int i = 0; i < players.Length; i++)
                    {
                        if (playerName == PhotonNetwork.NickName)
                        {
                            if (CanAnswer)
                            {

                                //PhotonRoom.instance.RingBellNotifOnPlayer(playerName);
                                //StopTimerAnswerAllPlayer
                                PhotonRoom.instance.photonView.RPC ("RingBellNotifOnPlayer",  RpcTarget.All, playerName);

                                GameUIController.instance.EnableAnswers(true);
                                
                                GameUIController.instance.StartAnswerTimer();
                                _answered = true;
                                return;

                            }
                        }
                    }
                    CanAnswer = false;
                    GameUIController.instance.EnableBuzzer(false);
                    

                    break;
                case 1:

                    PhotonRoom.instance.AddScore(playerName, GameSettings.instance.AnswerPoints);
                    QuestionController.instance.QuestionIndex += 1;

                    //int index = PhotonNetwork.IsMasterClient ? QuestionController.instance.QuestionIndex - 1 : QuestionController.instance.QuestionIndex;
                    //QuestionController.instance.Next(index);

                    QuestionController.instance.Next(QuestionController.instance.QuestionIndex);


                    CanAnswer = true;
                    PhotonRoom.instance.  NumOfWrongAnswerPlayer = 0;

                    _answered = false;


                    //GameUIController.instance.WrongAnswerNotif.SetActive(false);

                    StartCoroutine("hideWrongAnswerNotif");

                    for (int i = 0; i< GameUIController.instance.PlayerBellNotif.Count; i++ )
                        GameUIController.instance.PlayerBellNotif[i].SetActive(false);

                    break;
                case 2: //wrong answer


                    GameUIController.instance.StopAnswerTimer();
                    //StopTimerAnswerAllPlayer
                    PhotonRoom.instance.photonView.RPC("StopTimerAnswerAllPlayer", RpcTarget.All);



                    PhotonRoom.instance.NumOfWrongAnswerPlayer++;

                    if (PhotonRoom.instance.NumOfWrongAnswerPlayer < 2)
                    {
                        if (_answered)
                        {
                            GameUIController.instance.WrongAnswerNotif.SetActive(true);
                            GameUIController.instance.ActivateAnswers(false);

                            

                            return;
                        }
                            

                        GameUIController.instance.EnableBuzzer(true);

                        CanAnswer = true;


                    }
                    else
                    {
                        GameUIController.instance.WrongAnswerNotif.SetActive(true);

                        QuestionController.instance.QuestionIndex += 1;

                        QuestionController.instance.Next(QuestionController.instance.QuestionIndex);
                    

                        CanAnswer = true;

                        _answered = false;

                        PhotonRoom.instance.NumOfWrongAnswerPlayer = 0;


                        GameUIController.instance.HurryUp = false;

                        //GameUIController.instance.WrongAnswerNotif.SetActive(false);
                        StartCoroutine("hideWrongAnswerNotif");

                        for (int i = 0; i < GameUIController.instance.PlayerBellNotif.Count; i++)
                            GameUIController.instance.PlayerBellNotif[i].SetActive(false);

                    }

                     

                    break;

                case 3: //timeout
                    object[] data = (object[])photonEvent.CustomData;
                    int x = (int)data[0];

                    QuestionController.instance.QuestionIndex = x;

                    QuestionController.instance.QuestionIndex += 1;

                    QuestionController.instance.Next(QuestionController.instance.QuestionIndex);


                    CanAnswer = true;

                    _answered = false;

                    PhotonRoom.instance.NumOfWrongAnswerPlayer = 0;


                    GameUIController.instance.HurryUp = false;

                    //GameUIController.instance.WrongAnswerNotif.SetActive(false);
                    StartCoroutine("hideWrongAnswerNotif");

                    for (int i = 0; i < GameUIController.instance.PlayerBellNotif.Count; i++)
                        GameUIController.instance.PlayerBellNotif[i].SetActive(false);


                    break;

            }
        }


    }
}