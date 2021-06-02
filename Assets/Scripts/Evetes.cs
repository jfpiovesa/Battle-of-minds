using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Evetes : MonoBehaviour
{

    public UnityEvent evente;

    public void evento()
    {
        evente.Invoke();
    }
}
