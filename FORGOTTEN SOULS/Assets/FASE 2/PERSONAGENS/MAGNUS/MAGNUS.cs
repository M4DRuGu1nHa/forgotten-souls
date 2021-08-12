using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAGNUS : MonoBehaviour
{
    #region Variaveis da Vida
    public float Vida;
    private bool Imortal;
    #endregion

    #region Variaveis do Dash
    private float dashAtual;
    private bool canDash;
    private bool inDash;
    public float duracaoDash;
    public float dashSpeed;
    public float colDash;
    #endregion

    private bool isPaused;
    public GameObject pausePanel;
    public string cena;
    public GameObject pausePanel2;
    public GameObject pauseVideo;
    public GameObject pauseSom;
    public GameObject pauseControles;


    public Rigidbody2D playerBody;
    public float Velocidade;
    public float Pulo;
    public bool TaParaFrente;

    public Transform myTransform;

    [Header("BOSS")]
    public GameObject CameraBoss;
    public GameObject Boss;
    public GameObject VidaBoss;

    




    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myTransform = transform;
        Time.timeScale = 1f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
        if (!isPaused)
        {
            float movimento = Input.GetAxis("Horizontal");

            GetComponent<Rigidbody2D>().velocity = new Vector2(movimento * Velocidade, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKeyDown(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Pulo));
            }

            if (Vida <= 0)
            {
                Application.LoadLevel("GAMEOVER");
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

            if (movimento > 0 || movimento < 0)
            {
                GetComponent<Animator>().SetBool("WALK", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("WALK", false);
            }



        } 
    }
    void PauseScreen() {
        if (isPaused)
        {
        isPaused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pausePanel.SetActive(false);
            pausePanel2.SetActive(false);
            pauseVideo.SetActive(false);
            pauseSom.SetActive(false);
            pauseControles.SetActive(false);
        }
        else 
        {
            isPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pausePanel.SetActive(true);
        }

    }
    public void SairDoJogo() {
        SceneManager.LoadScene(cena);
    }
    public void VoltarAoJogo() {
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }
    public void configuracoes() {
        pausePanel.SetActive(false);
        pausePanel2.SetActive(true);
    }
    public void video()
    {
        pausePanel2.SetActive(false);
        pauseVideo.SetActive(true);
    }
    public void Som()
    {
        pausePanel2.SetActive(false);
        pauseSom.SetActive(true);
    }
    public void Controles()
    {
        pausePanel2.SetActive(false);
        pauseControles.SetActive(true);
    }
    public void voltar() {
        pausePanel.SetActive(true);
        pausePanel2.SetActive(false);
    }
    public void voltar2() {
        pausePanel2.SetActive(true);
        pauseVideo.SetActive(false);
        pauseSom.SetActive(false);
        pauseControles.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D Bad)
    {
        Debug.Log("CHAMA " + gameObject.name);

        if (!Imortal)
        {
            if (Bad.CompareTag("Espinho"))
            {
                Vida -= Bad.GetComponent<MAGIA>().Dano;
                MudaCor();
            }
            if (Bad.CompareTag("GOTA"))
            {
                Vida -= Bad.GetComponent<GOTA>().Dano;
                MudaCor();
            }
            if (Bad.CompareTag("ATTACK1"))
            {
                Vida -= Bad.GetComponent<Espinho>().Dano;
                MudaCor();
            }
            if (Bad.CompareTag("RAIO"))
            {
                Vida -= Bad.GetComponent<RAIO>().Dano;
                MudaCor();
            }
        }

        if (Bad.CompareTag("Limite"))
        {
            CameraBoss.GetComponent<CAMERABOSS>().venha = true;
             Boss.GetComponent<BOSS>().BORA = true;
             VidaBoss.SetActive(true);
        }
           
    }

    void OnCollisionEnter2D(Collision2D xanbis)
    {
        if (xanbis.transform.tag == "Chao")
        {
            myTransform.parent = xanbis.transform;
        }

    }
    void OnCollisionExit2D(Collision2D xanbis)
    {
        if (xanbis.gameObject.tag.Equals("Chao"))
        {
            this.transform.parent = null;
            Velocidade = 10;
        }


    }

   

    void MudaCor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        Invoke("NormalizaCor", 0.5f);
    }

    void NormalizaCor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(dashAtual<= 0)
            {
                StopDash();
            }
        }

        else
        {
            inDash = true;
            dashAtual -= Time.deltaTime;

            if (TaParaFrente)
            {
                playerBody.velocity = Vector2.right * dashSpeed;
            }
            else
            {
                playerBody.velocity = Vector2.left * dashSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            inDash = false;
            canDash = true;
            dashAtual = duracaoDash;
        }
    }

    void StopDash()
    {
        playerBody.velocity = Vector2.zero;
        dashAtual = duracaoDash;
        inDash = false;
        canDash = true;
    }
    
}
