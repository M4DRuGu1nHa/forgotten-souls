using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public float Velocidade;
    public float Stop;
    private Transform Posicao;
    public bool BORA;
    [HideInInspector] public Transform target;
    public bool Frente;

    [Header("Ataques")]
    public bool Atacando;
    public bool Atacando2;
    public bool Atacando3;
    public bool Atacando4;

    [Header("Tipo de ataques")]
    public GameObject Espada;
    public GameObject RAIO;
    public GameObject Tiro;
    public Transform bulletSpawn;
    public GameObject Cabeça1;
    public GameObject Cabeça2;
    public GameObject Cabeça3;
    public GameObject Cabeça4;
    public GameObject Cabeça1I;
    public GameObject Cabeça2I;
    public GameObject Cabeça3I;
    public GameObject Cabeça4I;
    public Transform headSpawn;

    private Animator anim;
    SpriteRenderer rend;

    private float minValor = 0;
    private float maxValor = 4;
    public float resultado;

    private float minValorC = 0;
    private float maxValorC = 5;
    private float resultadoC;



    void Start()
    {
        Posicao = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        target = GetComponent<Transform>();
        //resultado = Random.Range(minValor, maxValor);

        // BORA = true;
        // Atacando4 = true;
        
    }

    
    void Update()
    {

        if (resultado <= 1 && resultado >= 0)
        {
            Atacando = true;
        }
        if (resultado <= 2 && resultado >= 1)
        {
            Atacando2 = true;
        }
        if (resultado <= 3 && resultado >= 2)
        {
            Atacando3 = true;
        }
        if (resultado <= 4 && resultado >= 3)
        {
            Atacando4 = true;
        }
        if (BORA)
        {
            Bora();
        }

       if (Vector2.Distance(transform.position, Posicao.position) < Stop)
        {
            Atacando = true;
            one();
        }

        if (Atacando2)
        {
            Atacando = false;
            anim.SetBool("ATTACK1", false);
            twu();
        }
        if (Atacando3)
        {
            Atacando = false;
            anim.SetBool("ATTACK1", false);
            tree();
        }
        if (Atacando4)
        {
            Atacando = false;
            anim.SetBool("ATTACK1", false);
            four();
        }

        if ((Posicao.position.x > transform.position.x) || Posicao.position.x < transform.position.x)
        {
            Flip();          
        }
       
    }


    void one()//melle
    {
        anim.SetBool("ATTACK1", true);
        BORA = false;
        Velocidade = 0f;
    }

    void twu()//range
    {
        anim.SetBool("ATTACK2", true);
        Velocidade = 0f;
    }

    void tree()//cabeca
    {

        anim.SetBool("ATTACK3", true);
        Velocidade = 0f;
    }

    void four()//raio
    {
        anim.SetBool("ATTACK4", true);
        BORA = false;
        Velocidade = 0f;
    }

    private void Bora()
    {
        anim.SetBool("WALK", true);
        if (Vector2.Distance(transform.position, Posicao.position) >= Stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, Posicao.position, Velocidade * Time.deltaTime);
        }
    }

    void Anda()
    {
        anim.SetBool("ATTACK1", false);
        anim.SetBool("ATTACK2", false);
        anim.SetBool("ATTACK3", false);
        anim.SetBool("ATTACK4", false);
        Atacando = false;
        Atacando2 = false;
        Atacando3 = false;
        Atacando4 = false;
        BORA = true;
        Velocidade = 7;
        resultado = Random.Range(minValor, maxValor);
    }

  

    void Atirar()
    {
        GameObject cloneBullet = Instantiate(Tiro, bulletSpawn.position, bulletSpawn.rotation);
    }

    void HitBox()
    {
        Espada.SetActive(true);
    }
    void HitBoxFim()
    {
        Espada.SetActive(false);
    }
    void Raio()
    {
        RAIO.SetActive(true);

    }
    void RoletaC()
    {
        resultadoC = Random.Range(minValorC, maxValorC);
    }
    void Nascer()
    {
        if (!Frente)
        {
            if (resultadoC <= 1 && resultadoC >= 0)
            {
                GameObject cloneHead = Instantiate(Cabeça1I, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 2 && resultadoC >= 1)
            {
                GameObject cloneHead = Instantiate(Cabeça2I, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 3 && resultadoC >= 2)
            {
                GameObject cloneHead = Instantiate(Cabeça3I, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 5 && resultadoC >= 3)
            {
                GameObject cloneHead = Instantiate(Cabeça4I, headSpawn.position, headSpawn.rotation);
            }

        }
        else
        {
            if (resultadoC <= 1 && resultadoC >= 0)
            {
                GameObject cloneHead = Instantiate(Cabeça1, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 2 && resultadoC >= 1)
            {
                GameObject cloneHead = Instantiate(Cabeça2, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 3 && resultadoC >= 2)
            {
                GameObject cloneHead = Instantiate(Cabeça3, headSpawn.position, headSpawn.rotation);
            }
            if (resultadoC <= 5 && resultadoC >= 3)
            {
                GameObject cloneHead = Instantiate(Cabeça4, headSpawn.position, headSpawn.rotation);
            }

        }
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;

        if (Posicao.position.x > target.position.x)
        {
            rotation.y = 180f;
            Frente = false;
        }
        else
        {
            rotation.y = 0f;
            Frente = true;
        }

        transform.eulerAngles = rotation;
    }
}
