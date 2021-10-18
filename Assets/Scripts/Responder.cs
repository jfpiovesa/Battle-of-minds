using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Responder : MonoBehaviour
{
    public static Responder responder;
   

    public UnityEvent evente;
    public int idtema;//id do tema 

    public Text infoResposta;
    public Text pergunta;

    public Text resposta_A;
    public Text resposta_B;
    public Text resposta_C;
    public Text resposta_D;


    public List<string> perguntas; //armazena todas as perguntas
    public List<string> alternativa_A;//armazena todas as alternativas a
    public List<string> alternativa_B;//armazena todas as alternativas b
    public List<string> alternativa_C;//armazena todas as alternativas c
    public List<string> alternativa_D;//armazena todas as alternativas d

    public string[] corretas;//armazena todas as alternativas correntas

    private int id_perguntas;

    private float acertos = 0;
    private float quetoes = 0;
    private float media = 0;
    private int notafinal = 0;

    public Text timerText;
    private float startTime = 60.0f;
    public Image conometro;
    public string l;

    public bool m_pl = false;


    public GameObject ps2, player;

    public GameObject[] vf;

    bool stopTime = true;
    bool rs = false;
    float timeRunTime = 0.5f;



    public void Awake()
    {
        if (responder == null)
        {
            responder = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        St();
       

        
        idtema = PlayerPrefs.GetInt("idtema");
        id_perguntas = 0;
        quetoes = perguntas.ToArray().Length;
        pergunta.text = perguntas[id_perguntas];

        resposta_A.text = perguntas[id_perguntas];
        resposta_B.text = alternativa_B[id_perguntas];
        resposta_C.text = alternativa_C[id_perguntas];
        resposta_D.text = alternativa_D[id_perguntas];

        infoResposta.text = " Respondendo " + (idtema) + " de " + quetoes.ToString() + " perguntas. ";

        conometro.fillAmount = startTime;
        
    }
    private void Update()
    {
        conometro.fillAmount = startTime/60;
        if(stopTime == true)
        {
            rs = true;
            timeRunTime = 0.5f;
            foreach (GameObject g in vf)
            {
                g.gameObject.SetActive(false);
            }

            startTime -= Time.deltaTime;

            // string minutes = ((int)startTime / 60).ToString();
             string seconds = (startTime % 60).ToString("f0");
            timerText.text =  seconds;
          
        }    

        // para que se o tempo  for 0  volte o conometro a  o valor da contagem  quando as perguntas passarem 
        if (startTime <= 0)
        {

            resposta(l);

            timeRunTime -= Time.deltaTime;
            stopTime = false;
            

        }
        if (timeRunTime <= 0)
        {
           

            proximapergunta();
            startTime = 60;
            St();
            stopTime = true;
         
        }
    }
    
    public void resposta(string alternativa)// verificação de resposta se elas são verdadeiras e se são iguas as corretas se sim soma um acerto se não vai ate final e  pula pra proxima pergunta 
    {

        if (rs == true)
        {

            if (alternativa == "A" && m_pl == true)
            {

                if (alternativa_A[id_perguntas] == corretas[id_perguntas])
                {

                    vf[0].gameObject.SetActive(true);
                    acertos += 1;

                }
                else
                {
                    vf[1].gameObject.SetActive(true);
                }

            }

            else if (alternativa == "B" && m_pl == true)
            {


                if (alternativa_B[id_perguntas] == corretas[id_perguntas])
                {
                    vf[2].gameObject.SetActive(true);
                    acertos += 1;

                }
                else
                {
                    vf[3].gameObject.SetActive(true);
                }
            }

            else if (alternativa == "C" && m_pl == true)
            {

                if (alternativa_C[id_perguntas] == corretas[id_perguntas])
                {
                    vf[4].gameObject.SetActive(true);
                    acertos += 1;

                }
                else
                {
                    vf[5].gameObject.SetActive(true);
                }
            }

            else if (alternativa == "D" && m_pl == true)
            {


                if (alternativa_D[id_perguntas] == corretas[id_perguntas])
                {
                    vf[6].gameObject.SetActive(true);
                    acertos += 1;

                }
                else
                {
                    vf[7].gameObject.SetActive(true);
                }
            }
            rs = false;

        }

    }
    
    public void proximapergunta()
    {
        //proximas pertuntas  e tempo do conometro entra no valor inicial de novo 
        

           id_perguntas += 1;
           startTime = 60;
           if (id_perguntas < quetoes)
            {

           
                pergunta.text = perguntas[id_perguntas];

                resposta_A.text = alternativa_A[id_perguntas];
                resposta_B.text = alternativa_B[id_perguntas];
                resposta_C.text = alternativa_C[id_perguntas];
                resposta_D.text = alternativa_D[id_perguntas];

                infoResposta.text = " Respondendo " + (id_perguntas +1) + " de " + quetoes.ToString() + " perguntas. ";
               m_pl = false;
           }
           else
            {   // oque fazer quando termina as perguntas.
                media = 10 * (acertos /10);// calcula a media  na porcetagem dos acertos.

                notafinal = Mathf.RoundToInt(media);// arredonda a nota para o proximo inteiro,segindo a regra da matetmarica.

                if (notafinal > PlayerPrefs.GetInt("Nota" + idtema.ToString()))
                {
                    PlayerPrefs.SetInt("Nota" + idtema.ToString(), notafinal);
                    PlayerPrefs.SetInt("Acertos" + idtema.ToString(), (int)acertos);
                 
            }
                PlayerPrefs.SetInt("Notatemp" + idtema.ToString(), notafinal);
                PlayerPrefs.SetInt("Acertostemp" + idtema.ToString(), (int)acertos);
                PlayerPrefs.SetInt("Questoestemp" + idtema.ToString(), (int)quetoes);

            evente.Invoke();

        }     
           
    }
    public void Apertou(GameObject p)
    {
        if (startTime >= 0)
            player.transform.position = p.transform.position;
        
    }
    public void St()
    {
        player.transform.position = ps2.transform.position;
        l = "";
        m_pl = false;
    }
    public void LetraScolha(string letra)
    {
        startTime = 0.2f;
        if (startTime >=0 )
                 l = letra;
                 m_pl = true;

    }

 

}
