using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDAR_ESPINHO : MonoBehaviour
{
    public Transform Esquerdo;
    public Transform Direito;
    public float MoveSpeed;
    [HideInInspector] public Transform target;
    

    void Start()
    {
        SelectTarget();
    }
    void awake()
    {
        SelectTarget();
       
    }

   
    void Update()
    {
        if (!InsideofLimits() )
        {
            SelectTarget();
        }

        Move();
    }

    void Move()
    {       
          Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
          transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        
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
    }
   
}
