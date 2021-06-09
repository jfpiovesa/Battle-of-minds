using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    float volumenivel;
    float vlr;
    public static audioVolume au;
    public  Slider sl;
    private void Awake()
    {
        if(au ==  null)
        {
            au = this;
        }
    }
    private void Start()
    {
        vlr = PlayerPrefs.GetFloat("audiovolume", volumenivel);
        sl.value = vlr;
        volumenivel = vlr;
    }
    private void Update()
    {
    }
    public void SetVolume(float volume)
    {
        volumenivel = volume;
        audioMixer.SetFloat("volumeaudio", volumenivel);
        PlayerPrefs.SetFloat("audiovolume", volumenivel);
        sl.value = volumenivel;


    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public  void Mutar(float valor)
    {
        vlr = valor;
        volumenivel = valor;
    }
}