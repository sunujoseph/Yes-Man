using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int _healAmount;

    public GameObject _potion_HP;
    public override void PickupItem()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerControl>().StoreItem(this.gameObject);
        //Destroy(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
