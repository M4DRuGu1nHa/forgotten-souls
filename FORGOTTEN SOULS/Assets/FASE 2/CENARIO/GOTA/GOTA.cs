using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOTA : MonoBehaviour
{
   
    private float timeDestroy;
    public float tempo;

    public float Dano;
    void Start()
    {
      //  timeDestroy = tempo;
     //   Destroy(gameObject, timeDestroy);
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Barreria"))
        {
           
            Destroy(gameObject);
        }
    }
}
