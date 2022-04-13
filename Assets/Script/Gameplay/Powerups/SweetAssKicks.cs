using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetAssKicks : Pickup
{
    public float speedMultiplier = 3;

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
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().IncreaseSpeed(speedMultiplier); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().RevertSpeed(); // remove boost
        isActive = false;

    }
    /*void Update()
    {
        if (isActive == true)
        {
            activeItem.SetActive(true);
        }
        else if (isActive == false)
        {
            activeItem.SetActive(false);
        }
    }*/
}
