using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodToRefregiratorScript : MonoBehaviour
{
    GameObject rDoor;
    public UnityEngine.UI.InputField foodWeight;
    void Start()
    {
        rDoor = GameObject.FindWithTag("Door");
    }
    bool IsDigitsOnly(string str)
    {
        if (str == "") return false;
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }
    public void FoodToRef()
    {
        if (IsDigitsOnly(foodWeight.text))
        rDoor.GetComponent<RefregiratorTemperatureScript>().factTemperature +=int.Parse(foodWeight.text);
    }
}
