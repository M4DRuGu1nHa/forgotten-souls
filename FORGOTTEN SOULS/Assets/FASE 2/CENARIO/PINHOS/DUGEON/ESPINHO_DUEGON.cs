using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESPINHO_DUEGON : MonoBehaviour
{
    public bool Ativador;
    public GameObject Proximo;
    void Start()
    {
    }

    void Update()
    {
        if (Ativador)
        {
            GetComponent<Animator>().SetBool("SUBIU", true);
        }

    }

    void Desceu()
    {
        GetComponent<Animator>().SetBool("SUBIU", false);
        Proximo.GetComponent<ESPINHO_DUEGON>().  Ativador = true;
        Ativador = false;
    }
}
