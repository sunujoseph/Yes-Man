using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int itemAmount;

    //public float duration;

    private void Update()
    {
        UpdateAmountText();
        KeyActivate();
    }
    public virtual void UsePowerup()
    {
        Debug.Log(this.gameObject.name + "used");
    }

    public bool isActive = false;

    public virtual void CheckAmount()
    {

    }

    public void StoreItem()
    {
        itemAmount += 1;
    }

    public virtual void UpdateAmountText()
    {
        
    }

    public virtual void KeyActivate()
    {

    }


}







