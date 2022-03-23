using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIcon : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 _focusPoint = Vector2.zero;
    

    

    Vector2 mousPos;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(cursorTexture, _focusPoint, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousPos;
    }
}
