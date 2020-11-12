using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultFT : MonoBehaviour
{
    public UnityEngine.UI.InputField secondInput;
    GameObject fDoor;
    void Start()
    {
        fDoor = GameObject.FindWithTag("FreezerDoor");

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
        if (secondInput.text!="")
        if (IsDigitsOnly(secondInput.text))
        {
            fDoor.GetComponent<FreezerTemperatureScript>().defaultTemperature = int.Parse(secondInput.text);
            fDoor.GetComponent<FreezerTemperatureScript>().factTemperature = int.Parse(secondInput.text);
        }
        else
        {
            fDoor.GetComponent<FreezerTemperatureScript>().defaultTemperature = -273;
            fDoor.GetComponent<FreezerTemperatureScript>().factTemperature = -273;
        }
    }
}
