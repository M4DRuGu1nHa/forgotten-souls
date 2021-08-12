using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraCamera2 : MonoBehaviour
{
    public GameObject DOIS;
    public float Zoom;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D doly)
    {
        if (doly.gameObject.CompareTag("Player"))
        {
            DOIS.GetComponent<CAMERAZOOM>().Maximo = Zoom;

        }

    }
}
