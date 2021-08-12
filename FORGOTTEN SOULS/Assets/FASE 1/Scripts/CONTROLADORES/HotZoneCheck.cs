using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Comportamento_Shinba enemyParent;
    private bool inRange;
    private Animator anim;
    public GameObject Shinbs;
    public Collider2D ataque;
    public Collider2D ataque2;
    public GameObject explosao;
    public GameObject explosao2;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Comportamento_Shinba>();
        anim = Shinbs.GetComponent<Animator>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ataque, true);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ataque2, true);
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("ATACK"))
        {
            enemyParent.Flip();
        }
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ataque, true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }

    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
            anim.SetBool("ATACK", false);          
            explosao.SetActive(false);
            explosao2.SetActive(false);
            
        }
    }

}
