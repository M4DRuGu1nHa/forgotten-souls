using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OSGORD : MonoBehaviour
{
    public bool isPaused;
    public GameObject PausePainel;
    public string cena;
    public GameObject ConfigPainel;



    public float Pulo;
    public float Velocidade;
    public bool TaNoChao;

    public Transform Pe;
    public LayerMask Chao;


    public bool TaNaParede;

    public bool TaAcesso;
    public GameObject LuzDoSol;

    public bool TaParaFrente;


    public Collider2D AreaDeAtaque;
    public Collider2D AreaDeAtaque1;

    public float CDAtaque;
    private float TempoAtaque;

    public float CDAPulo;
    private float TempoPulo;

    public GameObject cursor;



    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursor.SetActive(false);

        TempoAtaque = 0;

    }


    void Update()
    {
        Cursor.visible = false;
        if (!isPaused)
        {

            float movimento = Input.GetAxis("Horizontal");

            GetComponent<Rigidbody2D>().velocity = new Vector2(movimento * Velocidade, GetComponent<Rigidbody2D>().velocity.y);


            // if (Input.GetKeyDown(KeyCode.N))
            // {
            //     GetComponent<Rigidbody2D>().AddForce(new Vector2(Dash , 0));
            // }
            if (TempoPulo <= 0)
            {
                if (Input.GetKeyDown(KeyCode.W) && TaNoChao)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Pulo));
                    TempoPulo = CDAPulo;
                }
            }
            else
            {
                TempoPulo -= Time.deltaTime;
            }

            if (TempoAtaque <= 0)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    GetComponent<Animator>().SetTrigger("ATACK");
                    TempoAtaque = CDAtaque;
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    GetComponent<Animator>().SetTrigger("ATACK");
                    TempoAtaque = CDAtaque;
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<Animator>().SetTrigger("ATACK");
                    TempoAtaque = CDAtaque;
                }

            }
            else
            {
                TempoAtaque -= Time.deltaTime;
            }
            if (movimento < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                TaParaFrente = false;


            }
            else if (movimento > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                TaParaFrente = true;
            }

            TaNoChao = Physics2D.OverlapCircle(Pe.position, 0.3f, Chao);

            if (movimento > 0 || movimento < 0)
            {
                GetComponent<Animator>().SetBool("WALK", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("WALK", false);

            }

            if (TaNoChao)
            {
                GetComponent<Animator>().SetBool("JUMP", false);

            }
            else
            {
                GetComponent<Animator>().SetBool("JUMP", true);
            }

            if (!TaNoChao)
            {
                GetComponent<Animator>().SetBool("WALK", false);
            }
            if (TaNaParede)
            {
                GetComponent<Animator>().SetBool("PAREDE", true);
                GetComponent<Animator>().SetBool("JUMP", false);
            }
            else
            {
                GetComponent<Animator>().SetBool("PAREDE", false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseScreen();
            }
        }

        void PauseScreen()
        {

            if (isPaused)
            {
                AudioListener.pause = false;
                Time.timeScale = 1f;
                isPaused = false;
                PausePainel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                cursor.SetActive(false);

            }
            else
            {
                AudioListener.pause = true;
                Time.timeScale = 0f;
                isPaused = true;
                PausePainel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                cursor.SetActive(true);
            }
        }

        void BackToMenu()
        {
            Application.LoadLevel("Menu");
        }

        void OnCollisionEnter2D(Collision2D sett)
        {
            if (sett.gameObject.CompareTag("Paredes"))
            {

                TaNaParede = true;
                Velocidade = 0.5f;
            }
            if (sett.gameObject.CompareTag("Piso"))
            {
                Velocidade = 2;
            }


        }
        void OnCollisionExit2D(Collision2D sett)
        {
            if (sett.gameObject.CompareTag("Paredes"))
            {
                Velocidade = 2f;
                TaNaParede = false;

            }

        }

        void OnTriggerEnter2D(Collider2D jeba)
        {
            if (jeba.gameObject.CompareTag("Barreria"))
            {
                GetComponent<AudioSource>().Play();
            }

            if (jeba.gameObject.CompareTag("Barreira2"))
            {
                GetComponent<AudioSource>().Stop();
            }

            if (jeba.gameObject.CompareTag("Luz"))
            {
                LuzDoSol.SetActive(false);
            }
            if (jeba.gameObject.CompareTag("Luz2"))
            {
                LuzDoSol.SetActive(true);
            }



        }

        void VoltaOJogo()
        {
            PauseScreen();
        }

        void MostrarConfigurações()
        {
            ConfigPainel.SetActive(true);

        }

    }
    void InicioDoAtaque()
    {
        if (TaParaFrente)
        {
            AreaDeAtaque1.enabled = false;
            AreaDeAtaque.enabled = true;

        }
        else
        {
            AreaDeAtaque1.enabled = true;
            AreaDeAtaque.enabled = false;

        }

        Velocidade = 0f;
    }
    void FimDoAtaque()
    {
        AreaDeAtaque1.enabled = false;
        AreaDeAtaque.enabled = false;
        Velocidade = 2f;

    }
}