using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
