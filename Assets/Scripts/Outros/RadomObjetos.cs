using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomObjetos : MonoBehaviour
{
    [SerializeField] private GameObject[] objetos;

    public void Update()
    {
        transform.position = objetos[Random.Range(0, objetos.Length)].transform.position;
    }
}
