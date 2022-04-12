using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform targetView;

    public float speed = 10f;
    
    private void FixedUpdate()
    {
        //Follow target's x position
        Vector3 newPos = new Vector3(targetView.position.x, targetView.position.y, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, speed * Time.deltaTime);
    }
}

