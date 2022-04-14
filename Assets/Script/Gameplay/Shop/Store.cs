using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public static Store instance;
    private void Awake()
    {
        instance = this;
    }
    public bool isShopping = false;

    public GameObject mainCanvas;
    public GameObject canvas2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isShopping = true;
            //mainCanvas.SetActive(false);
            canvas2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isShopping = false;
            canvas2.SetActive(false);
            //mainCanvas.SetActive(true);
        }
            
    }

    private void Update()
    {
        if (isShopping)
        {
            LevelManager.instance.timeLeft = 60;
        }
        else
        {
            canvas2.SetActive(false);
        }
    }
}
