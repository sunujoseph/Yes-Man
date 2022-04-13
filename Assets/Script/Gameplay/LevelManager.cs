using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isPaused = false;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        
    }
    public void PauseUnpause()
    {
        if (Time.timeScale == 0)
        {
            isPaused = true;
        }
    }

    public IEnumerator LevelEnd()
    {
        AudioManager.instance.PlayLevelWin();

        //UIControl.instance.StartFadeToBlack();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(3);
    }
}
