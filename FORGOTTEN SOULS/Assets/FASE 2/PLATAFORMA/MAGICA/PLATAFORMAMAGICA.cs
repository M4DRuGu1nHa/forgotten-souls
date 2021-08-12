using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATAFORMAMAGICA : MonoBehaviour
{
    private Animator anim;
    public GameObject EmSi;
    public GameObject Proxima;
    public Collider2D Chao;
    public float tempo;
    public float tempo2;
    public float tempo3;
    private float tempo4;
    void Start()
    {
        anim = GetComponent<Animator>();
        tempo4 = tempo2;
    }
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D fall)
    {
 
        if (fall.gameObject.CompareTag("Player"))
        {
            Invoke("Apareceu", tempo);
            Invoke("Sumiu", tempo2);
            Invoke("AnimacaoMorrendo", tempo3);
        }

    }
    void OnCollisionExit2D(Collision2D fall)
    {
        if (fall.gameObject.CompareTag("Player"))
        {
            Invoke("Sumiu2", tempo4);
            Invoke("AnimacaoMorrendo2", tempo3);

        }

    }

    void Sumiu()
    {     
         EmSi.SetActive(false);
    }
    void Sumiu2()
    {
        Proxima.SetActive(false);
    }
    void Apareceu()
    {
        Proxima.SetActive(true);
    }


    void FisicaSuma()
    {
        Chao.enabled = false;
    }

    void FisicaApareca()
    {
        Chao.enabled = true;
    }

    void AnimacaoMorrendo()
    {
        anim.SetTrigger("SUMA");
        
    }
    void AnimacaoMorrendo2()
    {
        Proxima.GetComponent<Animator>().SetTrigger("SUMA");
    }
}
