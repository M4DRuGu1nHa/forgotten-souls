using System.Collections.Generic;
using UnityEngine;

public class CABEÇABOSS : MonoBehaviour
{
    public float Velocidade;
    private Transform Posicao;

    private SpriteRenderer sprite;

    private Transform target;

    private Transform Player;

    public bool Invertida;


    void Start()
    {
        Posicao = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("MAGNUS MARLEY").GetComponent<Transform>();
       
    }

    
    void Update()
    {
        if (Posicao.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Posicao.position, Velocidade * Time.deltaTime);
           
        }
        if (!Invertida)
        {
            if ((Player.position.x > transform.position.x && sprite.flipX) || Player.position.x < transform.position.x && !sprite.flipX)
            {
                Flip();
            }
        }
        if (Invertida)
        {
            if ((Player.position.x < transform.position.x && sprite.flipX) || Player.position.x > transform.position.x && !sprite.flipX)
            {
                Flip();
            }
        }
    }

    public void Flip()
    {
       sprite.flipX = !sprite.flipX; 
    }

    
}
