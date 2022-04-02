using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform targetView;

    [SerializeField] float minX, maxX, minY, maxY;

    public Vector3 offset;
    private void FixedUpdate()
    {
        //Follow target's x position
        transform.position = targetView.position + offset;

        float cutoffX = Mathf.Clamp(transform.position.x, minX, maxX);
        float cutoffY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(cutoffX, cutoffY, transform.position.z) + offset;
    }
}

