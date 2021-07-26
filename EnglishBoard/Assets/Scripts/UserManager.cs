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

    public static int soundOn = 1; 
    public static int musicOn = 1;

    public static int englishOn = 1;
    public static int russianOn = 0;
    private void Start()
    {
        LoadData();
        //diceBought.Clear();
        //skinBought.Clear();
        if (diceBought == null)
            diceBought.Insert(0, 0);
        
        if (skinBought == null)
            skinBought.Insert(0, 0);
        
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
        coins = PlayerPrefs.GetInt("Record");
        englishOn = PlayerPrefs.GetInt("EnglishKey");
        russianOn = PlayerPrefs.GetInt("RussianKey");
        soundOn = PlayerPrefs.GetInt("SoundOnKey");
        musicOn = PlayerPrefs.GetInt("MusicOnKey");
        AudioSource generalAudio = this.GetComponent<AudioSource>();
        if (musicOn == 1)
            generalAudio.Play();
        else
            generalAudio.Stop();
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

    }
}
