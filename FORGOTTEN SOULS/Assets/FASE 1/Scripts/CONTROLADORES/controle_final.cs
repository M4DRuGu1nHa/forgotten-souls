using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class controle_final : MonoBehaviour
{
    public GameObject Aparecer;
    public GameObject Tchau;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Bruxão)
    {
        if (Bruxão.CompareTag("FIMDOFIM"))
        {
            Aparecer.SetActive(true);
            Tchau.SetActive(false);
            
        }

    }
}
