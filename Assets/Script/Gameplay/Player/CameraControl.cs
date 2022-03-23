using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //[SerializeField] Transform target;
    //public float smoothing;
    //public Vector3 offset; 

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position + offset, smoothing);

    //    transform.position = newPos;
    //}

    public GameObject player;
    public Vector3 ofset = new Vector3(0, 0, 1);
    // Start is called before the first frame update


    // Update is called once per frame
    public void FixedUpdate()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x + ofset.x, player.transform.position.y + ofset.y, player.transform.position.z + ofset.z);
        }
    }
}

