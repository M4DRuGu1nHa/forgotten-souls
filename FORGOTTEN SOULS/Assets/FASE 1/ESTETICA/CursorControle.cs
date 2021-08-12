using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControle : MonoBehaviour
{
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
      
    }

    
    void Update()
    {
        Cursor.visible = false;
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}
