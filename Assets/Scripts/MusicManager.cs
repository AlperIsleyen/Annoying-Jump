using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip themeSong;
    public AudioClip[] songList;
    private float playbackPosition;
    private bool isPaused;
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayThemeSong()
    {
        audioSource.time = 0;
        audioSource.clip = themeSong;
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayRandomSong()
    {
        int randomIndex = Random.Range(0, songList.Length);
        audioSource.clip = songList[randomIndex];
        audioSource.Play();
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            playbackPosition = audioSource.time;
            audioSource.Pause();
            isPaused = true;
        }
    }

    public void ResumeMusic()
    {
        if (isPaused)
        {
            audioSource.time = playbackPosition; 
            audioSource.Play();
            isPaused = false;
        }
    }
}
