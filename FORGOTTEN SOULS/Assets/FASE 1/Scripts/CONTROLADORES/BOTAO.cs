using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BOTAO : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void botao()
    {
        SceneManager.LoadScene("Menu");// carrega outra cena
    }
    public void Continuar()
    {
        SceneManager.LoadScene("JOGO EM SI");
    }
}
