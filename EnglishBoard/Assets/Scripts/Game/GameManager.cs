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
    private void OnEnable()
    {
        StartCoroutine(spawningPlatform());
        Instantiate(playerPrefab, new Vector3(Random.Range(0,Screen.width-100),playerSpawner.transform.position.y,0),Quaternion.identity);
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
    private IEnumerator spawningPlatform()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(platformPrefab, platformSpawner.transform);
        StartCoroutine(spawningPlatform());
    }

    public void QuittingGame()
    {

    }
}
