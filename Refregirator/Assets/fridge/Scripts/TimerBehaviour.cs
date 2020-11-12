using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    public int minutes;
    public int seconds;
    public bool isNightTime;
    public UnityEngine.UI.Text Timer;
    public UnityEngine.UI.Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 12;
        seconds = 0;
        isNightTime = false;
        Timer.text = minutes + ":00";
        InvokeRepeating("ShowTime", 0,2f);
    }

    public void ShowTime()
    {
        if (minutes < 24)
        {
            if (seconds < 59)
            {
                seconds += 1;
            }
            else
            {
                if (minutes < 23)
                    minutes += 1;
                else minutes = 0;
                seconds = 0;
            }
        }
        else
        {
            seconds = 0;
            minutes = 0;
        }
        if (seconds >= 10 && minutes >= 10)
            Timer.text = minutes + ":" + seconds;
        else if (seconds < 10 && minutes >= 10) Timer.text = minutes + ":0" + seconds;
        else if (minutes < 10 && seconds >= 10) Timer.text = "0" + minutes + ":" + seconds;
        else Timer.text = "0" + minutes + ":0" + seconds;
        if (minutes >= 0 && minutes <= 6) isNightTime = true;
        else isNightTime = false;
    }
    public void ChangeTime()
    {
        minutes = (int)(scrollbar.value * 24);
    }

}
