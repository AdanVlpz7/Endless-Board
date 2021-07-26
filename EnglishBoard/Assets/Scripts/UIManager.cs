using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Parent Objects.")]
    [Tooltip("")] [SerializeField] private GameObject principalMenuParentObject;
    [Tooltip("")] [SerializeField] private GameObject gameParentObject;
    //[Tooltip("")] [SerializeField] private GameObject gameOverParentObject;
    [Tooltip("")] [SerializeField] private GameObject settingsParentObject;
    [Tooltip("")] [SerializeField] private GameObject recordsParentObject;
    [Tooltip("")] [SerializeField] private GameObject dailyAwardParentObject;
    [Tooltip("")] [SerializeField] private GameObject shopParentObject;
    [Tooltip("")] [SerializeField] private GameObject throwingDicePanel;
    [Tooltip("")] [SerializeField] private UserManager userManager;

    public Sprite[] principalSprites;
    public GameObject indicatorSkin;

    public Text DiceCount;
    private void OnEnable()
    {
        ChangeIndicatorSkin();
        ChangeDiceCount();
    }
    public void ChangeIndicatorSkin()
    {
        int index = PlayerPrefs.GetInt("SkinIndex");
        indicatorSkin.GetComponent<Image>().sprite = principalSprites[index];
    }
    public void ChangeDiceCount()
    {
        DiceCount.text = PlayerPrefs.GetInt("PlayerDices").ToString() + " x";
    }
    public void GoToGame()
    {
        if(principalMenuParentObject.activeSelf)
            principalMenuParentObject.SetActive(false);
        gameParentObject.SetActive(true);
    }
    public void GoBackToMenu()
    {
        if (settingsParentObject.activeSelf)
            settingsParentObject.SetActive(false);
        if (recordsParentObject.activeSelf) 
            recordsParentObject.SetActive(false);
        if (shopParentObject.activeInHierarchy)
            shopParentObject.SetActive(false);
        if (dailyAwardParentObject.activeInHierarchy)
            dailyAwardParentObject.SetActive(false);
        if (gameParentObject.activeInHierarchy)
            gameParentObject.SetActive(false);
        if (throwingDicePanel.activeInHierarchy)
            throwingDicePanel.SetActive(false);
        principalMenuParentObject.SetActive(true);
    }
    public void GoToSettingsMenu()
    {
        settingsParentObject.SetActive(true);
        principalMenuParentObject.SetActive(false);
    }

    public void GoToRecordMenu()
    {
        recordsParentObject.SetActive(true);
        //principalMenuParentObject.SetActive(false);
    }
    public void GoToShop()
    {
        shopParentObject.SetActive(true);
        principalMenuParentObject.SetActive(false);
    }

    public void ShootingDiceMenu()
    {
        if (userManager.dices > 0)
        {
            
            throwingDicePanel.SetActive(true);
            userManager.dices--;
            PlayerPrefs.SetInt("PlayerDices", userManager.dices);
            ChangeDiceCount();
            StartCoroutine(previousGoToMenu());
        }
    }

    private IEnumerator previousGoToMenu()
    {
        yield return new WaitForSeconds(6f);
        GoBackToMenu();
    }
}
