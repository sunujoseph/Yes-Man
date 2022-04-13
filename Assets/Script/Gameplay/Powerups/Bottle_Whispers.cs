using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle_Whispers : Pickup
{
    //DecreaseDashCooldown
    public float cooldownkMultiplier = 0.5f;

    public GameObject BottleOfWhispers;

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
}
