using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite[] playerSkins;
    private UserManager userManager;
    // Start is called before the first frame update
    void Start()
    {
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        this.GetComponent<Image>().sprite = playerSkins[userManager.skinIndexUsed];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
