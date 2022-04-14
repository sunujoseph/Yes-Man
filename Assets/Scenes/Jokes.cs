using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokes : MonoBehaviour
{

    public AudioSource _as;
    public AudioClip[] audioClips; 
    // Start is called before the first frame update
    void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _as.clip = audioClips[Random.Range(0, audioClips.Length)];
        _as.PlayOneShot(_as.clip);
    }
    // Update is called once per frame
}
