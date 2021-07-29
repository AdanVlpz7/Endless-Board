using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyRecord : MonoBehaviour
{
    private AudioSource audioSource;
    public List<int> idAchievements = new List<int> { 0 };
    public Sprite[] rewardsImages;
    public GameObject rewardParentObject;
    public int idToSet = 0;
    public bool weAreInPreviousDay = true;
    private int currentDay;
    private int currentMonth;
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
        }
        if (currentDay == 0 && currentMonth == 0)
        {
            RestartProcess();
        }
        else
        {
            //int temp = 
            currentDay = Int32.Parse(GetComponent<TimeController>().getCurrentDateNow());
            currentMonth = Int32.Parse(GetComponent<TimeController>().getCurrentTimeNow());
            if (currentDay == nextDay)
            {
                rewardParentObject.SetActive(true);
                //nuevo dia
                idToSet++;
                PlayerPrefs.SetInt("idReward", idToSet);
                SetWhichMethodGiveRewards(idToSet);
            }
            else
            {
                //dia diferente al siguiente
                weAreInPreviousDay = PreviousDayToReward(currentDay,currentMonth);
                if (weAreInPreviousDay)
                {
                    //si entramos a jugar y aún no toca recompensa pero ya habíamos jugado
                    rewardParentObject.SetActive(false);
                }
                else
                {
                    //reiniciar cuenta
                    RestartProcess();
                }
            }
            currentMonth = Int32.Parse(GetComponent<TimeController>().getCurrentTimeNow());
        }
        audioSource = GetComponent<AudioSource>();
        if (UserManager.soundOn == 1)
            audioSource.Play();
    }
    
    int CheckNextDay(int day, int month)
    {
        if (month != 2)
        {
            if (day != 30  || day != 31)
            {
                return day++;
            }
            else
            {
                //other months
                switch (month)
                {
                    case 1:
                        return day == 30 ? 31 : 1;
                    case 3:
                        return day == 30 ? 31 : 1;
                    case 4:
                            return 1;
                    case 5:
                        return day == 30 ? 31 : 1;
                    case 6:
                        return 1;
                    case 7:
                        return day == 30 ? 31 : 1;
                    case 8:
                        return day == 30 ? 31 : 1;
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
        return 0;
    }

    bool PreviousDayToReward(int day, int month)
    {
        int previousDay;
            if (day != 1)
            {
                previousDay = day--;
                if (currentDay == previousDay)
                    return true;
            }
            else
            {
                //other months
                switch (month)
                {
                    case 1:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 2:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 3:
                        previousDay = 28;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 4:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 5:
                        previousDay = 30;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 6:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 7:
                        previousDay = 30;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 8:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 9:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 10:
                        previousDay = 30;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 11:
                        previousDay = 31;
                        if (currentDay == previousDay)
                            return true;
                        else return false;
                    case 12:
                        previousDay = 30;
                        if (currentDay == previousDay)
                            return true;
                        else return false;

                }
              
            }
        return true;
    }
    
 

    void RestartProcess()
    {
        //in case our variables are empty
        currentDay = Int32.Parse(GetComponent<TimeController>().getCurrentDateNow());
        currentMonth = Int32.Parse(GetComponent<TimeController>().getCurrentTimeNow());
        idToSet = 0;
        PlayerPrefs.SetInt("idReward", idToSet);
        SetWhichMethodGiveRewards(idToSet);
        nextDay = CheckNextDay(currentDay, currentMonth);
        rewardParentObject.SetActive(true);
        Debug.Log("Day: " + currentDay + "Month: " + "Next Day: " + nextDay + "IdRewardAble" + idToSet);
        PlayerPrefs.SetInt("Day", currentDay);
        PlayerPrefs.SetInt("Month", currentMonth);
        PlayerPrefs.SetInt("NextDay", nextDay);
    }
    void Load()
    {
        currentDay = PlayerPrefs.GetInt("Day",0);
        nextDay = PlayerPrefs.GetInt("NextDay",0);
    }

    void SetWhichMethodGiveRewards(int id)
    {
        switch (id)
        {
            case 0:
                RewardDay1();
                //change to white the color of the sprite
                break;
            case 1:
                RewardDay2();
                //change to white the color of the sprite
                break;
            case 2:
                RewardDay3();
                //change to white the color of the sprite
                break;
            case 3:
                RewardDay4();
                //change to white the color of the sprite
                break;
            case 4:
                RewardDay5();
                //change to white the color of the sprite
                break;
            case 5:
                RewardDay6();
                //change to white the color of the sprite
                break;
            case 6:
                //change to white the color of the sprite
                RewardDay7();
                break;

        }
    }
    void RewardDay1()
    {
        Debug.Log("[Daily Reward] giving first Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays++;
        userManager.coins += 500;
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay2()
    {
        Debug.Log("[Daily Reward] giving second Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays++;
        userManager.coins += 500;
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay3()
    {
        Debug.Log("[Daily Reward] giving third Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.dices += 2;
        userManager.plays++;
        PlayerPrefs.SetInt("UserDices", userManager.dices);
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay4()
    {
        Debug.Log("[Daily Reward] giving fourth Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.dices += 4;
        userManager.plays++;
        PlayerPrefs.SetInt("UserDices", userManager.dices);
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay5()
    {
        Debug.Log("[Daily Reward] giving fifth Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays += 2;
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay6()
    {
        Debug.Log("[Daily Reward] giving sixth Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays += 3;
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
    void RewardDay7()
    {
        Debug.Log("[Daily Reward] giving final Day Reward");
        //we always give the player one play opportunity at day
        UserManager userManager = GetComponent<UserManager>();
        userManager.plays += 4;
        userManager.dices += 3;
        userManager.coins += 1000;
        PlayerPrefs.SetInt("UserDices", userManager.dices);
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        PlayerPrefs.SetInt("UserPlays", userManager.plays);
    }
}
