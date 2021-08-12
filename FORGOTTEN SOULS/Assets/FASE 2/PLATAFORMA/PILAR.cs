using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PILAR : MonoBehaviour
{
    public float MoveSpeed;
    [HideInInspector] public Transform target;
    public float Fixa;

    public bool Up;


    void Start()
    {
       // Up = true;
    }
    void awake()
    {


    }


    void Update()
    {
        if (Up)
        {
            Cima();
        }

        if (!Up)
        {
            Baixo();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Barreria"))
        {
            //Up = false;
        }

        if (col.gameObject.CompareTag("Barreira2"))
        {
          //  Up = true;
        }
    }


    void Cima()
    {
        Vector2 targetPosition = new Vector2(Fixa, -45.5f);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
    }
    void Baixo()
    {
        Vector2 targetPosition = new Vector2(Fixa, -52.8f);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
    }
}
