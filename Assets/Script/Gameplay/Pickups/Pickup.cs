using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    //Pickup delay time
    public float _waitToPickup = .5f;


    // Update is called once per frame
    void Update()
    {
        
        if (_waitToPickup > 0)
        {
            _waitToPickup -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _waitToPickup <= 0)
        {
            PickupItem();
        }
    }
    public abstract void PickupItem();
}
