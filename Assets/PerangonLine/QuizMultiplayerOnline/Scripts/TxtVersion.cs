using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtVersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Ver " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
