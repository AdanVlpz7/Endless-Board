using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternatingBtns : MonoBehaviour
{
    public static int skinArrayIndex;
    public static int diceArrayIndex;
    

    public GameObject[] imageSkinsIndicator = new GameObject[3];
    public GameObject[] imageDicesIndicator = new GameObject[3];
    public Sprite[] images = new Sprite[2];
    
    private int arbitrary1 = skinArrayIndex;
    private int arbitrary2 = diceArrayIndex;
    int caseUpdate;

    private bool changing = false;

    private void Start()
    {
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        skinArrayIndex = userManager.skinIndexUsed;
        for (int i = 0; i < imageSkinsIndicator.Length; i++)
        {
            if (i == skinArrayIndex)
            {
                ChangingImageOfButtonUse(imageSkinsIndicator[i]);
                imageSkinsIndicator[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                caseUpdate = 0;
                ResettingImages(i);
            }
        }
        diceArrayIndex = userManager.diceIndexUsed;
        for (int i = 0; i < imageDicesIndicator.Length; i++)
        {
            if (i == diceArrayIndex)
            {
                ChangingImageOfButtonUse(imageDicesIndicator[i]);
                imageDicesIndicator[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                caseUpdate = 1;
                ResettingImages(i);
            }
        }
    }
    public void SettingCase(int caseUp)
    {
        caseUpdate = caseUp;
    }
    public void ChangeArrayIndex(int num)
    {
        if (changing)
        {
            switch (caseUpdate)
            {
                case 0:
                    if (arbitrary1 != num)
                    {
                        ResettingImage(true);
                        skinArrayIndex = num;
                        arbitrary1 = skinArrayIndex;
                        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
                        userManager.skinIndexUsed = skinArrayIndex;
                        PlayerPrefs.SetInt("SkinIndex",arbitrary1);
                    }
                    break;
                case 1:
                    if (arbitrary2 != num)
                    {
                        ResettingImage(false);
                        diceArrayIndex = num;
                        arbitrary2 = diceArrayIndex;
                        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
                        userManager.diceIndexUsed = diceArrayIndex;
                        PlayerPrefs.SetInt("DiceIndex",arbitrary2);
                    }
                    break;
            }
        }
    }
    public void ChangingImageOfButtonUse(GameObject index)
    {
        if (index.GetComponent<Image>().color == Color.gray)
            changing = false;
        if (index.GetComponent<Image>().color == Color.white)
            changing = true;
        if(changing)
        index.GetComponent<Image>().sprite = images[0];
    }
    public void ResettingImage(bool skins)
    {
        if (skins)
        {
            imageSkinsIndicator[skinArrayIndex].GetComponent<Image>().sprite = images[1];
            
        }
        else
            imageDicesIndicator[diceArrayIndex].GetComponent<Image>().sprite = images[1];
            
    }
    public void ResettingImages(int index)
    {
        switch (caseUpdate)
        {
            case 0:
                imageSkinsIndicator[index].GetComponent<Image>().sprite = images[1];
                //imageSkinsIndicator[skinArrayIndex].GetComponent<Image>().color = Color.gray;
                break;
            case 1:
                imageDicesIndicator[index].GetComponent<Image>().sprite = images[1];
                //imageDicesIndicator[diceArrayIndex].GetComponent<Image>().color = Color.gray;
                break;
        }
    }
}
