using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource winMusic;
    public AudioSource dashSFX;

    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();

        gameOverMusic.Play();
    }

    public void PlayRoundWin()
    {
        levelMusic.Stop();

        winMusic.Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
    public void EnemyDash()
    {
        dashSFX.Stop();

        dashSFX.Play();
    }

}
