using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowyCloak : Pickup
{
    //Immune to damage while dashing

    public Transform _flashPoint;

    public GameObject _flashParticle;

    bool isActive = false;
    public void PlayFlashEffect()
    {
        GameObject spawenedFLash = Instantiate(_flashParticle, _flashPoint.position, _flashPoint.rotation, _flashPoint);
        Destroy(spawenedFLash, 5.0f);
    }

    public override void PickupItem()
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
}
