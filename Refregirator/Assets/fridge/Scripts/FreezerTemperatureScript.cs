using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezerTemperatureScript : MonoBehaviour
{
    public double defaultTemperature;
    public double factTemperature;
    public bool isInNeedInAlarm;
    public UnityEngine.UI.Text FTemperature;
    GameObject fDoor;
    // Start is called before the first frame update
    void Start()
    {
        defaultTemperature = -273;
        factTemperature = defaultTemperature;
        isInNeedInAlarm = false;
        fDoor = GameObject.FindWithTag("FreezerDoor");
        InvokeRepeating("Defrosting", 0, 2f);
    }
    public void Defrosting()
    {
        if (!fDoor.GetComponent<OpenCloseFreezerDoor>().isClosed)
        {
            if (factTemperature < 100)
                factTemperature+=2;
        }
        else
        {
            if (factTemperature > defaultTemperature)
            {
                factTemperature -= 0.5;
                Debug.Log(factTemperature);
            }
            else
            {
                factTemperature = defaultTemperature;
            }
        }
        if (factTemperature - defaultTemperature >= 3) isInNeedInAlarm = true;
        else isInNeedInAlarm = false;
        FTemperature.text = "Факт темп морозильника: " + (int)(factTemperature) + "C";
    }
}
