using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class METRALHATEMPO : MonoBehaviour
{
    public GameObject Tiro;
    public Transform bulletSpawn;

    public bool PodeAtirar;

    public float tempo;

    void Start()
    {
        Invoke("Vai", tempo);
    }


    void Update()
    {
        if (PodeAtirar)
        {
            GetComponent<Animator>().SetBool("ATTACK", true);
            GetComponent<Animator>().SetBool("IDLE", false);
        }

        if (!PodeAtirar)
        {
            Invoke("Vai", tempo);
            GetComponent<Animator>().SetBool("ATTACK", false);
            GetComponent<Animator>().SetBool("IDLE", true);
        }




    }

    void Atirar()
    {
        GameObject cloneBullet = Instantiate(Tiro, bulletSpawn.position, bulletSpawn.rotation);

    }

    void Vai()
    {
        PodeAtirar = true;
        Invoke("Para", tempo);
    }

    void Para()
    {
        PodeAtirar = false;
    }

}
