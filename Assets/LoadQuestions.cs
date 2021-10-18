using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadQuestions : MonoBehaviour
{

    [Header("Quetions")]
    private int valorQuetions;
    private string questionPath = "Assets/Questions/";
    private QuestionCollection QuestionCollection;
    // Start is called before the first frame update
    void Start()
    {
       valorQuetions = PlayerPrefs.GetInt("idtema");

        LoadQuest();
    }

    [ContextMenu("Load Questions")]
    private void LoadQuest()
    {
        string nome = "Question" + valorQuetions + ".json";
        using (StreamReader stream = new StreamReader(nome))
        {
            string jason = stream.ReadToEnd();
            QuestionCollection = JsonUtility.FromJson<QuestionCollection>(jason);

        }

    }
}
