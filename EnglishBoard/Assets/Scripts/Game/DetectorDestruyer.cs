using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDestruyer : MonoBehaviour
{
    public UIManager uimanager;
    public AudioSource audioSource;
    public BetterJump betterJump;
    private void Start()
    {
        betterJump = GameObject.FindGameObjectWithTag("Player").GetComponent<BetterJump>();
    }
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        uimanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        //betterJump = GameObject.FindGameObjectWithTag("Player").GetComponent<BetterJump>();
    }
    private void Update()
    {
        //if (betterJump.jumping)
        //{
            this.transform.Translate(Vector3.up * 0.1f);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FinishGame());
            
        }
        if(!collision.gameObject.CompareTag("Bg"))
            Destroy(collision.gameObject);
        //else
            //betterJump = GameObject.FindGameObjectWithTag("Player").GetComponent<BetterJump>();
    }
    IEnumerator FinishGame()
    {
        if (UserManager.soundOn == 1)
            audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameManager.QuittingGame();
        uimanager.GoBackToMenu();
    }
}
