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

        _questions.Add(new Question(2, "Escolha a opção apenas com bibliotecas gráficas:", false));
        answersList.Add(new Answer(1, "Unity 3D e Cryengine", false));
        answersList.Add(new Answer(2, "Unreal Engine e Unity 3D", false));
        answersList.Add(new Answer(3, "Direct3D e OpenGL", true));
        answersList.Add(new Answer(4, "Todas corretas", false));
        _answers.Add(answersList);


        _questions.Add(new Question(5, "No Unity3D, para que serve a aba 'inspector'?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Inspeção no código", false));
        answersList.Add(new Answer(2, "Editar componentes e propriedades", true));
        answersList.Add(new Answer(3, "Corrigir o código", false));
        answersList.Add(new Answer(4, "Inspecionar o Project Body", false));
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

        _questions.Add(new Question(6, "O que é o Monobehaviour?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Uma Classe-base da Unity", true));
        answersList.Add(new Answer(2, "O Pai de todos os métodos", false));
        answersList.Add(new Answer(3, "Árvore de comportamento padrão", false));
        answersList.Add(new Answer(4, "Para Audio Mono ou Stereo", false));
        _answers.Add(answersList);

        _questions.Add(new Question(14, "Qual jogo foi desenvolvido utilizando UNREAL ENGINE?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Crysis 3", false));
        answersList.Add(new Answer(3, "Farcry", false));
        answersList.Add(new Answer(2, "Street Fighter V", true));
        answersList.Add(new Answer(4, "Call of Duty Modern Warfare", false));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "Se tratando de UNREAL, o que é BLUEPRINT?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Um template FPS", false));
        answersList.Add(new Answer(2, "Uma base de arquitetura", false));
        answersList.Add(new Answer(3, "Uma Impressão Visual Azul", false));
        answersList.Add(new Answer(4, "Sistema de Código Visual", true));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "PACMAN foi originalmente produzido para qual plataforma?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Atari 2600", false));
        answersList.Add(new Answer(2, "Atari 2021", false));
        answersList.Add(new Answer(3, "Arcade", true));
        answersList.Add(new Answer(4, "Comodoro", false));
        _answers.Add(answersList);

        _questions.Add(new Question(8, "Por padrão a janela _________ do Unity permite ver todos os Gameobjects em cena", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Hierarchy", true));
        answersList.Add(new Answer(2, "Inspector", false));
        answersList.Add(new Answer(3, "Game Manager", false));
        answersList.Add(new Answer(4, "Objectors Scene", false));
        _answers.Add(answersList);

        _questions.Add(new Question(9, "A janela SEQUENCER cria animações, e pertece a qual dessas Engines Gráficas?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "UNREAL ENGINE", true));
        answersList.Add(new Answer(2, "UNITY 2019.3.4", false));
        answersList.Add(new Answer(3, "CRYENGINE", false));
        answersList.Add(new Answer(4, "Todas possuem Sequencer Window", false));
        _answers.Add(answersList);


        _questions.Add(new Question(9, "O que faz a aba Navigation no Unity?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Da Aquele BAKE", false));
        answersList.Add(new Answer(2, "Machine Learning", false));
        answersList.Add(new Answer(3, "Cria malhas de navegação", true));
        answersList.Add(new Answer(4, "Cria uma árvore", false));
        _answers.Add(answersList);

        _questions.Add(new Question(10, "Extensão de Scripts CSharp?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, ".SC", false));
        answersList.Add(new Answer(2, ".CS", true));
        answersList.Add(new Answer(3, ".SV", false));
        answersList.Add(new Answer(4, ".XML", false));
        _answers.Add(answersList);

        _questions.Add(new Question(12, "Músico do Dire Straits que toca guitarra sem a palheta:", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Mark Knopfler", true));
        answersList.Add(new Answer(2, "Eric Clapton", false));
        answersList.Add(new Answer(3, "Billy Idol", false));
        answersList.Add(new Answer(4, "Supla", false));
        _answers.Add(answersList);

        _questions.Add(new Question(13, "Complete a frase: Everbody Wants To Rule The _____", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(2, "World", true));
        answersList.Add(new Answer(1, "MonoBehaviour", false));
        answersList.Add(new Answer(3, "Paper", false));
        answersList.Add(new Answer(4, "Music", false));
        _answers.Add(answersList);

        _questions.Add(new Question(13, "Tipo de diagrama comportamental na Linguagem de Modelagem Unificada:", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "UML", false));
        answersList.Add(new Answer(3, ".JSON", false));
        answersList.Add(new Answer(2, "Diagrama de Estados", true));
        answersList.Add(new Answer(4, "Estados Infinitos", false));
        _answers.Add(answersList);

        _questions.Add(new Question(14, "Possui uma série com Lendário motor V8-302 com 199 cavalos de potência máxima:", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "Dodge Charger Challenger", false));
        answersList.Add(new Answer(3, "Galaxie Landau", false));
        answersList.Add(new Answer(2, "Maverick", true));
        answersList.Add(new Answer(4, "Opalão", false));
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
