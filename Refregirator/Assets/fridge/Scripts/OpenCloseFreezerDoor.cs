using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseFreezerDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isClosed;
    public void OpenCloseFDoor()
    {
        GameObject Lock = GameObject.FindWithTag("Lock");
        if (!Lock.GetComponent<LockBehavior>().isLocked)
        {
            GameObject Dor = GameObject.FindWithTag("FreezerDoor");
            Animator anim = Dor.GetComponent<Animator>();
            anim.SetTrigger("OpenCloseFreezer");
            if (isClosed == false)
            {
                isClosed = true;
            }
            else
            {
                isClosed = false;
            }
        }
    }
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
