using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideFirstInput : MonoBehaviour
{
    public UnityEngine.UI.InputField firstInput;
    public Image myImage;
    public Color tempColor;

    void Start()
    {
        myImage = firstInput.GetComponent<Image>();
        tempColor = myImage.color;
        tempColor.a = 0f;
        myImage.color = tempColor;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            tempColor.a = 0f;
            myImage.color = tempColor;
            Time.timeScale = 1.0f;
        }
    }
    public void ChangeVisible()
    {
        if (tempColor.a == 0f)
        {
            firstInput.text = "";
            tempColor.a = 1f;
            myImage.color = tempColor;
            Time.timeScale = 0.0f;
        }
        else
        {
            tempColor = myImage.color;
            tempColor.a = 0f;
            myImage.color = tempColor;
            Time.timeScale = 1.0f;
        }
        
    }
}
