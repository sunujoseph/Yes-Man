using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Pickup
{
    public int _goldValue;
    public override void PickupItem()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerControl>().AddGold(_goldValue);
        //Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
