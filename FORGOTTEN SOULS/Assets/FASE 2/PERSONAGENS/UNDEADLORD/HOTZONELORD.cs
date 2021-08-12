using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOTZONELORD : MonoBehaviour
{
    private UNDEADLORD enemyParent;
    private bool inRange;
    private Animator anim;
    public GameObject Individuo;

    private void Awake()
    {
        enemyParent = GetComponentInParent<UNDEADLORD>();
        anim = Individuo.GetComponent<Animator>();

    }

    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACK")) ;
        {
            enemyParent.Flip();
        }
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
            anim.SetBool("ATTACK", false);
            
        }
    }
}
