using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource audioData;
    GameObject Siren;
    public int counter;
    public bool isPlaying;
    void Start()
    {
        isPlaying = false;
        Siren = GameObject.FindWithTag("Siren");
        InvokeRepeating("DoScream", 0, 0.05f);
    }


    public void DoScream()
    {
        if (Siren.GetComponent<SirenScript>().needSiren)
        {
            if (!isPlaying)
            {
                audioData = GetComponent<AudioSource>();
                audioData.Play();
                isPlaying = true;
            }
            else
            {
                if (counter >= 100)
                {
                    counter = 0;
                    isPlaying = false;
                }
                else
                    counter++;
            }
        }
        else
        {
            counter = 0;
            isPlaying = false;
            audioData = GetComponent<AudioSource>();
            audioData.Stop();
        }
    }
}
