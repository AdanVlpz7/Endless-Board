using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameFinished = false;
    
    public GameObject platformSpawner;
    public GameObject playerSpawner;
    public GameObject platformPrefab;
    public GameObject playerPrefab;
    public GameObject collisionDetector;
    public GameObject playerPlatformSpawner;
    public Transform playerPlatformSpawnerTransform;
    private void OnEnable()
    {
        //Instantiate(platformPrefab, platformSpawner.GetComponent<SpawnerTracker>().spawnPos, Quaternion.identity, platformSpawner.transform);
        StartCoroutine(spawningPlatform());
        Instantiate(playerPrefab, playerSpawner.transform);
        Instantiate(playerPlatformSpawner, playerPlatformSpawnerTransform.position, Quaternion.identity, playerPlatformSpawnerTransform);
        Instantiate(collisionDetector, playerPlatformSpawnerTransform);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
        }

    }
    bool CheckRecord(int record)
    {
        if (record > PlayerPrefs.GetInt("Record"))            
            return true;
        else           
            return false;
    }
    void ChangingRecordTxt(int record)
    {
        //RecordTxt.text = "Your coins was: "+record.ToString();
        //HighRecordTxt.text = "Your highScore is: " + PlayerPrefs.GetInt("Record").ToString();
    }
    int spawningCount = 0;
    public bool canSpawnPlay = false;
    private IEnumerator spawningPlatform()
    {
        if (spawningCount == 6)
        {
            canSpawnPlay = true;
            spawningCount = 0;
        }
        yield return new WaitForSeconds(2.5f);
        canSpawnPlay = false;
        //+ new Vector3(Random.Range(-100,100),0,0)
        //Instantiate(platformPrefab, platformSpawner.GetComponent<SpawnerTracker>().spawnPos,Quaternion.identity,platformSpawner.transform);
        InstanciatingAPlatform();
        spawningCount++;
        StartCoroutine(spawningPlatform());
    }
    int temp = 10;
    public void InstanciatingAPlatform()
    {
        GameObject platformClone = Instantiate(platformPrefab, platformSpawner.GetComponent<SpawnerTracker>().spawnPos, Quaternion.identity, platformSpawner.transform);
        platformClone.GetComponent<PowerUps>().random = RandomInt();
        //return 0;
    }
    private int RandomInt()
    {
        int index = Random.Range(0,10);
        if (index == temp)
        {
            index++;
            if (index == 10)
                index = 0;
            temp = index;
        }
        else {
            temp = index;
        }
        return temp;
    }
    public void QuittingGame()
    {
        GameObject playerClone = GameObject.FindGameObjectWithTag("Player");
        Destroy(playerClone);
        GameObject[] platformClones = GameObject.FindGameObjectsWithTag("Platform");
        for (int i = 0; i < platformClones.Length; i++)
        {
            Destroy(platformClones[i]);
        }
        GameObject collisioner = GameObject.FindGameObjectWithTag("Finish");
        Destroy(collisioner);
    }
}
