using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    [SerializeField] private GameObject GainBtn;
    [SerializeField] private GameObject UseBtn;
    [SerializeField] private int price;
    [SerializeField] private int id;
    [SerializeField] private UserManager userManager;
    [SerializeField] private bool skin;
    public bool canUse = false;
    // Start is called before the first frame update
    void Start()
    {
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        this.GetComponent<Button>().onClick.AddListener(UpdateBtn);
        
        //userManager.Save(0);
        if (skin)
        {
            if (userManager.skinBought.Contains(id))
            {
                OnEnableIfBought();
            }
            else
                UseBtn.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            if (userManager.diceBought.Contains(id))
            {
                OnEnableIfBought();
            }
            else
                UseBtn.GetComponent<Image>().color = Color.gray;
        }

    }
    private void Awake()
    {
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        if (userManager.skinBought.Contains(id))
        {
            OnEnableIfBought();
        }
    }
    public void UpdateBtn()
    {
        if (userManager.coins > price)
        {
            UseBtn.GetComponent<Image>().color = Color.white;
            this.gameObject.SetActive(false);
            GainBtn.SetActive(true);
            userManager.UpdateAfterBuying(price, id,skin);
            //userManager.ballArrayAdded.Add(id);
            userManager.Save();
        }
    }

    public void OnEnableIfBought()
    {
        this.gameObject.SetActive(false);
        GainBtn.SetActive(true);
        UseBtn.GetComponent<Image>().color = Color.white;
        
    }
}