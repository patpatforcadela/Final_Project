using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    public float time;
    public Text gameOverTime;
    public Text highScoreTime;
    private float seconds, minutes, highMin, highSec;
	// Use this for initialization
	void Start () {
        highMin = PlayerPrefs.GetFloat("highMinute", 0);
        highSec = PlayerPrefs.GetFloat("highSec", 0);
        highScoreTime.text = "Best Time: " + highMin.ToString("00") + ':' + highSec.ToString("00");
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        seconds = (time % 60);
        minutes = ((int)(time / 60) % 60);

        timer.text = minutes.ToString("00") + ':' + seconds.ToString("00");
    }
    public void gameOver()
    {
        gameOverTime.text = "Time: " + minutes.ToString("00") + ':' + seconds.ToString("00");
        if (minutes <= highMin)
        {
            Debug.Log(minutes);
            if (seconds < highSec)
            {
                PlayerPrefs.SetFloat("highMinute", minutes);
                PlayerPrefs.SetFloat("highSec", seconds);
                highScoreTime.text = "Best Time: " + minutes.ToString("00") + ':' + seconds.ToString("00");
            }
        }
    }
}
