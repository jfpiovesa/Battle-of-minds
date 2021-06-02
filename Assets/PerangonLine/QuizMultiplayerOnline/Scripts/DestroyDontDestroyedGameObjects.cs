using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class DestroyDontDestroyedGameObjects : MonoBehaviour
{


    public List<string> GameobjectName;

    // Start is called before the first frame update
    void Start()
    {

        PhotonNetwork.Disconnect();

        for( int i = 0; i< GameobjectName.Count; i++ )
        {
            Destroy(GameObject.Find(GameobjectName[i]));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
