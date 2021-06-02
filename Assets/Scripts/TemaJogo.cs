using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemaJogo : MonoBehaviour
{
    private _comandosBasicos cb;
    // public Button        btnPlay;// botão de player
    public Text          textNomeTema;// texto do tema

    public GameObject    inftema;
    public Text          txtinfoTema;

    public GameObject    estrela_1;
    public GameObject    estrela_2; 
    public GameObject    estrela_3;

    public string[]      nometema;

    private int           idtema;

    public int           numerosquetoes;



    void Start()
    {
        cb = FindObjectOfType<_comandosBasicos>() as _comandosBasicos;
        idtema = 0;
        textNomeTema.text = nometema[idtema];
        txtinfoTema.text = "Você acertou x de x questões "; 
        inftema.SetActive(false);
        estrela_1.SetActive(false);
        estrela_2.SetActive(false);
        estrela_3.SetActive(false); 

      
    }

   public void selecioneTema(int i)// para selecionar o tema e vir com a verificaçõe de estrelas e acertos se ja jogou o tema 
    {
        
        idtema = i;

        PlayerPrefs.SetInt("idtema",idtema);// salva idtema  no metodo playerprefs para verificação futura
        textNomeTema.text = nometema[idtema];

        int notasfinal =  PlayerPrefs.GetInt("Nota" + idtema.ToString());// pega valor da nota salva no metodo playerprefs
        int acertos = PlayerPrefs.GetInt("Acertos" + idtema.ToString());// pega valor da acertos salva no metodo playerprefs

        // deixando as estrelas amerelas comecen off
        estrela_1.SetActive(false);
        estrela_2.SetActive(false);
        estrela_3.SetActive(false);
        // verificação de notas de estrelas com  as medias 
        if (notasfinal == 10)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(true);
            estrela_3.SetActive(true);
        }
        else if (notasfinal >= 7)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(true);
            estrela_3.SetActive(false);

        }
        else if (notasfinal >= 5)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(false);
            estrela_3.SetActive(false);

        }


        txtinfoTema.text = "Você acertou "+ acertos.ToString() +" de " + numerosquetoes.ToString() +  " questões ";
        inftema.SetActive(true);
      //  btnPlay.interactable = true;
    }

    
    public void jogar()
    {
        if(idtema >=0 )
        {
            cb.carregando("T" + idtema.ToString());
        }
     
      
    }
   
}
