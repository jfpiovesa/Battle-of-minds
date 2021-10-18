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

        _questions.Add(new Question(2, "O que busca o ODS7 (Objetivo de Desenvolvimento Sustentável)?", false));
        answersList.Add(new Answer(1, "Assegurar uma vida saudável e promover o bem-estar para todos, em todas as idades.", false));
        answersList.Add(new Answer(2, "Fortalecer os meios de implementação e revitalizar a parceria global para o desenvolvimento sustentável.", false));
        answersList.Add(new Answer(3, "Conservação e uso sustentável dos oceanos, dos mares e dos recursos marinhos para o desenvolvimento sustentável.", false));
        answersList.Add(new Answer(4, "Garantir acesso à energia barata, confiável, sustentável e renovável para todos.", true));
        _answers.Add(answersList);


        _questions.Add(new Question(5,"Até 2030, assegurar o acesso universal, confiável, moderno e a preços acessíveis a serviços de energia. Qual meta se refere o texto?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "meta 7.c", false));
        answersList.Add(new Answer(2, "Emeta 7.1", true));
        answersList.Add(new Answer(3, "meta 7.6", false));
        answersList.Add(new Answer(4, "meta 7.4", false));
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

        _questions.Add(new Question(6, "Até 2030, aumentar substancialmente a participação de energias renováveis na matriz energética global. Qual meta se refere o texto?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "meta 7.c", false));
        answersList.Add(new Answer(2, "meta 7.1", false));
        answersList.Add(new Answer(3, "meta 7.3", false));
        answersList.Add(new Answer(4, "meta 7.2", true));
        _answers.Add(answersList);

        _questions.Add(new Question(14, "Até 2030, dobrar a taxa global de melhoria da eficiência energética. Qual meta se refere o texto?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "meta 7.c", false));
        answersList.Add(new Answer(3, "meta 7.a", false));
        answersList.Add(new Answer(2, "meta 7.3", true));
        answersList.Add(new Answer(4, "meta 7.8", false));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "Até 2030, reforçar a cooperação internacional para facilitar o acesso a pesquisa e tecnologias de energia limpa, incluindo energias renováveis, eficiência energética e tecnologias de combustíveis fósseis avançadas e mais limpas, e promover o investimento em infraestrutura de energia e em tecnologias de energia limpa. Qual meta se refere o texto?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "meta 7.c", false));
        answersList.Add(new Answer(2, "meta 7.a", true));
        answersList.Add(new Answer(3, "meta 7.3 ", false));
        answersList.Add(new Answer(4, "meta 7.1", false));
        _answers.Add(answersList);

        _questions.Add(new Question(7, "Expandir a infraestrutura e modernizar a tecnologia para o fornecimento de serviços de energia modernos e sustentáveis para todos nos países em desenvolvimento, particularmente nos países menos desenvolvidos.... Qual meta se refere o texto?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "meta 7.c", false));
        answersList.Add(new Answer(2, "meta 7.a ", false));
        answersList.Add(new Answer(3, "meta 7.b", true));
        answersList.Add(new Answer(4, "meta 7.c", false));
        _answers.Add(answersList);

        _questions.Add(new Question(8, "Qual a definição de serviços e energia modernos citado na meta 7.b?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "São os que disponibilizam energias limpas e renováveis, com menor impacto no meio ambiente e maior emissão de gases de efeito estufa.", false));
        answersList.Add(new Answer(2, "São os que disponibilizam energias limpas e renováveis, com maior impacto no meio ambiente e menor emissão de gases de efeito estufa.", false));
        answersList.Add(new Answer(3, "São os que disponibilizam energias limpas e renováveis, com menor impacto no meio ambiente e menor emissão de gases de efeito estufa.", true));
        answersList.Add(new Answer(4, "Nenhuma das alternativas", false));
        _answers.Add(answersList);

        _questions.Add(new Question(9, "Qual a definição de energias limpas citada na meta 7.a?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "São as que liberam, após o processo de produção, resíduos ou gases poluentes.", false));
        answersList.Add(new Answer(2, "São as que não liberam, durante seu processo de produção ou de consumo, resíduos ou gases poluentes.", true));
        answersList.Add(new Answer(3, "São as que liberam, durante o seu consumo, resíduos ou gases poluentes.", false));
        answersList.Add(new Answer(4, "Nenhuma das alternativas", false));
        _answers.Add(answersList);


        _questions.Add(new Question(9, "Nas décadas de 1970 e 1980 houve, no Brasil, uma queda expressiva na intensidade energética, o que se deve isso?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "A substituição da lenha por outros energéticos mais eficientes.", true));
        answersList.Add(new Answer(2, "O uso exclusivo da energia nuclear, forma não poluente.", false));
        answersList.Add(new Answer(3, "O uso de lenha para queimada, recurso que gera energia e é uma energia limpa.", false));
        answersList.Add(new Answer(4, "Nenhuma das alternativas", false));
        _answers.Add(answersList);

        _questions.Add(new Question(10, "Qual a definição de energias modernas citada na meta 7.1?", false));
        answersList = new List<Answer>();
        answersList.Add(new Answer(1, "São as energias limpas e renováveis, que provocam menor impacto no meio ambiente e menor emissão de gases de efeito estufa.", true));
        answersList.Add(new Answer(2, "São as que por meio de lenha, carvão, petróleo etc.", false));
        answersList.Add(new Answer(3, "São as que liberam, durante o seu consumo e produção, resíduos ou gases poluentes.", false));
        answersList.Add(new Answer(4, "Nenhuma das alternativas", false));
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
