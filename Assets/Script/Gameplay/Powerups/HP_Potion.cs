using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Potion : Powerup
{
    //Increase max health + heals fully
    public float healAmount = 50;

    public Transform _flashPoint;

    public GameObject _flashParticle;

    bool isActive = false;
    public void PlayFlashEffect()
    {
        GameObject spawenedFLash = Instantiate(_flashParticle, _flashPoint.position, _flashPoint.rotation, _flashPoint);
        Destroy(spawenedFLash, 5.0f);
    }

    public override void UsePowerup()
    {
        if (isActive == false)
        {
            PlayFlashEffect();

            isActive = true;
            StartCoroutine(PowerUpWearOff(60f));
        }


    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().HealDamage(50); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().RevertMaxHP(); // remove boost
        isActive = false;

    }
}
