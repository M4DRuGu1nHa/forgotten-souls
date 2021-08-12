using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLATAFORMA_VERMELHA : MonoBehaviour
{
    private Animator anim;
    public float tempo;
    public float tempo2;
    public GameObject EmSi;
    public Collider2D Chao;
    public bool TaMorto;
    void Start()
    {
        anim = GetComponent<Animator>();
        TaMorto = false;
    }

    void Update()
    {
        if (TaMorto)
        {
            Invoke("Voltou", tempo2);
        }
    }

    void OnCollisionEnter2D(Collision2D fall)
    {
        if (fall.gameObject.CompareTag("Player"))
        {       
            Invoke("Tremeu", tempo);
        }

    }

    void Tremeu()
    {
        anim.SetTrigger("TREMENDO");
    }

    void Quebrou()
    {
        anim.SetTrigger("QUEBRANDO");
        TaMorto = true;
    }

    void Sumiu()
    {
        EmSi.SetActive(false);
    }
    void SumiuCol()
    {
        Chao.enabled = false;
    }
    void Voltou()
    {    
        EmSi.SetActive(true);
    }
    void VoltouCol()
    {
        Chao.enabled = true;
    }
}
