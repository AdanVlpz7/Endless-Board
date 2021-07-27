using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PowerUps powerUpParent;
    // Start is called before the first frame update
    void Start()
    {
        powerUpParent = this.GetComponentInParent<PowerUps>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (powerUpParent.randomIndex == 0)
            {
                IncreaseCoins();
            }
            if (powerUpParent.randomIndex == 1)
            {
                IncreaseTimer();
            }
            if (powerUpParent.randomIndex == 2)
            {
                IncreaseDiceCount();
            }
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(powerUpParent.randomIndex == 0)
            {
                IncreaseCoins();
            }
            if (powerUpParent.randomIndex == 1)
            {
                IncreaseTimer();
            }
            if (powerUpParent.randomIndex == 2)
            {
                IncreaseDiceCount();
            }
            Destroy(this.gameObject);
        }
    }

    private void IncreaseTimer()
    {
        Debug.Log("[PowerUp] Increasing Timer");
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        timer.timeToShowInSeconds += 20;
    }
    private void IncreaseCoins()
    {
        Debug.Log("[PowerUp] Increasing Coins");
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        userManager.coins += 100;
        PlayerPrefs.SetInt("UserCoins", userManager.coins);
        userManager.UpdateTextCoinIndicator();
    }
    private void IncreaseDiceCount()
    {
        Debug.Log("[PowerUp] Increasing Dice Count");
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        userManager.dices++;
        PlayerPrefs.SetInt("UserDices", userManager.dices);
        UIManager uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        uiManager.ChangeDiceCount();
    }
}
