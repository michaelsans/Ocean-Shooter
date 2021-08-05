using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI recordText;
    private TextMeshProUGUI moneyText;
    public Projetil projetil;
    public Shop shop;

    public int updateScore;
    public int updateMoney;
    public int updateRecord;
    public bool[] updateItemPurchased;
    public bool levelLoaded = false;

    public static PlayerManager playerManagerInstance;
    private void Awake()
    {
        if (playerManagerInstance == null)
            playerManagerInstance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
    }
    private void OnEnable()
    {
        scoreText = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("MoneyNumber").GetComponent<TextMeshProUGUI>();
        recordText = GameObject.Find("RecordNumber").GetComponent<TextMeshProUGUI>();
        shop = GameObject.Find("NewShop").GetComponentInChildren<Shop>();
        
    }
    private void Start()
    {
        updateRecord = 0;
        updateItemPurchased = new bool[10];
        LoadPlayer();
    }
    void Update()
    {
        scoreText = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("MoneyNumber").GetComponent<TextMeshProUGUI>();
        recordText = GameObject.Find("RecordNumber").GetComponent<TextMeshProUGUI>();
        if(SceneManager.GetActiveScene().buildIndex == 0)
            shop = GameObject.Find("NewShop").GetComponentInChildren<Shop>();
        moneyText.text = updateMoney.ToString();
        scoreText.text = updateScore.ToString();
        SetRecord();
    }
    public void SetRecord()
    {
        if (updateScore > updateRecord)
        {
            updateRecord = updateScore;
            recordText.text = updateRecord.ToString();
        }
        else
            recordText.text = updateRecord.ToString();
    }

    public void ResetScore()
    {
        updateScore = 0;
        scoreText.text = updateScore.ToString();
    }

    public void UseMoney(int amount)
    {
        updateMoney -= amount;
    }
    public bool HasEnoughMoney(int amount)
    {
        return (updateMoney >= amount);
    }

    public void LoadPlayer()
    {
        PlayerSaveData data = SaveSystem.LoadPlayer();
        updateMoney = data.money;
        updateRecord = data.record;
        levelLoaded = true;
        for (int i = 0; i <= 9; i++)
        {
            updateItemPurchased[i] = data.itemPurchased[i];
        }
        Debug.Log("Load");
    }

    public void SavePlayer()
    {   
        SaveSystem.SavePlayer(this);
        Debug.Log("save");
    }
}
