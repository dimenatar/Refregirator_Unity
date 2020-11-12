using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefregiratorTemperatureScript : MonoBehaviour
{
    public double defaultTemperature;
    public double factTemperature;
    public bool isInNeedInAlarm;
    public UnityEngine.UI.Text RTemperature;
    GameObject rDoor;
    // Start is called before the first frame update
    void Start()
    {
        defaultTemperature = -273;
        factTemperature = defaultTemperature;
        isInNeedInAlarm = false;
        rDoor = GameObject.FindWithTag("Door");
        InvokeRepeating("Defrosting", 0, 2f);
    }
    public void Defrosting()
    {
        if (!rDoor.GetComponent<OpenCloseMainDoor>().isClosed)
        {
            if (factTemperature < 100)
                factTemperature++;
        }
        else
        {
            if (factTemperature > defaultTemperature)
            {
                factTemperature -= 0.1;
            }
            else
            {
                factTemperature = defaultTemperature;
            }
        }
        if (factTemperature - defaultTemperature >= 3) isInNeedInAlarm = true;
        else isInNeedInAlarm = false;
        RTemperature.text = "Факт темп холодильника: " + (int)(factTemperature) + "C";
    }
}
