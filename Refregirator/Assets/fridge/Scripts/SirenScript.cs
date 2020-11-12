using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenScript : MonoBehaviour
{
    GameObject fDoor;
    GameObject rDoor;
    public Light Siren;
    public bool needSiren;
    public bool goOn;
    void Start()
    {
        goOn = true;
        needSiren = false;
        fDoor = GameObject.FindWithTag("FreezerDoor");
        rDoor = GameObject.FindWithTag("Door");
        InvokeRepeating("DoSiren", 0, 0.05f);
    }

    void Update()
    {
        if (rDoor.GetComponent<RefregiratorTemperatureScript>().isInNeedInAlarm || fDoor.GetComponent<FreezerTemperatureScript>().isInNeedInAlarm)
        {
            needSiren = true;
        }
        else
        {
            needSiren = false;
        }
    }
    public void DoSiren()
    {
        if (needSiren)
        {
            //if (!IsPlaying)
            //{
            //    audioData = GetComponent<AudioSource>();
            //    audioData.Play();
            //    IsPlaying = true;
            //}
            

            if (goOn)
            {
                if (Siren.range <= 1) Siren.range += 0.1f;
                else goOn = false;
            }
            else
            {
                if (Siren.range > 0) Siren.range -= 0.1f;
                else goOn = true;
            }
        }  
        else
        {
            Siren.range = 0;
        }
            
    }
}
