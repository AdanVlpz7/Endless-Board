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
    public Text PlayCount;
    private void OnEnable()
    {
        ChangeIndicatorSkin();
        ChangeDiceCount();
        ChangePlaysCount();
    }
    public void ChangeIndicatorSkin()
    {
        int index = PlayerPrefs.GetInt("SkinIndex");
        indicatorSkin.GetComponent<Image>().sprite = principalSprites[index];
    }
    public void ChangeDiceCount()
    {
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        DiceCount.text = PlayerPrefs.GetInt("PlayerDices").ToString() + " x";
        DiceCount.text = userManager.dices.ToString() + " x";
    }
    public void ChangePlaysCount()
    {
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        PlayCount.text = "x " + PlayerPrefs.GetInt("PlayerPlays").ToString();
        PlayCount.text = "x " + userManager.plays.ToString();
    }
    public void GoToGame()
    {
        if (userManager.plays > 0)
        {
            userManager.plays--;
            PlayerPrefs.SetInt("UserPlays", userManager.plays);
            ChangePlaysCount();
            if (principalMenuParentObject.activeSelf)
                principalMenuParentObject.SetActive(false);
            gameParentObject.SetActive(true);
            
        }
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
        ChangeDiceCount();
        ChangePlaysCount();
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
        AudioSource audioSource = GetComponent<AudioSource>();
        //if(UserManager.soundOn == 1)
            //audioSource.Play();
        GoBackToMenu();
    }
}
