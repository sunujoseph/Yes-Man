using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public bool isPaused = false;
    float timeLeft = 300;
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
            StartCoroutine(StartFirstRound());
        }
        else if (sceneName == "BossScene")
        {
            ActiveScene = "Boss";
            currentRound = 5;
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
                if (timeLeft < 0)
                {
                    StartCoroutine(LevelEnd());
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
        currentRound++;

        StartCoroutine(StartNewRound());

        if (currentRound >= 5)
        {
            SceneManager.LoadScene(6);
        }
    }

    void DisplayRound()
    {
        UIControl.instance._currentRound.text = ("Round " + currentRound.ToString());
    }
    void DisplayTime()
    {
        timeLeftInt = (int)timeLeft;
        UIControl.instance._currentRound.text = (timeLeftInt.ToString());
    }
    public IEnumerator StartFirstRound()
    { 

        yield return new WaitForSeconds(5);

        timeLeft = 300;

        spawner1.SetActive(true);

    }
    public IEnumerator StartNewRound()
    {
        AudioManager.instance.PlayRoundWin();

        yield return new WaitForSeconds(5);

        timeLeft = 300;

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
        
    }
}
