using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class _comandosBasicos : MonoBehaviour
{
    public Animator fad;
    
    public string nomeCena;
  
    
  
 
    public void carregando(string cena)// metodo para carregar cena 
    {
    
        nomeCena = cena;
        fad.GetComponent<Animator>().SetBool("Verdadeiro", true);
        StartCoroutine(TimeCena());
       
    }

    public void resetpontuacao()// metodo para zera os prefabs
    {
        PlayerPrefs.DeleteAll();
    }
    public void OnApplicationQuit()// metodo para sair 
    {
        Application.Quit();
    }

    IEnumerator TimeCena()
    {

        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadSceneAsync(nomeCena);
      
    }
    public void MenuTImeOn( GameObject menu)
    {
        bool ativomeunu = false;
        if (!ativomeunu)
        {
            menu.gameObject.SetActive(true); 
        }
        else
        {
            menu.gameObject.SetActive(false);

        }

    }
  
   

}
