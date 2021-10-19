using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip gameMusic;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void StartGame()
    {
        transform.localScale = Vector3.zero;

        Time.timeScale = 1f;
        
        if(audioSource && gameMusic)
        {
        audioSource.clip = gameMusic;
        audioSource.loop = true;
        audioSource.Play();
        }
    }
}
