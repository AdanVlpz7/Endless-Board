using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject gainAchievement;
    public int id;
    private void Start()
    {

    }
    private void OnEnable()
    {
        UserManager userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        if (userManager.achievements.Contains(id))
        {
            ChangingSprite();
        }
    }
    private void ChangingSprite()
    {
        this.GetComponent<Image>().sprite = sprites[1];
        GetComponentInChildren<Text>().color = Color.blue;
        gainAchievement.SetActive(true);
    }
}
