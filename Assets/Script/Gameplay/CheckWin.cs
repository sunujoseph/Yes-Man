using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public GameObject boss;
    public GameObject portal;

    public GameObject winScreen;

    private void Start()
    {
        winScreen.SetActive(false);
    }
    private void Update()
    {
        if (boss = null)
        {
            StartCoroutine(openWinScreen());
            Instantiate(portal, transform.position, Quaternion.identity);
        }
    }

    IEnumerator openWinScreen()
    {
        winScreen.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        winScreen.SetActive(false);
    }
}
