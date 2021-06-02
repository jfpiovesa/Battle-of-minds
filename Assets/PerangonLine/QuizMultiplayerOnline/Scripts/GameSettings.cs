using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public static GameSettings instance;
    [Range(2,2)]
    public int MaxPlayers = 2;
    
    [Header("build index Game Scene")]
    [Tooltip("Jangan lupa ganti dengan build index Game Scene")]
    public int GameScene = 2;

    [Space(10)] // 10 pixels of spacing here.
    [Header("Game Rules")]
    [Range(1,100)]
    public int AnswerTime = 10;
    public int AnswerPoints = 10;
    public int QuestionTime = 30;
    

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
