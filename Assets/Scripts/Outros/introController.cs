using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class introController : MonoBehaviour
{
    public static long sessao;

    public GameObject cameraIntro;
    public GameObject cameraGame;

    public GameObject[] outros;

    private void Start()
    {
        if (sessao == 10)
        {
            //Destroy(this.gameObject);
            cameraIntro.SetActive(false);
            cameraGame.SetActive(true);

            foreach (GameObject i in outros){
                i.SetActive(true);
            }
        }
        else
        {
            sessao = AnalyticsSessionInfo.sessionId;
        }
        Debug.Log("Sessão: " + sessao);

    }
}
