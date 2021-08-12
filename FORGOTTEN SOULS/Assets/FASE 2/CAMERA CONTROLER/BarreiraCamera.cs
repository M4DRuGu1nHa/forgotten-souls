using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraCamera : MonoBehaviour
{
    public GameObject UM;

    void Awake()
    { 
      
    } 


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D dale)
    {
        if (dale.gameObject.CompareTag("Player"))
        {
            UM.GetComponent<CAMERAZOOM>().zoomAtivado = true;
        }   

    }

    void OnTriggerExit2D(Collider2D dale)
    {
        if (dale.gameObject.CompareTag("Player"))
        {
            UM.GetComponent<CAMERAZOOM>().zoomAtivado = false;

        }
    }

}
