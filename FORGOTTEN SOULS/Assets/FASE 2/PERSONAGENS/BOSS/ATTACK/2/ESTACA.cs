using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTACA : MonoBehaviour
{
    public float velocidade;
    private float timeDestroy;
    public float tempo;

    public float Dano;
    void Start()
    {
        timeDestroy = tempo;
        Destroy(gameObject, timeDestroy);
    }


    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Barreria"))
        {
            // Debug.Log("CHAMA " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
