using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAVES : MonoBehaviour
{
    public GameObject Botao;
    public GameObject EmSi;

    public GameObject Pilar5;

    public float tempo;

    void Start()
    {

    }


    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D Poly)
    {
        if (Poly.gameObject.CompareTag("Player"))
        {
            EmSi.SetActive(false);
            Invoke("Cair", tempo);
        }
    }

    void Cair()
    {
        Botao.GetComponent<BOTAODUGE>().SETE = true;
        Pilar5.GetComponent<PILAR>().Up = false;
    }
}
