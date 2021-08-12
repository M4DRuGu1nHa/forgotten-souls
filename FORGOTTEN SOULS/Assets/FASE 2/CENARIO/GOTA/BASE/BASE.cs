using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASE : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("GOTA"))
        {
            GetComponent<Animator>().SetTrigger("FALL");
        }
    }
}
