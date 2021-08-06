using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTracker : MonoBehaviour
{
    public Vector3 spawnPos;
    private void Start()
    {
        spawnPos = this.transform.position;
        //StartCoroutine(advanceSpawner());
        
    }
    private void OnEnable()
    {
        spawnPos = this.transform.position;
        StartCoroutine(advanceSpawner());
    }

    IEnumerator advanceSpawner()
    {
        yield return new WaitForSeconds(1.5f);
        spawnPos += Vector3.up * 200;
        if(!GameManager.GameFinished)
            StartCoroutine(advanceSpawner());

    }
}
