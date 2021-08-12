using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAIO : MonoBehaviour
{
    public GameObject My;
    public Collider2D MyCol;
    public GameObject Proximo;

    public float Dano;

    public Transform myTransform;
    public Transform Novo;
    public Transform Velho;


    void Start()
    {
        
    }  
    void Update()
    {
        
    }
    void RaioFIM()
    {
        My.SetActive(false);
    }

    void DanoComeço()
    {
       MyCol.enabled = true;
    }

    void DanoFim()
    {
        MyCol.enabled = false;
    }

    void Apareceu()
    {
        Proximo.SetActive(true);
    }

    void Dont()
    {
        myTransform.parent = Novo.transform;
    }

    void Yes()
    {
        myTransform.parent = Velho.transform;
    }
}
