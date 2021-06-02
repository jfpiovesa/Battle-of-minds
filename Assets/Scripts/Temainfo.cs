using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temainfo : MonoBehaviour
{
    public int           idtema;//id do tema que esta 

    public GameObject    estrela_1;// para potuação em estrelas
    public GameObject    estrela_2;// para potuação em estrelas
    public GameObject    estrela_3;// para potuação em estrelas


    public int            notafinal; // variavel nota final
   
    void Start()
    {  
         // deixando as estrelas amerelas comecen off
        estrela_1.SetActive(false);
        estrela_2.SetActive(false);
        estrela_3.SetActive(false);

            
       int notaf = PlayerPrefs.GetInt("Nota" + idtema.ToString());// pega valor da nota salva no metodo playerprefs
      

      
     

        // verificação de notas de estrelas com  as medias 
        if (notaf == 10)
        {
            estrela_1.SetActive(true);
            estrela_2.SetActive(true);
            estrela_3.SetActive(true);
        }
        else if (notaf >= 7)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
