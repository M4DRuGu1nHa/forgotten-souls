using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOTA_SPAW : MonoBehaviour
{
    public GameObject Tiro;
    public Transform bulletSpawn;
    

    public bool Vai; 

    void Start()
    {
        
    }

  
    void Update()
    {
       // Invoke("Atirar", tempo);
    }


    void Atirar()
    {
        GameObject cloneBullet = Instantiate(Tiro, bulletSpawn.position, bulletSpawn.rotation);

    }
}
