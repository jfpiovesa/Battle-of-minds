using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class introEvent : MonoBehaviour
{
    public static long sessao;
    private void Start()
    {
        if (sessao == 10)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sessao = AnalyticsSessionInfo.sessionId;
        }
        Debug.Log("Sessão: " + sessao);
        
    }
    public void exitIntro()
    {
        Destroy(this.gameObject);
        sessao = 10;
    }
}
