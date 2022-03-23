using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIcon : MonoBehaviour
{

    Vector2 mousPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousPos;
    }
}
