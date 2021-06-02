using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource audio_so;
 

    // Start is called before the first frame update
    void Start()
    {
        audio_so = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
  

    public void playaudios(int valor)
    {
        audio_so.PlayOneShot(audios[valor]);

    }
}
