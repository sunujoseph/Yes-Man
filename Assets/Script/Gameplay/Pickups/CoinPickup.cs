using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    public int goldValue = 1;
    int startingGoldValue;
    public override void PickupItem()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().AddGold(goldValue);
        Destroy(this.gameObject);
    }

    //Powerup
    public void IncreaseGoldValue(int goldValueMultiplier)
    {
        goldValue = startingGoldValue * goldValueMultiplier;
    }
    public void RevertGoldValue()
    {
        goldValue = startingGoldValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
