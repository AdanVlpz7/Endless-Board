using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowDice : MonoBehaviour
{
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
        ThrowDiceSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowDiceSprite()
    {
        UserManager userManager;
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        int random = Random.Range(1, 7);
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
        PlayerPrefs.SetInt("BoardPos", userManager.boardPosition);
        boardManagement.RefreshPositions();
    }
}
