using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RANGE : MonoBehaviour
{
    public GameObject PAI;

    void Awake()
    {
       
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Black)
    {
        if (Black.gameObject.CompareTag("Player"))
        {
            PAI.GetComponent<CABEÇA>().Go = true;
        }
    }

    void OnTriggerExit2D(Collider2D Black)
    {
        if (Black.gameObject.CompareTag("Player"))
        {
           PAI.GetComponent<CABEÇA>().Go = false;
        }

    }
}
