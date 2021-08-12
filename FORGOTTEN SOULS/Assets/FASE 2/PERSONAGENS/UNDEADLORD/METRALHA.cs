using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class METRALHA : MonoBehaviour
{
    public GameObject Tiro;
    public Transform bulletSpawn;
    void Start()
    {
        GetComponent<Animator>().SetBool("ATTACK", true);
    }  
    void Update()
    {             
    }
    void Atirar()
    {
        GameObject cloneBullet = Instantiate(Tiro, bulletSpawn.position, bulletSpawn.rotation);
    }
}
