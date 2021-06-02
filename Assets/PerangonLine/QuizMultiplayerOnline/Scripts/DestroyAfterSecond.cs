using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSecond : MonoBehaviour
{

    public float SecondToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.gameObject, SecondToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
