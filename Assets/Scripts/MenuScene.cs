using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public static MenuScene instance;
    public GameObject dataBoard;
    public GameObject settingsBoard;
    public MusicManager musicManager;

    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.instance.PlayThemeSong();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetButton()
    {
        DataManager.Instance.RemoveData();
    }
    public void PlayButton()
    {

        MusicManager.instance.StopMusic();
        SceneManager.LoadScene(1);

    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Bullet Shot: " + DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed: " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }
    public void SettingsBoardButton()
    {
        settingsBoard.SetActive(true);
    }
    public void XButton()
    {
        dataBoard.SetActive(false);
    }
    public void XSButton()
    {
        settingsBoard.SetActive(false);
    }
    public void SoundButton()
    {
        
    }

}
