using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRecord : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (UserManager.soundOn == 1)
            audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
