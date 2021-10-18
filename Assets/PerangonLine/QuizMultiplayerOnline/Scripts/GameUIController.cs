using Perangonline.PhotonQuis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;

public class GameUIController : MonoBehaviour {

    public static GameUIController instance;

    [SerializeField]
    public List<GameObject> PlayerBellNotif;

    [SerializeField]
    public GameObject WrongAnswerNotif;


    [SerializeField]
    public GameObject PanelResult;

    public Button ButtonExitRoom;

    [SerializeField]
    private Image QuestionImage;
    [SerializeField]
    private Text QuestionText;
    [SerializeField]
    private Button Answer1;
    [SerializeField]
    private Button Answer2;
    [SerializeField]
    private Button Answer3;
    [SerializeField]
    private Button Answer4;

    [SerializeField]
    private Image player1;
    [SerializeField]
    private Image player2;
    [SerializeField]
    private Image player3;

    [SerializeField]
    private Button BuzzerButton;
    [SerializeField]
    private Text Timer;
    [SerializeField]
    private Text QuestionTime;

    private Text scorePlayer1;
    private Text scorePlayer2;
    private Text scorePlayer3;


    private readonly byte RequestAnswer = 0;
    private readonly byte RightAnswer = 1;
    private readonly byte WrongAnswer = 2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scorePlayer1 = player1.transform.GetChild(1).GetComponent<Text>();
        scorePlayer2 = player2.transform.GetChild(1).GetComponent<Text>();
        //scorePlayer3 = player3.transform.GetChild(1).GetComponent<Text>();

        EnableAnswers(false);
        EnableBuzzer(false);


