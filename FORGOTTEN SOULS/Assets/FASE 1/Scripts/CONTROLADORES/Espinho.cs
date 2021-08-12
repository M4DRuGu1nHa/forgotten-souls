using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public int Dano;
    public bool IDLE;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (IDLE)
        {
            GetComponent<Animator>().SetTrigger("IDLE");
        }
    }

    
}
