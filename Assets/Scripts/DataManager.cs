using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    EasyFileSave myFile;
    private int coinCollected;
    public int totalCoinCollected;
    public Vector2 lastCheckpoint;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        
    }

    public Vector2 CheckPointSave
    {
        get
        {
            return lastCheckpoint;

        }
        set
        {
            lastCheckpoint = value;

        }
    }

    public int CoinCollected
    {
        get
        {
            return coinCollected;

        }
        set
        {
            coinCollected = value;
            GameObject.Find("CoinCollectedText").GetComponent<TextMeshProUGUI>().text = coinCollected.ToString();
        }
    }
    public int ShotBullet
    {
        get { 
            return shotBullet;

        }
        set { 
            shotBullet = value;
        }
    }
    public int EnemyKilled
    {
        get {
            return enemyKilled;

        }
        set
        {
            enemyKilled = value;

        }
    }
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }
    public void SaveData()
    {
        totalShotBullet += shotBullet; 
        totalEnemyKilled += enemyKilled;
        totalCoinCollected += coinCollected;

        myFile.Add("totalBulletShot", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);
        myFile.Add("totalCoinCollected", totalCoinCollected);
        myFile.Add("lastCheckPoint", lastCheckpoint);

        myFile.Save();

    }
    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalBulletShot");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
            totalCoinCollected = myFile.GetInt("totalCoinCollected");
            lastCheckpoint = myFile.GetUnityVector2("lastCheckPoint");
        }
    }

    public void RemoveData()
    {
        myFile.Add("totalBulletShot", 0f);
        myFile.Add("totalEnemyKilled", 0f);
        myFile.Add("totalCoinCollected", 0f);
        myFile.Add("lastCheckPoint", (-8.35f,-0.36f));

        myFile.Save();

        LoadData() ;
    }
}