        ButtonExitRoom.onClick.AddListener(() => {
            PhotonRoom.instance.LeaveRoom();
        });
    }

    public void EnableAnswers(bool enabled)
    {
        Answer1.enabled = enabled;
        Answer2.enabled = enabled;
        Answer3.enabled = enabled;
        Answer4.enabled = enabled;

 
    }

    public void ActivateAnswers(bool active)
    {
        Answer1.gameObject.SetActive(active);
        Answer2.gameObject.SetActive(active);
        Answer3.gameObject.SetActive(active);
        Answer4.gameObject.SetActive(active);

        if (!active)
        {
            QuestionText.gameObject.SetActive(false);
            QuestionImage.gameObject.SetActive(false);
        }
    }


    public enum  ResultType{   AllAnswered, Timeup, PlayerLeave, Disconnected };
    private bool isDraw = true;

    [HideInInspector]
    public bool ResultIsShown = false;

    public void ShowResult(int resulttype = 0, string WinnerNickname = "", string runningAwayNickname = "")
    {
        if(!ResultIsShown)
        {
            PanelResult ps = PanelResult.GetComponent<PanelResult>();
            int BestScore = 0;

            if (resulttype == (int)ResultType.AllAnswered)
            {
                ps.ResultDesc.text = "Completo!";

                if (PhotonRoom.instance.playerScore[0] == PhotonRoom.instance.playerScore[1])
                {
                    isDraw = true;
                }
                else
                {
                    Player[] _players = PhotonNetwork.PlayerList;

                    BestScore = Math.Max(PhotonRoom.instance.playerScore[0], PhotonRoom.instance.playerScore[1]);
                    int winner = -1;

                    for (int i = 0; i < PhotonRoom.instance.playerScore.Length; i++)
                    {
                        if (BestScore == PhotonRoom.instance.playerScore[i])
                        {
                            winner = i;
                            break;
                        }
                    }

                    if (winner != -1)
                    {
                        isDraw = false;
                        WinnerNickname = _players[winner].NickName;
                    }
                }


                if (isDraw)
                {
                    ps.ResultDesc.text += "\r\n" + "\r\n" + "EMPATE!";
                }
                else
                {
                    if (WinnerNickname == PlayerPrefs.GetString("PlayerName"))
                        ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Venceu!";
                    else
                        ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Perdeu!";

                    ps.ResultDesc.text += "\r\n" + "\r\n" + "HighScore: " + BestScore + ". Vencedor: " + WinnerNickname;
                }







            }
            else if (resulttype == (int)ResultType.Timeup || resulttype == (int)ResultType.Disconnected)
            {
                if(resulttype == (int)ResultType.Timeup)
                    ps.ResultDesc.text = "Timeout!";
                else
                    ps.ResultDesc.text = "Desconectado!";

                if (PhotonRoom.instance.playerScore[0] == PhotonRoom.instance.playerScore[1])
                {
                    isDraw = true;
                }
                else
                {
                    Player[] _players = PhotonNetwork.PlayerList;

                    BestScore = Math.Max(PhotonRoom.instance.playerScore[0], PhotonRoom.instance.playerScore[1]);
                    int winner = -1;

                    for (int i = 0; i < PhotonRoom.instance.playerScore.Length; i++)
                    {
                        if (BestScore == PhotonRoom.instance.playerScore[i])
                        {
                            winner = i;
                            break;
                        }
                    }

                    if (winner != -1)
                    {
                        isDraw = false;
                        WinnerNickname = _players[winner].NickName;
                    }
                }


                if (isDraw)
                {
                    ps.ResultDesc.text += "\r\n" + "\r\n" + "EMPATE!";
                }
                else
                {
                    if (WinnerNickname == PlayerPrefs.GetString("PlayerName"))
                        ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Venceu!";
                    else
                        ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Perdeu!";

                    ps.ResultDesc.text += "\r\n" + "\r\n" + "HighScore: " + BestScore + ". Vencedor: " + WinnerNickname;
                }
            }
            else if (resulttype == (int)ResultType.PlayerLeave)
            {
                ps.ResultDesc.text = "Player Abandonou!";


                if (runningAwayNickname == PlayerPrefs.GetString("PlayerName"))
                {
                    ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Perdeu!";
                }
                else
                {
                    ps.ResultDesc.text += "\r\n" + "\r\n" + "Você Venceu!";
                }
            }





            PanelResult.SetActive(true);
            ResultIsShown = true;

        }
        
    }

    public void ShowQuestion(Question question, List<Answer> answers)
    {
        StopAllCoroutines();
        StartCoroutine("QuestionTimer");

        if (question.IsImage)
        {
            QuestionText.gameObject.SetActive(false);
            QuestionImage.gameObject.SetActive(true);
            StartCoroutine(LoadImage(QuestionImage, question.Description));
        }
        else
        {
            QuestionImage.gameObject.SetActive(false);
            QuestionText.gameObject.SetActive(true);
            QuestionText.text = question.Description;
        }

        ActivateAnswers(true);

        Answer1.transform.GetChild(0).GetComponent<Text>().text = answers[0].Description;
        Answer1.tag = answers[0].IsTrue ? "true_answer" : "Untagged";

        Answer2.transform.GetChild(0).GetComponent<Text>().text = answers[1].Description;
        Answer2.tag = answers[1].IsTrue ? "true_answer" : "Untagged";

        Answer3.transform.GetChild(0).GetComponent<Text>().text = answers[2].Description;
        Answer3.tag = answers[2].IsTrue ? "true_answer" : "Untagged";

        Answer4.transform.GetChild(0).GetComponent<Text>().text = answers[3].Description;
        Answer4.tag = answers[3].IsTrue ? "true_answer" : "Untagged";

    }

    public static IEnumerator LoadImage(Image image, string url)
    {
        WWW www = new WWW(url);

        yield return www;
        
        www.LoadImageIntoTexture(image.mainTexture as Texture2D);
        www = null;


    }


    public void BellNotifOn(string playerName)
    {
        int playerNumber = GetPlayerNumber(playerName);
        Debug.Log("number: " + playerNumber + " name: " + playerName + " ring bell: ");
        switch (playerNumber)
        {
            case 1:
                PlayerBellNotif[0].SetActive(true);
                break;
            case 2:
                PlayerBellNotif[1].SetActive(true);

                break;

           
        }
    }

     
    public void UpdateScore(string playerName, int score)
    {
        int playerNumber = GetPlayerNumber(playerName);

        Debug.Log("número: " + playerNumber + " nome: " + playerName + " score: " + score );

        switch (playerNumber)
        {
            case 1:
                scorePlayer1.text = score.ToString();
                break;
            case 2:
                scorePlayer2.text = score.ToString();

                break;

                /*
            case 3:
                scorePlayer3.text = score.ToString();
                break;

                */
        }
    }

    public void PreparePlayers(Player[] players)
    {
        player1.transform.GetChild(0).GetComponent<Text>().text = players[0].NickName;
        player2.transform.GetChild(0).GetComponent<Text>().text = players[1].NickName;
        //player3.transform.GetChild(0).GetComponent<Text>().text = players[2].NickName;
    }

    public void OnBuzzerClick()
    {
        
        EnableBuzzer(false);
        

        object[] content = new object[] { PlayerPrefs.GetString("PlayerName") };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All};
        SendOptions sendOptions = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(RequestAnswer, content, raiseEventOptions, sendOptions);
        
    }



    public void EnableBuzzer(bool enabled)
    {
        BuzzerButton.enabled = enabled;
    }
        
    public int GetPlayerNumber(string playerName)
    {
        if (player1.transform.GetChild(0).GetComponent<Text>().text == playerName)
            return 1;
        if (player2.transform.GetChild(0).GetComponent<Text>().text == playerName)
            return 2;

        return 3;
    }

    public void OnAnswerClick(Button button)
    {
        
        EnableAnswers(false);
        StopCoroutine(AnswerTimer());
        Timer.text = "";
        Timer.gameObject.SetActive(false);

        RaiseAnswerEvent(button.tag == "true_answer" ? RightAnswer : WrongAnswer);

    }

    public void RaiseAnswerEvent(byte code)
    {
        object[] content = new object[] { PlayerPrefs.GetString("PlayerName") };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };

        PhotonNetwork.RaiseEvent(code, content, raiseEventOptions, sendOptions);
    }

    private bool AnswerTimeStarted = false;


    [HideInInspector]
    public bool HurryUp;// true if answertime remaining is less than QuestionTImeRemainingtime

    public void StartAnswerTimer()
    {
        AnswerTimeStarted = true;
        Timer.gameObject.SetActive(true);
        HurryUp = false;

        if (GameSettings.instance.AnswerTime < QuestionTImeRemainingtime)
            AnswerTimeRemaining = GameSettings.instance.AnswerTime;
        else
        {
            HurryUp = true;

            //PhotonRoom.instance.photonView.RPC("setHurryUpToAll", RpcTarget.All, true);


            AnswerTimeRemaining = QuestionTImeRemainingtime;
        }
           


        StartCoroutine("AnswerTimer");
    }

    public void StopAnswerTimer()
    {
        AnswerTimeStarted = false;
        Timer.gameObject.SetActive(false);


        

        StopCoroutine("AnswerTimer");
    }

    float AnswerTimeRemaining = 0f;

    private IEnumerator AnswerTimer()
    {
         

        if(AnswerTimeStarted)
        {
            

            do
            {
                AnswerTimeRemaining -= Time.deltaTime;
                Timer.text = Math.Round(AnswerTimeRemaining, 1).ToString();
                //Timer.text = "" + timeRemaining;
                yield return null;

            } while (AnswerTimeRemaining >= 0f);


            if(AnswerTimeRemaining <= 0f)
            {
                //Debug.Log("timeRemaining = " + timeRemaining);
                AnswerTimeStarted = false;

                if(!HurryUp)
                    RaiseAnswerEvent(WrongAnswer); // di sini ada fungsi next question, jangan sampai balapan dengan questiontimer


                StopAnswerTimer();
            }
            

        }
        
    }

    float QuestionTImeRemainingtime;

    private IEnumerator QuestionTimer()
    {
         QuestionTImeRemainingtime = GameSettings.instance.QuestionTime;

        do
        {
            QuestionTImeRemainingtime -= Time.deltaTime;

            QuestionTime.text = ((int)QuestionTImeRemainingtime).ToString();

            yield return null;
        } while (QuestionTImeRemainingtime >= 0);

        //
        //PhotonRoom.instance.NumOfWrongAnswerPlayer = 1;
        //RaiseAnswerEvent(WrongAnswer);

        if(true) //(HurryUp)  
        {

            object[] content = new object[] { QuestionController.instance.QuestionIndex };//send current question index 
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            SendOptions sendOptions = new SendOptions { Reliability = true };

            PhotonNetwork.RaiseEvent(3, content, raiseEventOptions, sendOptions);


            //one player send broadcast to all
            //PhotonRoom.instance.NumOfWrongAnswerPlayer += 1;
            //RaiseAnswerEvent(3); //send to all

            /*
            //ShowResult((int) ResultType.AllAnswered, "", "");
            
            QuestionController.instance.QuestionIndex += 1;

            QuestionController.instance.Next(QuestionController.instance.QuestionIndex);
            GameUIController.instance.EnableBuzzer(true);


            PhotonRoom.instance.NumOfWrongAnswerPlayer = 0;
            */


        }
        else
        {
            /*
            if(PhotonRoom.instance.NumOfWrongAnswerPlayer<2)
            {
                 //RaiseAnswerEvent(3);
                //every player load next question individually


                QuestionController.instance.QuestionIndex += 1;

                QuestionController.instance.Next(QuestionController.instance.QuestionIndex);
                GameUIController.instance.EnableBuzzer(true);


                PhotonRoom.instance.NumOfWrongAnswerPlayer = 0;
                
            }

            */
                
        }

        

            
        

        GameUIController.instance.WrongAnswerNotif.SetActive(false);

        for (int i = 0; i < GameUIController.instance.PlayerBellNotif.Count; i++)
            GameUIController.instance.PlayerBellNotif[i].SetActive(false);
            

    }

}
