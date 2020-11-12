using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChanger : MonoBehaviour
{
    private static bool ShowFirstUI = false;
    private static bool ShowSecondUI = false;
    
    public void ShowFirstMenu()
    {
        
        GameObject EnterMenu = GameObject.FindWithTag("MainEnter");
        EnterMenu.transform.localScale = new Vector3(0,0,0);

    }
}
