using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _comandosBasicos : MonoBehaviour
{
    public Animator fad;
    
    public string nomeCena;
    public AudioMixer _audioMixer;
    public Slider audioVolume;
    private float audiValor ;
    public void Start()
    {
       
        _audioMixer = FindObjectOfType<AudioMixer>() as AudioMixer ;
    }
    private void Update()
    {
        // audiValor = audioVolume.value ;
        //_audioMixer.GetFloat(name, out audiValor);
       
    }
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

        yield return new WaitForSeconds(0.6f);
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
