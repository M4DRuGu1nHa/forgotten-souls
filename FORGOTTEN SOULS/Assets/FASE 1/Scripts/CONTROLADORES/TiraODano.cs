using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraODano : MonoBehaviour
{
    public GameObject Martelo;
    public GameObject NockBack;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void ColocaDano()
    {
        Martelo.GetComponent<AreaDeAtaque>().Dano = 20;
        NockBack.GetComponent<VIDA>().ParaCima2 = 500f;
        NockBack.GetComponent<VIDA>().ParaTras2 = 100f;
        NockBack.GetComponent<VIDA>().ParaCima = 250f;
        NockBack.GetComponent<VIDA>().ParaTras = 100f;


    }

    void TiraDano()
    {
        Martelo.GetComponent<AreaDeAtaque>().Dano = 0;
        NockBack.GetComponent<VIDA>().ParaCima2 = 0f;
        NockBack.GetComponent<VIDA>().ParaTras2 = 0f;
        NockBack.GetComponent<VIDA>().ParaCima = 0f;
        NockBack.GetComponent<VIDA>().ParaTras = 0f;
    }
}
