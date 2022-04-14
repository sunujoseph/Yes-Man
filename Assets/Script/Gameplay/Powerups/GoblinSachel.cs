using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSachel : Powerup
{
    //Increase gold collection value
    public int goldValueMultiplier = 3;


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
        GameObject.FindWithTag("Coin").GetComponent<CoinPickup>().IncreaseGoldValue(goldValueMultiplier); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("Coin").GetComponent<CoinPickup>().RevertGoldValue(); // remove boost
        isActive = false;

    }
   
}
