using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finnish : MonoBehaviour
{
    
  
    public string nome_cenas; // para carregar a cena mais com opção de  por o nome 
  
    public Text timerText; // ui de texto na unity
    private float startTime; // tempo  de inicio com time
    public float valor = 0;// valor para verificação
  
    void Start()
    {
        startTime = Time.time;
    }

    
    void Update()
    {
        
        

        float t = Time.time - startTime;
        // transformando em conometro
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
        // verificação de ficou 0
        if(t >= valor )
        {
            SceneManager.LoadScene(nome_cenas);
        }

    }


}
