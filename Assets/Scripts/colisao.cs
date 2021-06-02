using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class colisao : MonoBehaviour
{
    public  UnityEvent Event;
    private Player_two pl;
    private Responder rs;
    public GameObject ps2,player;
    public GameObject pos1;
 
   // float _Time = 5.0f;
   // bool cl = false;
    //public Text _Text;
  
    private string _lentra ;
    
    private void Start()
    {
        //conometro.fillAmount = _Time;
       // ob.SetActive(false);
        pl = FindObjectOfType<Player_two>() as Player_two;

    }
    private void Update()
    {



    }
    public void Apertou()//colisão de 
    {
           
            player.transform.position = pos1.transform.position;

          // cl = true;
          //  ob.SetActive(true);
          //  Responder.responder.m_pl = false;
           // pl.Ativamove = false;                 
    }
    public  void St()
    {    
       
        player.transform.position = ps2.transform.position;       
    }
    

}
