using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUps : MonoBehaviour
{
    public GameObject imageChild;
    public Sprite[] powerUps;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, 3);
        imageChild.GetComponent<Image>().sprite = powerUps[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //moverlo
        this.transform.Translate(Vector3.down);
    }

}
