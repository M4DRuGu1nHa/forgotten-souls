using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNDEADLORD : MonoBehaviour
{
    #region Variaveis Walk

    public Transform Esquerdo;
    public Transform Direito;
    public float MoveSpeed;
    [HideInInspector] public Transform target;

    #endregion

    #region Variaveis Ataque

    public float AttackDistance;
    public float timer;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    private float intTimer;
    private bool attackMode;
    private float distance;
    private bool cooling;

    #region Variaveis Tiro
    public GameObject Tiro;
    public Transform bulletSpawn;
    public float fireRate;
    private float nextFire;

    #endregion

    #endregion

    #region Variaveis de atalho

    private Animator anim;
    SpriteRenderer rend;

    #endregion

    void Start()
    {
        
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
        intTimer = timer;
        rend = GetComponent<SpriteRenderer>();
        SelectTarget();

    }
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideofLimits() )
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }

    #region Walk
    void Move()
    {
        anim.SetBool("WALK", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACK"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        }
    }
    private bool InsideofLimits()
    {
        return transform.position.x > Esquerdo.position.x && transform.position.x < Direito.position.x;
    }
    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, Esquerdo.position);
        float distanceToRight = Vector2.Distance(transform.position, Direito.position);

        if (distanceToLeft > distanceToRight)
        {
            target = Esquerdo;
        }
        else
        {
            target = Direito;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;

        if (transform.position.x > target.position.x)
        {
            rotation.y= 180f;
        }
        else
        {
            rotation.y= 0f;
        }

        transform.eulerAngles = rotation;

    }
    #endregion


    #region Ataque

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
            anim.SetBool("ATTACK", false);
        }
    }

    void Attack()
    {
        timer = intTimer; 
        attackMode = true;

        anim.SetBool("WALK", false);
        anim.SetBool("ATTACK", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;

        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
       
    }

    void TriggerCooling()
    {
        cooling = true;

    }

    void Atirar()
    {
       
        Tiro.SetActive(true);
        nextFire = Time.time + fireRate;

      GameObject cloneBullet = Instantiate(Tiro, bulletSpawn.position, bulletSpawn.rotation);
            
    }


    #endregion 
}
