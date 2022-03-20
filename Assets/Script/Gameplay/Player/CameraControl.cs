using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform target;
    public float smoothing;
    public Vector3 offset; 

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position + offset, smoothing);

        transform.position = newPos;
    }
}
