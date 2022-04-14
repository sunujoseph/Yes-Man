using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    

    public bool isPaused = false;
    public float timeLeft = 30;
    float timeLeftInt;

    public static LevelManager instance;

    public string ActiveScene;

    public int currentRound;
    
    
    public bool newRound;

    public GameObject boss;

    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MainSceneComplete")
        {
            ActiveScene = "Main";
            currentRound = 1;
            StartFirstRound();
        }
        else if (sceneName == "Tutorial")
        {
            ActiveScene = "Tutorial";
        }
        else if (sceneName == "LoseScene")
        {
            ActiveScene = "LoseScene";
        }
        else if (sceneName == "Setting")
        {
            ActiveScene = "Settings";
        }
    }

    void Update()
    {
        switch (currentRound)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    StartNewRound();
                    timeLeft = 60;
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }

        if (newRound) 
        {
            NewRound();
        }

        DisplayRound();
        DisplayTime();

    }
    public void PauseUnpause()
    {
        if (Time.timeScale == 0 || isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public IEnumerator LevelEnd()
    {
        //AudioManager.instance.PlayRoundWin();

        //UIControl.instance.StartFadeToBlack();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(4);
    }

    public void NewRound()
    {
        currentRound += 1;

        StartNewRound();

        newRound = false;

        if (currentRound >= 5)
        {
            SceneManager.LoadScene(5);
        }
    }

    void DisplayRound()
    {
        UIControl.instance._currentRound.text = ("Round " + currentRound.ToString());
    }
    void DisplayTime()
    {
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        timeLeftInt = (int)timeLeft;
        
        UIControl.instance._timeLeft.text = (timeLeftInt.ToString());
    }
    public void StartFirstRound()
    { 


        timeLeft = 30;

        spawner1.SetActive(true);

    }
    public void StartNewRound()
    {
        AudioManager.instance.PlayRoundWin();


        currentRound += 1;

        timeLeft = 60;

        if (currentRound == 2)
        {
            spawner1.SetActive(false);
            spawner2.SetActive(true);
        }
        if (currentRound == 3)
        {
            spawner2.SetActive(false);
            spawner3.SetActive(true);
        }
        if (currentRound == 4)
        {
            spawner3.SetActive(false);
            spawner4.SetActive(true);
        }
        if (currentRound == 5)
        {
            spawner4.SetActive(false);
            boss.SetActive(true);
        }

    }



}
