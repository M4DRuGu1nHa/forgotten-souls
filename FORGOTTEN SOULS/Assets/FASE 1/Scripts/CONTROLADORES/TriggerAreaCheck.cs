using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private Comportamento_Shinba enemyParent;
    public Collider2D ataque;
  

    private void Awake()
    {
        enemyParent = GetComponentInParent<Comportamento_Shinba>();
        
    }

    void Update()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ataque, true);
        

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
