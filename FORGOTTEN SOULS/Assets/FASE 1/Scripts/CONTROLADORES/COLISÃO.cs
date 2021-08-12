using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLISÃO : MonoBehaviour
{
    public Collider2D outro;  
    
    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), outro, true);

    }

    
}
