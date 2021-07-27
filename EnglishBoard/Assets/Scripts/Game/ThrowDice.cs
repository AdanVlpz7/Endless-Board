using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowDice : MonoBehaviour
{
    private AudioSource audioSource;
    public Text boardCardTxt;
    public GameObject DiceImage;
    public BoardManagement boardManagement;
    public Sprite[] whiteDiceSprites;
    public Sprite[] redDiceSprites;
    public Sprite[] greenDiceSprites;
    private void OnEnable()
    {
        UserManager userManager;
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        boardCardTxt.text = userManager.boardPosition.ToString();
        //ThrowDiceSprite();
        StartCoroutine(rotationEffect());
        audioSource = GetComponent<AudioSource>();
        if (UserManager.soundOn == 1)
            audioSource.Play();
    }

    void CheckAchievements(int achIndex)
    {
        UserManager userManager;
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        if (!userManager.achievements.Contains(achIndex))
        {
                userManager.achievements.Add(achIndex);
                SaveScript saveScript = GameObject.FindGameObjectWithTag("UserManager").GetComponent<SaveScript>();
                saveScript.SaveBallsData();
        }
    }
    IEnumerator rotationEffect()
    {
        UserManager userManager;
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        switch (userManager.diceIndexUsed)
        {
            case 0:
                DiceImage.GetComponent<Image>().sprite = whiteDiceSprites[0];
                break;
            case 1:
                DiceImage.GetComponent<Image>().sprite = redDiceSprites[0];
                break;
            case 2:
                DiceImage.GetComponent<Image>().sprite = greenDiceSprites[0];
                break;
        }
        //DiceImage.transform.Rotate(new Vector3(0, 180, 0));
        RotateLeft(1,true);
        yield return new WaitForSeconds(4f);
        ThrowDiceSprite();
    }
    void RotateLeft(int i, bool canRotate)
    {
        if (canRotate)
        {
            DiceImage.transform.Rotate(new Vector3(0, Mathf.Clamp(i, 0, 180), 0));
            if (i == 180)
                RotateLeft(i--, canRotate);
            if(i == 0)
                RotateLeft(i++, canRotate);
        }
    }
    void ThrowDiceSprite()
    {
        UserManager userManager;
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        int random = Random.Range(1, 7);
        if(random == 6)
        {
            CheckAchievements(0);
        }
        switch (userManager.diceIndexUsed)
        {
            case 0:
                DiceImage.GetComponent<Image>().sprite = whiteDiceSprites[random];
                break;
            case 1:
                DiceImage.GetComponent<Image>().sprite = redDiceSprites[random];
                break;
            case 2:
                DiceImage.GetComponent<Image>().sprite = greenDiceSprites[random];
                break;
        }
        
        userManager.boardPosition += random;
        if (userManager.boardPosition >= 50)
            CheckAchievements(3);
        if (userManager.boardPosition >= 100)
            CheckAchievements(4);
        if (userManager.boardPosition >= 500)
            CheckAchievements(5);
        if (userManager.boardPosition >= 1000)
            CheckAchievements(6);
        PlayerPrefs.SetInt("BoardPos", userManager.boardPosition);
        boardManagement.RefreshPositions();
    }
}
