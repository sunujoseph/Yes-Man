using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHeart : Pickup
{
    //Increase max health + heals fully
    public float maxHP_Multiplier = 1.5f;


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
            StartCoroutine(PowerUpWearOff(60f));
        }


    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().IncreaseMaxHP(maxHP_Multiplier); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().RevertMaxHP(); // remove boost
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
