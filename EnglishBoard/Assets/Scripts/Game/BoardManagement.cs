using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public Text[] boardElements;
    private UserManager userManager;
    void Start()
    {
        userManager = GameObject.FindGameObjectWithTag("UserManager").GetComponent<UserManager>();
        RefreshPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshPositions()
    {
        for(int i = 0; i < boardElements.Length; i++)
        {
            int aux = i - 2;
            int aux2 = userManager.boardPosition + aux;
            if (aux2 < 0)
                boardElements[i].text = "";
            else boardElements[i].text = (userManager.boardPosition + aux).ToString();
            
        }
    }
}
