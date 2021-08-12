using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTAODUGE : MonoBehaviour
{
    public bool UM;
    public bool DOIS;
    public bool TRES;
    public bool QUATRO;
    public bool CINCO;
    public bool SEIS;
    public bool SETE;

    public GameObject Pilar1;
    public GameObject Pilar2;
    public GameObject Pilar3;
    public GameObject Pilar4;

    public int Sequencia;


    void Start()
    {
        Sequencia = 1;
    }

    void Update()
    {
        if (UM)
        {
            Sequencia = 2;
        }

        if (DOIS)
        {
            Sequencia = 3;
        }

        if (TRES)
        {
            Sequencia = 4;
        }
        if (QUATRO)
        {
            Sequencia = 5;
        }
        if (CINCO)
        {
            Sequencia = 6;
        }
        if (SEIS)
        {
            Sequencia = 7;
        }
        if (SETE)
        {
            Sequencia = 8;
        }

        if (Sequencia == 1)
        {
            SETE = false;
            Pilar1.GetComponent<PILAR>().Up = false;
            Pilar2.GetComponent<PILAR>().Up = false;
            Pilar3.GetComponent<PILAR>().Up = false;
            Pilar4.GetComponent<PILAR>().Up = false;
        }
        if (Sequencia == 2)
        {
            Pilar1.GetComponent<PILAR>().Up = false;
            Pilar2.GetComponent<PILAR>().Up = true;
            Pilar3.GetComponent<PILAR>().Up = true;
            Pilar4.GetComponent<PILAR>().Up = false;
        }
        if (Sequencia == 3)
        {
            Pilar1.GetComponent<PILAR>().Up = false;
            Pilar2.GetComponent<PILAR>().Up = false;
            Pilar3.GetComponent<PILAR>().Up = true;
            Pilar4.GetComponent<PILAR>().Up = true;
        }
        if (Sequencia == 4)
        {
            Pilar1.GetComponent<PILAR>().Up = true;
            Pilar2.GetComponent<PILAR>().Up = true;
            Pilar3.GetComponent<PILAR>().Up = false;
            Pilar4.GetComponent<PILAR>().Up = true;
        }
        if (Sequencia == 5)
        {
            Pilar1.GetComponent<PILAR>().Up = true;
            Pilar2.GetComponent<PILAR>().Up = false;
            Pilar3.GetComponent<PILAR>().Up = false;
            Pilar4.GetComponent<PILAR>().Up = true;
        }
        if (Sequencia == 6)
        {
            Pilar1.GetComponent<PILAR>().Up = false;
            Pilar2.GetComponent<PILAR>().Up = true;
            Pilar3.GetComponent<PILAR>().Up = false;
            Pilar4.GetComponent<PILAR>().Up = true;
        }
        if (Sequencia == 7)
        {
            Pilar1.GetComponent<PILAR>().Up = true;
            Pilar2.GetComponent<PILAR>().Up = true;
            Pilar3.GetComponent<PILAR>().Up = true;
            Pilar4.GetComponent<PILAR>().Up = true;
        }
        if (Sequencia == 8)
        {
            Sequencia = 1;
            SETE = false;
            UM = false;
            DOIS = false;
            TRES = false;
            QUATRO = false;
            CINCO = false;
            SEIS = false;
            Pilar1.GetComponent<PILAR>().Up = false;
            Pilar2.GetComponent<PILAR>().Up = false;
            Pilar3.GetComponent<PILAR>().Up = false;
            Pilar4.GetComponent<PILAR>().Up = false;
        }

    }
    void OnCollisionEnter2D(Collision2D Poly)
    {
        if (Poly.gameObject.CompareTag("Player"))
        {
            UM = true;
            GetComponent<Animator>().SetBool("BAIXO", true);
            if (UM && Sequencia == 2)
            {

                DOIS = true;
            }

            if (DOIS && Sequencia == 3)
            {

                TRES = true;
            }

            if (TRES && Sequencia == 4)
            {

                QUATRO = true;
            }

            if (QUATRO && Sequencia == 5)
            {
                CINCO = true;
            }
            if (CINCO && Sequencia == 6)
            {
                SEIS = true;
            }
            if (SEIS && Sequencia == 7)
            {
                SETE = true;
            }

        }

    }

    void OnCollisionExit2D(Collision2D Poly)
    {
        if (Poly.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("BAIXO", false);
        }
    }
}