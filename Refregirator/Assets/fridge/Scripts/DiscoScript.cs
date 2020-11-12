using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoScript : MonoBehaviour
{
    public Light light;
    public Color randomColor;
    public Color lightColor;
    public bool NeedToChangeColor;
    void Start()
    {
        lightColor = light.color;
        NeedToChangeColor = true;
        InvokeRepeating("GetRandomColor", 0, 0.05f);
        InvokeRepeating("ChangeToRandomColor", 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetRandomColor()
    {
        if (NeedToChangeColor)
        {
            randomColor.b = 1;
            randomColor.g = 1;
            randomColor.r = 1;
            while (randomColor.b + randomColor.g + randomColor.r >= 1.8f)
            {
                randomColor.b = Random.Range(0.0f, 1.0f);
                randomColor.g = Random.Range(0.0f, 1.0f);
                randomColor.r = Random.Range(0.0f, 1.0f);
                Debug.Log("Рандом не прошел");
            }
            NeedToChangeColor = false;
        }
    }
    public void ChangeToRandomColor()
    {
        if (lightColor.r != randomColor.r || lightColor.b != randomColor.b || lightColor.g != randomColor.g)
        {
            if (Mathf.Abs(lightColor.r  - randomColor.r) <=0.005f)
            {
                lightColor.r = randomColor.r;
            }
            else
            {
                if (lightColor.r <randomColor.r)
                {
                    Debug.Log("r +");
                    lightColor.r += 0.005f;
                }
                else
                {
                    lightColor.r -= 0.005f;
                    Debug.Log("r -");
                }
            }
            if (Mathf.Abs(lightColor.g - randomColor.g) <= 0.005f)
            {
                lightColor.g = randomColor.g;
            }
            else
            {
                if (lightColor.g < randomColor.g)
                {
                    lightColor.g += 0.005f;
                }
                else
                {
                    lightColor.g -= 0.005f;
                }
            }
            if (Mathf.Abs(lightColor.b - randomColor.b) <= 0.005f)
            {
                lightColor.b = randomColor.b;
            }
            else
            {
                if (lightColor.b < randomColor.b)
                {
                    lightColor.b += 0.005f;
                }
                else
                {
                    lightColor.b -= 0.005f;
                }
                
            }
            light.color = lightColor;
        }
        else
        {
            NeedToChangeColor = true;
        }
    }
}
