using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePaineis : MonoBehaviour

{
    public GameObject ControlesPainel;
    public GameObject VideoPainel;
    public GameObject SomPainel;    

    void Start()
    {
        

    }

   
    void Update()
    {
        
    }

    public void MostrarControles()
    {
        ControlesPainel.SetActive(true);
    }

    public void Voltar1()
    {
        ControlesPainel.SetActive(false);
    }

    public void MostrarSom()
    {
        VideoPainel.SetActive(true);
    }

    public void voltar2()
    {
        VideoPainel.SetActive(false);
    }

    public void MostrarVideo()
    {
        SomPainel.SetActive(true);
    }

    public void Voltar3()
    {
        SomPainel.SetActive(false);
    }


}
