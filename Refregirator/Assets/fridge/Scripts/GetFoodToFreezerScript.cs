using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodToFreezerScript : MonoBehaviour
{
    GameObject fDoor;
    public UnityEngine.UI.InputField foodWeight;
    // Start is called before the first frame update
    void Start()
    {
        fDoor = GameObject.FindWithTag("FreezerDoor");
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
    public void FoodToFreezer()
    {
        if (IsDigitsOnly(foodWeight.text))
        fDoor.GetComponent<FreezerTemperatureScript>().factTemperature += int.Parse(foodWeight.text);
    }
}
