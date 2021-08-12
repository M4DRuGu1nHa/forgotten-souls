using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public GameObject ConfiguraçõesPainel;
    
   
    public void StartGame() 
    {
        SceneManager.LoadScene(cena);
    
    }




    public void QuitGame() 
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ShowOptions() 
    {
        ConfiguraçõesPainel.SetActive(true);

    }

    public void BackToMenu() 
    {
        ConfiguraçõesPainel.SetActive(false);
    }

}
