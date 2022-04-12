using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplyfyingGem : Powerup
{
    //Increase Attack Damage
    public float attackMultiplier = 2;

    public GameObject AmpGem;

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
            StartCoroutine(PowerUpWearOff(15f));  
        }
        
        
    }
    IEnumerator PowerUpWearOff(float waitTime)
    {
        GameObject.FindWithTag("PlayerBullet").GetComponent<Bullet>().IncreaseAttackDamage(attackMultiplier); // add boost
        yield return new WaitForSeconds(waitTime);
        GameObject.FindWithTag("PlayerBullet").GetComponent<Bullet>().RevertAttackDamage(); // remove boost
        isActive = false;

    }
}
