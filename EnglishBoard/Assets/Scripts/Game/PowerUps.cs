using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerUps : MonoBehaviour
{
    public GameObject imageChild;
    public Sprite[] powerUps;
    public int randomIndex;
    [Tooltip("this is the speed of the basket which will scale up")] public float translationSpeed;
    Vector2 origin;
    private Vector2 pos1 = new Vector2(-210, 0);
    private Vector2 pos2 = new Vector2(210, 0);
    private int maxRange = 3;
    public int random;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        //switch sprite
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        if (gameManager.canSpawnPlay)
            maxRange = 4;
        else
            maxRange = 3;
        randomIndex = Random.Range(0, maxRange);
        imageChild.GetComponent<Image>().sprite = powerUps[randomIndex];
        //switch velocity
        
        switch (random)
        {
            case 0:
                this.translationSpeed = .35f;
                break;
            case 1:
                this.translationSpeed = .25f;
                break;
            case 2:
                this.translationSpeed = .10f;
                break;
            case 3:
                this.translationSpeed = .15f;
                break;
            case 4:
                this.translationSpeed = .45f;
                break;
            case 5:
                this.translationSpeed = .275f;
                break;
            case 6:
                this.translationSpeed = .25f;
                break;
            case 7:
                this.translationSpeed = .20f;
                break;
            case 8:
                this.translationSpeed = .50f;
                break;
            case 9:
                this.translationSpeed = .40f;
                break;
            case 10:
                this.translationSpeed = .30f;
                break;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector2.Lerp(pos1 + origin, pos2 + origin, Mathf.PingPong(translationSpeed * Time.time, 1.0f));
        //LerpMovement(this.transform,origin,this.translationSpeed);
    
    }
    public void LerpMovement(Transform transformToMove, Vector2 origin, float translationSpeed)
    {
        pos1 = new Vector2(-210, 0);
        pos2 = new Vector2(210, 0);
        transformToMove.position = Vector2.Lerp(pos1 + origin, pos2 + origin, Mathf.PingPong(translationSpeed * Time.time, 1.0f));
    }
    
}
