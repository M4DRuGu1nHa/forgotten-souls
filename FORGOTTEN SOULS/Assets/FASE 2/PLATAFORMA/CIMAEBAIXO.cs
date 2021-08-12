using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIMAEBAIXO : MonoBehaviour
{
    public bool moveDown = true;

    public float velocidade = 3f;
    public Transform PontoA;
    public Transform PontoB;
   // public GameObject PLAYER;


    void Start()
    {
       
    }
    void Update()
    {
        if (transform.position.y > PontoA.position.y)
        {
            moveDown = true;
        }
        if(transform.position.y < PontoB.position.y)
        {
            moveDown = false;
        }
        if (moveDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
        void OnCollisionEnter2D(Collision2D Poly)
        {
            if (Poly.gameObject.CompareTag("Player"))
            {
               // PLAYER.GetComponent<MAGNUS>().Pulo = 2.834f;
            }

        }

    }
}
