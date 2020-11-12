using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultRT : MonoBehaviour
{

    public UnityEngine.UI.InputField firstInput;
    GameObject rDoor;
    void Start()
    {
        rDoor = GameObject.FindWithTag("Door");

    }
    bool IsDigitsOnly(string str)
    {
        if (str == "") return false;
        foreach (char c in str)
        {
            if ((c < '0' || c > '9') && c != '-')
                return false;
        }

        return true;
    }
    public void SetDefaultTemperature()
    {
        if (IsDigitsOnly(firstInput.text))
        {
            rDoor.GetComponent<RefregiratorTemperatureScript>().defaultTemperature = int.Parse(firstInput.text);
            rDoor.GetComponent<RefregiratorTemperatureScript>().factTemperature = int.Parse(firstInput.text);
        }
        else
        {
            rDoor.GetComponent<RefregiratorTemperatureScript>().defaultTemperature = -273;
            rDoor.GetComponent<RefregiratorTemperatureScript>().factTemperature = -273;
        }
    }
}
