using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VIDA : MonoBehaviour
{
    public float MaximoVida = 100f;
    public Image BarraDeVida;
    private float Vidinha;
   

    public float ParaCima;
    public float ParaTras;

    public float ParaCima2;
    public float ParaTras2;

    //public Rigidbody2D Rigid;


    void Start()
    {
        Vidinha = MaximoVida;
        BarraDeVida.fillAmount = Vidinha / MaximoVida;

    }

    private void OnTriggerEnter2D(Collider2D Jhin)
    {

        if (Jhin.CompareTag("WIN"))
        {
            Application.LoadLevel("GANHO");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 1f;
        }
        if (Jhin.CompareTag("Espinho"))
        {
            Vidinha -= Jhin.GetComponent<Espinho>().Dano;
            BarraDeVida.fillAmount = Vidinha / MaximoVida;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(ParaTras, ParaCima));

            if (Vidinha <= 0)
            {
                Application.LoadLevel("GAMEOVER");
            }

            if (Vidinha <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 1f;
            }
        }    

        if (Jhin.CompareTag("NOVODANO"))
        {
            Vidinha -= Jhin.GetComponent<AreaDeAtaque>().Dano;
            BarraDeVida.fillAmount = Vidinha / MaximoVida;
            TomoDano();
            

            if (Vidinha <= 0)
            {
                Application.LoadLevel("GAMEOVER");
            }

            if (Vidinha <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 1f;
            }
        }




    }

    private void OnTriggerExit2D(Collider2D Jhin)
    {
        Volto();

    }

    void TomoDano()
    {
        GetComponent<OSGORD>().Velocidade = 0f;

        if (GetComponent<OSGORD>().TaNoChao)
        {
         //   Rigid.AddForce(new Vector2(ParaTras, ParaCima));
        }

        if (GetComponent<OSGORD>().TaNoChao = false)
        {
         //   Rigid.AddForce(new Vector2(ParaTras, 0f));
        }
    }

    void Volto()
    {
        GetComponent<OSGORD>().Velocidade = 2f;       
    }
}
