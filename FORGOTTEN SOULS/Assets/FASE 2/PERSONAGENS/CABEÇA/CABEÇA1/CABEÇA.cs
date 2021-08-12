using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CABEÇA : MonoBehaviour
{
    public float Velocidade;
    private Transform Posicao;
    public bool Go;

    private SpriteRenderer sprite;
    private Transform target;
    private Transform Player;

    void Start()
    {
        Posicao = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("MAGNUS MARLEY").GetComponent<Transform>();
    }

    void Update()
    {
        if (Go)
        {
            VAI();
        }
        if ((Player.position.x > transform.position.x && sprite.flipX) || Player.position.x < transform.position.x && !sprite.flipX)
        {
            Flip();
        }
    }

    public void Flip()
    {
        sprite.flipX = !sprite.flipX;  
    }


     void OntriggerEnter2D(Collider2D Fate)
    {
        
    }
    
    void VAI()
    {
        if (Go)
        {
            if (Posicao.gameObject != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, Posicao.position, Velocidade * Time.deltaTime);
            }
        }
    } 
}
