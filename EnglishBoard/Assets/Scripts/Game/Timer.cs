using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("initial time in seconds")] public int initialTime;

    [Tooltip("time scale of the clockE")] [Range(-10f, 10f)] public float timeScale = 1;
    [Tooltip("Text label where the chronometer works")] public Text myText;
    public bool pause = false;
    public UIManager uimanager;

    private float frameTimeOnScaleTime = 0f;
    public float timeToShowInSeconds = 60f;
    public int minutes = 0; //the int value of the minutes
    public int seconds = 0;//the int value of the seconds
    //variables used to resume the game after the pause
    private float scaleTimeBeforePause, initialScaleTime = 1;
    public bool timeIsFinished;
    // Start is called before the first frame update
    void OnEnable()
    {
        uimanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        myText = GetComponent<Text>();
        myText.text = "1:00";
        timeToShowInSeconds = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        frameTimeOnScaleTime = Time.deltaTime * timeScale;

        timeToShowInSeconds -= frameTimeOnScaleTime;

        refreshClock(timeToShowInSeconds);
    }
    public void refreshClock(float timeInSeconds)
    {
        string textoDelReloj;

        if (timeInSeconds < 0) timeInSeconds = 0;//we CAN´T have negative time
        
        //this is the calculos of the minutes and seconds accord the seconds we are working with
        minutes = (int)timeInSeconds / 60;
        seconds = (int)timeInSeconds % 60;
        if (minutes == 0 && seconds == 0)
        {
            GameManager.GameFinished = true;
            
            GameObject playerClone = GameObject.FindGameObjectWithTag("Player");
            Destroy(playerClone);
            GameObject[] platformClones = GameObject.FindGameObjectsWithTag("Platform");
            for(int i = 0; i < platformClones.Length; i++)
            {
                Destroy(platformClones[i]);
            }
            GameObject collisioner = GameObject.FindGameObjectWithTag("Finish");
            Destroy(collisioner);
            uimanager.GoBackToMenu();
        }

        textoDelReloj = minutes.ToString("00") + ":" + seconds.ToString("00"); //refresh the string of the chronometer
        myText.text = textoDelReloj;//we give the string to the text label object
        
    }// W O R K S

    //this method is used when we PAUSE the game with the button
    public void PausedClock()
    {
        if (!pause)
        {
            //
            pause = true;
            scaleTimeBeforePause = timeScale; //se guarda la escala antes de la pausa, para dejarla en 0 despues
            timeScale = 0; // para que no avance el cronometro
        }
    } // W O R K S

    //this method is used when we REPLAY the game when we paused it
    public void ContinueClock()
    {
        if (pause)
        {
            
            pause = false;
            //restart the scale of the clock
            timeScale = scaleTimeBeforePause; //la escala recupera el valor que tenia antes de la pausa

        }
    }// W O R K S

    //this method is used when we QUIT the game
    public void RestartClock()
    {
        pause = false;// if we  just came out of pause, we turn it off the boolean

        //restart the values of the clock
        timeScale = initialScaleTime;
        timeToShowInSeconds = initialTime;
        refreshClock(timeToShowInSeconds);
    } // W O R K S
    private void DissapearingTimerOnPause()
    {
        this.gameObject.SetActive(false);
        GetComponent<Image>().gameObject.SetActive(false);
        GetComponentInParent<Image>().gameObject.SetActive(false);
    }
}

