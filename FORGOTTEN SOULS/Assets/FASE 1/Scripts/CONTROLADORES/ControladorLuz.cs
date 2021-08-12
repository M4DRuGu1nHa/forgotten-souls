using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorLuz : MonoBehaviour
{
    public Light Light;
    private float Intencidade = 1f;
    void Start()
    {
        Light = GetComponent<Light>();
    }

    
    void Update()
    {
        Light.intensity = Intencidade;
    }

    public void Gama(float luz)
    {
        Intencidade = luz;
    }
}
