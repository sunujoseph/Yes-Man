using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float _healAmount = 5.0f;

    public GameObject _potion_HP;
    public override void PickupItem()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().HealDamage(_healAmount);
        Destroy(this.gameObject);
    }
    
}
