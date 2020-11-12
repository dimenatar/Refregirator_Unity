using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUIScript : MonoBehaviour
{
    public Canvas firstCanvas;
    public void ShowFirstUI()
    {

        if (firstCanvas.scaleFactor == 1) firstCanvas.scaleFactor = 0.01f;
        else firstCanvas.scaleFactor = 1;
    }
}
