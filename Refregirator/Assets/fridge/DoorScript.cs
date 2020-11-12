using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    GameObject Dor;
    Animator anim;
    public void SukaBlyatZaebaloVse()
    {
        Dor = GameObject.FindWithTag("Door");
        anim = Dor.GetComponent<Animator>();
        anim.SetTrigger("OpenClose");
    }
}
