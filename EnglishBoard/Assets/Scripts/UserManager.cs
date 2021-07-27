using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    [SerializeField] private Text shopCoinIndicator;
    public int coins = 0;

    public List<int> diceBought = new List<int> { 0 };
    public int diceIndexUsed = 0;
    public List<int> skinBought = new List<int> { 0 };
    public int skinIndexUsed = 0;
    public List<int> achievements = new List<int> { 8 };
    public int boardPosition = 0;
    public int dices = 1;
    public static int soundOn = 1; 
    public static int musicOn = 1;

    public static int englishOn = 1;
    public static int russianOn = 0;
    private void Start()
    {
        LoadData();
        PlayerPrefs.SetInt("PlayerDices", 15);
        achievements = new List<int>();
        if (diceBought == null)
            diceBought.Insert(0, 0);
        
        if (skinBought == null)
            skinBought.Insert(0, 0);
        if (achievements == null)
            achievements.Insert(8, 0);
        UpdateTextCoinIndicator();
    }
    private void OnEnable()
    {
        LoadData();
    }
    public void Save()
    {
        SaveScript saveScript = GetComponent<SaveScript>();
        saveScript.SaveBallsData();
    }
    private void LoadData()
    {
        coins = PlayerPrefs.GetInt("UserCoins");
        englishOn = PlayerPrefs.GetInt("EnglishKey");
        russianOn = PlayerPrefs.GetInt("RussianKey");
        soundOn = PlayerPrefs.GetInt("SoundOnKey");
        musicOn = PlayerPrefs.GetInt("MusicOnKey");
        diceIndexUsed = PlayerPrefs.GetInt("DiceIndex");
        skinIndexUsed = PlayerPrefs.GetInt("SkinIndex");
        dices = PlayerPrefs.GetInt("PlayerDices",1);
        boardPosition = PlayerPrefs.GetInt("BoardPos",1);
        AudioSource generalAudio = this.GetComponent<AudioSource>();
        if (musicOn == 1)
            generalAudio.Play();
        else
            generalAudio.Stop();
    }

    public void UpdateTextCoinIndicator()
    {
        shopCoinIndicator.text = "$ " + coins.ToString();
        PlayerPrefs.SetInt("UserCoins", coins);
    }
    public void UpdateAfterBuying(int price, int indexToAdd, bool skin)
    {
        coins -= price;
        Debug.Log("[User Manager] You have bought something!.");
        if (skin)
            skinBought.Add(indexToAdd);
        else
            diceBought.Add(indexToAdd);
        shopCoinIndicator.text = coins.ToString();
        PlayerPrefs.SetInt("UserCoins", coins);
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        if (!achievements.Contains(1))
        {
            if (skinBought.Contains(1) && skinBought.Contains(2))
            {
                achievements.Add(1);
                SaveScript saveScript = GetComponent<SaveScript>();
                saveScript.SaveBallsData();
            }
        }
        if (!achievements.Contains(2))
        {
            if (diceBought.Contains(1) && diceBought.Contains(2))
            {
                achievements.Add(2);
                SaveScript saveScript = GetComponent<SaveScript>();
                saveScript.SaveBallsData();
            }
        }
    }
}
