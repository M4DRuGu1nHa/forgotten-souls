using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Controlador_Barreira : MonoBehaviour
{

    public GameObject ObjetoDesativado;
    public GameObject ObjetoDesativado2;
    public GameObject ObjetoAtivado;
    public GameObject ObjetoAtivado2;


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Vaza)
    {
        if (Vaza.CompareTag("Player"))
        {
            ObjetoDesativado.SetActive(false);
           
        }
        if (Vaza.CompareTag("Player"))
        {
            ObjetoDesativado2.SetActive(false);
        }
        if (Vaza.CompareTag("Player"))
        {
            ObjetoAtivado.SetActive(true);
        }
        if (Vaza.CompareTag("Player"))
        {
            ObjetoAtivado2.SetActive(true);
        }
    }
}
