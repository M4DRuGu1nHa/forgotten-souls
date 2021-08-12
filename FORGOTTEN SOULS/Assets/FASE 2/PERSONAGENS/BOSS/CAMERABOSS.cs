using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERABOSS : MonoBehaviour
{
    public Transform TransformCam;
    public Transform Camera;

    public bool venha;

    private float tempo;

    public float MoveSpeed;
    [HideInInspector] public Transform target;

    public GameObject DOIS;
    public float Zoom;

    void Start()
    {
        //TransformCam = transform;
        tempo = 1f;
    }

   
    void Update()
    {
        if (venha)
        {
            ZOOM();
        }
    }

    void ZOOM()
    {
        TransformCam.parent = Camera.transform;
        Vector2 targetPosition = new Vector2(472f, -158.6f);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
        Invoke("Tempo", tempo);
    }

    void Tempo()
    {
        DOIS.GetComponent<CAMERAZOOM>().Maximo = Zoom;
    }
}
