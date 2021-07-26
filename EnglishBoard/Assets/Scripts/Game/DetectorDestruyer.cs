using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDestruyer : MonoBehaviour
{
    UIManager uimanager;
    AudioSource audioSource;
    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        uimanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(UserManager.soundOn == 1)
                audioSource.Play();
            uimanager.GoBackToMenu();
            Destroy(collision.gameObject);
        }

        Destroy(collision.gameObject);
    }
}
