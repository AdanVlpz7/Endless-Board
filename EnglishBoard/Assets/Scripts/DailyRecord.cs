using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyRecord : MonoBehaviour
{
    private AudioSource audioSource;
    
    public List<int> idAchievements = new List<int> { 0 };
    public Image[] rewardsImages;
    public GameObject rewardParentObject;
    public int idToSet = 0;
    public bool weAreInPreviousDay = true;
    private int currentDay = 0;
    private int currentMonth = 0;
    private int nextDay;
    private int nextMonth;
    // Start is called before the first frame update
    void Start()
    {
        Load();
        if (weAreInPreviousDay == false)
        {
            currentDay = 0;
            currentMonth = 0;
            if (!rewardParentObject.activeInHierarchy)
                rewardParentObject.SetActive(true);
            return;
            
        }
        if (currentDay == 0 && currentMonth == 0)
        {
            RestartProcess();
            if (!rewardParentObject.activeInHierarchy)
                rewardParentObject.SetActive(true);
            return;
        }
        if(currentDay != 0)
        {
            //int temp = 
            currentDay = (GetComponent<TimeController>().getCurrentDateNow());
            currentMonth = (GetComponent<TimeController>().getCurrentTimeNow());
            if (currentMonth == nextDay)
            {
                if (idToSet == 6)
                {
                    RestartProcess();
                    rewardParentObject.SetActive(true);
                }
                else
                {
                    if (!rewardParentObject.activeInHierarchy)
                        rewardParentObject.SetActive(true);
                    //nuevo dia
                    idToSet++;
                    nextDay = CheckNextDay(currentMonth, currentDay);
                    PlayerPrefs.SetInt("Day", currentMonth);
                    PlayerPrefs.SetInt("idReward", idToSet);
                    PlayerPrefs.SetInt("NextDay", nextDay);
                    Debug.Log("Day: " + currentMonth + " Month: " + currentDay + " Next Day: " + nextDay + " IdRewardAble: " + idToSet);
                    SetWhichMethodGiveRewards(idToSet);
                    return;
                }
            }
            if(currentMonth != nextDay)
            {
                //dia diferente al siguiente
                weAreInPreviousDay = PreviousDayToReward(currentMonth, currentDay);
                if (weAreInPreviousDay) { 

                    Debug.Log("[DailyRecord] You already played today.");
                    //si entramos a jugar y aún no toca recompensa pero ya habíamos jugado
                    rewardParentObject.SetActive(false);
                    return;
                }
                if(!weAreInPreviousDay)
                {
                    //reiniciar cuenta
                    Debug.Log("[DailyRecord] restarting count.");
                    RestartProcess();
                    if (!rewardParentObject.activeInHierarchy)
                        rewardParentObject.SetActive(true);
                    return;
                }
            }
        }
        audioSource = GetComponent<AudioSource>();
        if (UserManager.soundOn == 1)
            audioSource.Play();
    }
    
    int CheckNextDay(int day, int month)
    {
        if (month != 2)
        {
            if (day < 30)
            {
                Debug.Log("Just adding one day");
                return day+=1;
            }
            else
            {
                //other months
                switch (month)
                {
                    case 1:
                        Debug.Log("Your Month is January bro");
                        if (day == 30)
                            return 31;
                        if (day == 31)
                            return 1;
                        break;
                    case 3:
                        return day == 30 ? 31 : 1;
                    case 4:
                            return 1;
                    case 5:
                        return day == 30 ? 31 : 1;
                    case 6:
                        return 1;
                    case 7:
                        if (day == 30)
                            return 31;
                        if (day == 31)
                            return 1;
                        break;
                        //return day == 30 ? 31 : 1;
                    case 8:
                        Debug.Log("Your Month is August bro");
                        if (day == 30)
                            return 31;
                        if (day == 31)
                            return 1;
                        break;
                    case 9:
                        return 1;
                    case 10:
                        return day == 30 ? 31 : 1;
                    case 11:
                        return 1;
                    case 12:
                        return day == 30 ? 31 : 1;

                }
            }
            
        }
        if(month == 2)
        {
            if(day != 28)
            {
                return day++;
            }
        }
        return day++;
    }

    bool PreviousDayToReward(int day, int month)
    {
        int previousDay;
            if (nextDay > 1)
            {
                Debug.Log("Case 1 Previous Day To Reward");
                previousDay = nextDay-1;
                Debug.Log("previousDay : " + previousDay + " day: " + day + " nextDay was settled on: "+nextDay);
                if (day == previousDay)
                    return true;
                else
                    return false;
            }
            if(nextDay == 1)
            {
                //other months
                switch (month)
                {
                    case 1:
                    Debug.Log("Case 2 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 2:
                    Debug.Log("Case 2 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 3:
                    Debug.Log("Case 3 Previous Day To Reward");
                    previousDay = 28;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 4:
                    Debug.Log("Case 4 Previous Day To Reward");
                    previousDay = 30;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 5:
                    Debug.Log("Case 5 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 6:
                    Debug.Log("Case 6 Previous Day To Reward");
                    previousDay = 30;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 7:
                    Debug.Log("Case 7 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 8:
                    Debug.Log("Case 8 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 9:
                    Debug.Log("Case 9 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 10:
                    Debug.Log("Case 10 Previous Day To Reward");
                    previousDay = 30;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 11:
                    Debug.Log("Case 11 Previous Day To Reward");
                    previousDay = 31;
                        if (day == previousDay)
                            return true;
                        else return false;
                    case 12:
                    Debug.Log("Case 12 Previous Day To Reward");
                    previousDay = 30;
                        if (day == previousDay)
                            return true;
                        else return false;

                }
              
            }
        return true;
    }
    
 

    void RestartProcess()
    {
        //in case our variables are empty
        currentDay = (GetComponent<TimeController>().getCurrentDateNow());
        currentMonth = (GetComponent<TimeController>().getCurrentTimeNow());
        idToSet = 0;
        PlayerPrefs.SetInt("idReward", idToSet);
        SetWhichMethodGiveRewards(idToSet);
        nextDay = CheckNextDay(currentMonth, currentDay);
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        Debug.Log("Day: " + currentMonth + " Month: " +  currentDay + " Next Day: " + nextDay + " IdRewardAble: " + idToSet);
        PlayerPrefs.SetInt("Day", currentMonth);
        PlayerPrefs.SetInt("Month", currentMonth);
        PlayerPrefs.SetInt("NextDay", nextDay);
    }
    void Load()
    {
        currentDay = PlayerPrefs.GetInt("Day",0);
        nextDay = PlayerPrefs.GetInt("NextDay",0);
        idToSet = PlayerPrefs.GetInt("idReward");
        Debug.Log("[DailyRecord] current Day is: " + currentDay + " Next Day was settled on: " + nextDay + " Id To Set Was: " + idToSet);
    }

    void SetWhichMethodGiveRewards(int id)
    {
        switch (id)
        {
            case 0:
                RewardDay1();
                //change to white the color of the sprite
                rewardsImages[0].color = Color.white;
                break;
            case 1:
                RewardDay2();
                //change to white the color of the sprite
                rewardsImages[1].color = Color.white;
                break;
            case 2:
                RewardDay3();
                //change to white the color of the sprite
                rewardsImages[2].color = Color.white;
                break;
            case 3:
                RewardDay4();
                //change to white the color of the sprite
                rewardsImages[3].color = Color.white;
                break;
            case 4:
                RewardDay5();
                //change to white the color of the sprite
                rewardsImages[4].color = Color.white;
                break;
            case 5:
                RewardDay6();
                //change to white the color of the sprite
                rewardsImages[5].color = Color.white;
                break;
            case 6:
                //change to white the color of the sprite
                rewardsImages[6].color = Color.white;
                rewardsImages[7].color = Color.white;
                rewardsImages[8].color = Color.white;
                RewardDay7();
                break;

        }
    }
    void RewardDay1()
    {
        Debug.Log("[Daily Reward] giving first Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        userManager.plays++;
        userManager.coins += 500;
        userManager.UpdateTextCoinIndicator();
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay2()
    {
        Debug.Log("[Daily Reward] giving second Day Reward");
        //we always give the player one play opportunity at day
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays++;
        userManager.coins += 500;
        userManager.UpdateTextCoinIndicator();
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay3()
    {
        Debug.Log("[Daily Reward] giving third Day Reward");
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.dices += 2;
        userManager.plays++;
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangeDiceCount();
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("PlayerDices", userManager.dices);
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay4()
    {
        Debug.Log("[Daily Reward] giving fourth Day Reward");
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.dices += 4;
        userManager.plays++;
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangeDiceCount();
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("PlayerDices", userManager.dices);
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay5()
    {
        Debug.Log("[Daily Reward] giving fifth Day Reward");
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangePlaysCount();
        userManager.plays += 2;
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay6()
    {
        Debug.Log("[Daily Reward] giving sixth Day Reward");
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
  
        userManager.plays += 3;
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("PlayerPlays", userManager.plays);
    }
    void RewardDay7()
    {
        Debug.Log("[Daily Reward] giving final Day Reward");
        if (!rewardParentObject.activeInHierarchy)
            rewardParentObject.SetActive(true);
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays += 4;
        userManager.dices += 3;
        userManager.coins += 1000;
        userManager.UpdateTextCoinIndicator();
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangeDiceCount();
        uiManager.ChangePlaysCount();
        PlayerPrefs.SetInt("PlayDices", userManager.dices);
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("PlayPlays", userManager.plays);
    }
}
