using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;

    void Start()
    {

        MusicManager.instance.PlayRandomSong();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        MusicManager.instance.PauseMusic();   
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        MusicManager.instance.ResumeMusic();
    }
    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        MusicManager.instance.StopMusic();
        SceneManager.LoadScene(0);
    }

    
}
