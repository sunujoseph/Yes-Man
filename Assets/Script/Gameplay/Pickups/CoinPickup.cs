using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    public int goldValue = 1;
    public override void PickupItem()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().AddGold(goldValue);
        Destroy(this.gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
