using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondUIScript : MonoBehaviour
{
    public Canvas secondCanvas;
    public void ShowSecondUI()
    {

        if (secondCanvas.scaleFactor == 1) secondCanvas.scaleFactor = 0.01f;
        else secondCanvas.scaleFactor = 1;
    }
}
