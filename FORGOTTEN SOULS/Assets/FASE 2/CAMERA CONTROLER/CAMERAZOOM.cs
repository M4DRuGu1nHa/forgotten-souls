using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERAZOOM : MonoBehaviour
{
    public bool zoomAtivado;

    public Camera Cam;

    public float Velocidade;

    public float Minimo;
    public float Maximo;

    void Start()
    {
        Cam = Camera.main;

        
    }

    public void LateUpdate()
    {
        if (zoomAtivado)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,Minimo, Velocidade);
        }

        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize,Maximo,Velocidade);
        }
    }
}
