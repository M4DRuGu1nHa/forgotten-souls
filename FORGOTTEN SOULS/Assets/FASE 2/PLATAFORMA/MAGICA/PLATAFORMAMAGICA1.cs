using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATAFORMAMAGICA1 : MonoBehaviour
{
    private Animator anim;
    public GameObject Proxima;
    public float tempo;
   
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D fall)
    {

        if (fall.gameObject.CompareTag("Player"))
        {
            Invoke("Apareceu", tempo);
        }

    }   
    void Apareceu()
    {
        Proxima.SetActive(true);
    }   
}