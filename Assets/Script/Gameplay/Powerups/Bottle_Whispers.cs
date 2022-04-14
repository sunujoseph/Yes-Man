using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle_Whispers : Powerup
{
    //DecreaseDashCooldown
    public float cooldownkMultiplier = 0.5f;

    

    public Transform _flashPoint;

    public GameObject _flashParticle;

   
    public void PlayFlashEffect()
    {
        GameObject spawenedFLash = Instantiate(_flashParticle, _flashPoint.position, _flashPoint.rotation, _flashPoint);
        Destroy(spawenedFLash, 5.0f);
    }

    public override void UsePowerup()
    {
        if (isActive == false)
        {
            //PlayFlashEffect();

            isActive = true;
            StartCoroutine(PowerUpWearOff(15f));
        }


    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().DecreaseDashCooldown(cooldownkMultiplier); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().RevertDashCooldown(); // remove boost
        isActive = false;

    }

    public override void CheckAmount()
    {
        if (itemAmount > 0)
        {
            UsePowerup();
            itemAmount -= 1;
            UIControl.instance.bottleAmountText.text = itemAmount.ToString();
        }
    }

    public override void UpdateAmountText()
    {
        UIControl.instance.bottleAmountText.text = itemAmount.ToString();
    }

    public override void KeyActivate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckAmount();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        Debug.Log("Picked up");
    //        UsePowerup();
    //        Destroy(gameObject);
    //    }
    //}

}
