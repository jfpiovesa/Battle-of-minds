using Perangonline.PhotonQuis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour {

    public static QuestionController instance;

    public List<Question> _questions;
    private List<List<Answer>> _answers;

    [HideInInspector]
    public int questionIndex = 0;

    public int QuestionIndex
    {
        get
        {
            return questionIndex;
        }

        set
        {
            questionIndex = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadQuestions()
    {
        _questions = new List<Question>();
        _answers = new List<List<Answer>>();
        

        List<Answer> answersList = new List<Answer>();

        _questions.Add(new Question(2, " Qual é a flor nacional do Japão ? ", false));
        answersList.Add(new Answer(1, "Flor de Lótus", false));
        answersList.Add(new Answer(2, "Rosas", false));
        answersList.Add(new Answer(3, "Girassol", false));
        answersList.Add(new Answer(4, "Flor de Cerejeira", true));
        _answers.Add(answersList);


        _questions.Add(new Question(5, " Quem foi o principal líder da Guerra dos Canudos ? ", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, " Tiradentes ", false));
        answersList.Add(new Answer(2, " Antônio Conselheiro ", true));
        answersList.Add(new Answer(3, " Lucas de Oliveira ", false));
        answersList.Add(new Answer(4, " Antonio de Souza Neto ", false));
        _answers.Add(answersList);

        /**
        _questions.Add(new Question(14, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEV60mwJUTZRNquTmRYUJOAJJDwkBUvqQ6Xn_iixL480ioUxd9tBjLPF8B2qtLWvoAIwM&usqp=CAU", true));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Saturn", true));
        answersList.Add(new Answer(3, "Mars", false));
        answersList.Add(new Answer(2, "Jupiter", false));
        answersList.Add(new Answer(4, "Earth", false));
        _answers.Add(answersList);
        **/

        _questions.Add(new Question(6, " Quantos centímetros existem em 5 metros ? ", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, " 500 cm ", true));
        answersList.Add(new Answer(2, "5 cm", false));
        answersList.Add(new Answer(3, "5000 cm", false));
        answersList.Add(new Answer(4, "50 cm", false));
        _answers.Add(answersList);

        _questions.Add(new Question(14, "Qual é o nome do hormônio masculino produzido nos testículos?      ", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Estrogênio", false));
        answersList.Add(new Answer(3, "Teratogênico", false));
        answersList.Add(new Answer(2, "Testosterona", true));
        answersList.Add(new Answer(4, "Tireoide", false));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "Qual desses animais é mamífero?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Polvo", false));
        answersList.Add(new Answer(2, "Tubarão", false));
        answersList.Add(new Answer(3, "Cavalo-marinho", false));
        answersList.Add(new Answer(4, "Baleia ", true));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "Qual energia não é renovável?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Solar", false));
        answersList.Add(new Answer(2, "Eólica", false));
        answersList.Add(new Answer(3, "Nuclear", true));
        answersList.Add(new Answer(4, "Hidrelétrica", false));
        _answers.Add(answersList);

        _questions.Add(new Question(8, "Qual dos países abaixo não está localizado no continente africano?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Armênia", true));
        answersList.Add(new Answer(2, "Angola", false));
        answersList.Add(new Answer(3, "Togo", false));
        answersList.Add(new Answer(4, "Marrocos", false));
        _answers.Add(answersList);

        _questions.Add(new Question(9, "O osso mais longo e mais volumoso do corpo humano é o...", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Bigorna", false));
        answersList.Add(new Answer(2, "Metacarpo", false));
        answersList.Add(new Answer(3, "Martelo", false));
        answersList.Add(new Answer(4, "Fêmur", true));
        _answers.Add(answersList);


        _questions.Add(new Question(9, "O que pode ser Lixo Orgânico?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Vidro", false));
        answersList.Add(new Answer(2, "Metal", false));
        answersList.Add(new Answer(3, "Restos de alimentos", true));
        answersList.Add(new Answer(4, "Plásticos", false));
        _answers.Add(answersList);

        _questions.Add(new Question(10, "Quem possui a habilidade de Ecolocalização:", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Peixes", false));
        answersList.Add(new Answer(2, "Golfinhos", true));
        answersList.Add(new Answer(3, "Polvos", false));
        answersList.Add(new Answer(4, "Carangueijos", false));
        _answers.Add(answersList);

        _questions.Add(new Question(12, "Em que continente está localizado o Catar?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Ásia", true));
        answersList.Add(new Answer(2, "África", false));
        answersList.Add(new Answer(3, "Oceania", false));
        answersList.Add(new Answer(4, "América do Sul", false));
        _answers.Add(answersList);

        _questions.Add(new Question(13, "O Tratado de Tordesilhas foi um acordo firmado entre:", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(2, "Holanda e Espanha", false));
        answersList.Add(new Answer(1, "Portugal e Itália", false));
        answersList.Add(new Answer(3, "Portugal e Espanha", true));
        answersList.Add(new Answer(4, "Portugal e Holanda", false));
        _answers.Add(answersList);

        _questions.Add(new Question(13, "O símbolo das Olimpiadas é composto por quantos anéis entrelaçados?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "7", false));
        answersList.Add(new Answer(3, "5", true));
        answersList.Add(new Answer(2, "6", false));
        answersList.Add(new Answer(4, "8", false));
        _answers.Add(answersList);

        _questions.Add(new Question(14, "De qual cidade vieram os Beatles?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Londres", false));
        answersList.Add(new Answer(3, "Paris", false));
        answersList.Add(new Answer(2, "Liverpool", true));
        answersList.Add(new Answer(4, "Amsterdã", false));
        _answers.Add(answersList);


    }
    public void Next()
    {
        if( QuestionIndex < _questions.Count  )
        {
            GameUIController.instance.ShowQuestion(_questions[QuestionIndex], _answers[QuestionIndex]);
            GameUIController.instance.EnableBuzzer(true);
            GameUIController.instance.EnableAnswers(false);

            QuestionIndex++;
        }
        else
        {
            GameUIController.instance.ShowResult();
            GameUIController.instance.EnableBuzzer(false);
            GameUIController.instance.EnableAnswers(false);
        }


    }



     

    public void Next(int index)
    {

        if (index < _questions.Count )
        {
            GameUIController.instance.ShowQuestion(_questions[index], _answers[index]);
            GameUIController.instance.EnableBuzzer(true);
            GameUIController.instance.EnableAnswers(false);
        }
        else
        {
            GameUIController.instance.ShowResult();
            GameUIController.instance.EnableBuzzer(false);
            GameUIController.instance.EnableAnswers(false);
        }

            
        

    }
}
