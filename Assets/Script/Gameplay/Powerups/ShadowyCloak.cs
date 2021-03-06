using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowyCloak : Powerup
{
    //Immune to damage while dashing

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
            StartCoroutine(PowerUpWearOff(20f));
        }


    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().SetInvincibleDash(); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().RevertInvincibilty(); // remove boost
        isActive = false;

    }

    public override void CheckAmount()
    {
        if (itemAmount > 0)
        {
            UsePowerup();
            itemAmount -= 1;
            UIControl.instance.cloakAmountText.text = itemAmount.ToString();
        }
    }

    public override void UpdateAmountText()
    {
        UIControl.instance.cloakAmountText.text = itemAmount.ToString();
    }

    public override void KeyActivate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
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
