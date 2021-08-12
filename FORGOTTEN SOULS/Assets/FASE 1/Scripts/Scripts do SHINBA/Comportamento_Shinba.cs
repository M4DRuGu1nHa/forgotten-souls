using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamento_Shinba : MonoBehaviour
{
    #region Variaveis Publicas
    public float AttackDistance; //minima distancia
    public float MoveSpeed;
    public float timer; //Cd do ataque
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; // ve se o objeto ta no range
    public GameObject hotZone;
    public GameObject triggerArea ;
    public GameObject explosao;
    public GameObject explosao2;
    #endregion

    #region Variaveis Privadas
    private Animator anim;
    private float distance; // calcula a distancia entre o player e o inimigo
    private bool attackMode; 
    private bool cooling; // ve se o inimigo ta descansando
    private float intTimer;
    #endregion

    #region Variaveis De Vida
    public float vida;
    public float ParaCima;
    public float ParaTras;
    public Collider2D corpo;
    public GameObject Espada;
    public GameObject DontVirar;
    SpriteRenderer rend;

    public float TempoMorte;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("ATACK")) 
        {
            SelectTarget();
        }  
        if(inRange)
        {    
            EnemyLogic();
        }
        if (vida <= 0)
        {
            Morreu();
            anim.SetBool("MORTE", true);
            Invoke("desaparece", TempoMorte);
        }

    }

    public void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.CompareTag("ATAQUE"))
        {
           vida -= trig.GetComponent<AreaDeAtaque>().Dano;
           GetComponent<Rigidbody2D>().AddForce(new Vector2(ParaTras, ParaCima));
           MudaCor();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > AttackDistance)
        {
            
            StopAttack();
        }
        else if (AttackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("ATACK", false);
        }
    }

    void Move()
    {
        anim.SetBool("WALK", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("ATACK"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; // reseta o tempo quando o player entra dentro
        attackMode = true; // checa se o inimigo ta ou nao no modo ataque

        anim.SetBool("WALK", false);
        anim.SetBool("ATACK", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <=0  && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;

        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        //anim.SetBool("ATACK", false);
    }    

    void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;

        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    void MudaCor()
    {
        rend.color = Color.red;

        Invoke("NormalizaCor", 0.5f);
    }

    void NormalizaCor()
    {
        rend.color = Color.white;
    }

    void Explosao()
    {
        explosao.SetActive(true);
        explosao2.SetActive(true);
    }
    void FimExplosao()
    {
        explosao.SetActive(false);
        explosao2.SetActive(false);
    }

    void FimExplosao2()
    {
        explosao.SetActive(false);
    }

    void desaparece()
    {
        Destroy(gameObject);
    }

    void Morreu()
    {
        MoveSpeed = 0f;
        anim.SetBool("ATACK", false);
        anim.SetBool("WALK", false);
        Espada.SetActive(false);
        DontVirar.SetActive(false);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), corpo, true);
    }
}

