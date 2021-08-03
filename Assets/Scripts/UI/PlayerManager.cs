using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI recordText;
    private TextMeshProUGUI moneyText;
    public Projetil projetil;


    public int updateScore;
    public int updateMoney;
    public int updateRecord;

    public static PlayerManager playerManagerInstance;
    private void Awake()
    {
        
        LoadPlayer();
        if (playerManagerInstance == null)
            playerManagerInstance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        scoreText = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("MoneyNumber").GetComponent<TextMeshProUGUI>();
        recordText = GameObject.Find("RecordNumber").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        updateRecord = 0;
    }
    void Update()
    {
        scoreText = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        moneyText = GameObject.Find("MoneyNumber").GetComponent<TextMeshProUGUI>();
        recordText = GameObject.Find("RecordNumber").GetComponent<TextMeshProUGUI>();
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
        Debug.Log("load");
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("save");
    }
}
