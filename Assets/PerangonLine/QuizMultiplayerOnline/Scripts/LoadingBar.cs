using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(Image))]


public class LoadingBar : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = this.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;

    }
}
