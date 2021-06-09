using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notafinal : MonoBehaviour
{
    private _comandosBasicos cb;
    private int idtema;

    public Text txtNota;
    public Text txtinfoTema;

    public GameObject estrela_1;
    public GameObject estrela_2;
    public GameObject estrela_3;

    private int notaf;
    private int acertos;
    int peguntas;


    void Start()
    {
        cb = FindObjectOfType<_comandosBasicos>() as _comandosBasicos;
        idtema = PlayerPrefs.GetInt("idtema");

        estrela_1.SetActive(false);
        estrela_2.SetActive(false);
        estrela_3.SetActive(false);


        // pega valor da  salvos no metodo playerprefs mas  temporaria para exibir na nota final 
        notaf = PlayerPrefs.GetInt("Notatemp" + idtema.ToString());
        acertos = PlayerPrefs.GetInt("Acertostemp" + idtema.ToString());
        peguntas = PlayerPrefs.GetInt("Questoestemp" + idtema.ToString());

        txtNota.text = notaf.ToString();
        txtinfoTema.text = " Você acertou " + acertos.ToString() + " de " + peguntas + " perguntas";

        // verificação de notas de estrelas com  as medias 
        if (notaf == 10)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(true);
            estrela_3.SetActive(true);
        }
        else if(notaf >= 7)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(true);
            estrela_3.SetActive(false);

        }
        else if (notaf >= 5)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(false);
            estrela_3.SetActive(false);

        }
    }

   
    public void jogarnovamente()
    {

        cb.carregando("T" + idtema.ToString());
    }
}
