using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject itemUI;
    public virtual void UsePowerup()
    {

    }


    public bool isActive = false;

    void Update()
    {
        if (isActive == true)
        {
            itemUI.SetActive(true);

        }

        {
            itemUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            UsePowerup();
            Debug.Log("Powered up " + itemUI);
        }
    }
}

    

    

    

