using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMainDoor : MonoBehaviour
{
    public bool isClosed;
    public void OpenCloseMDoor()
    {
        GameObject Lock = GameObject.FindWithTag("Lock");
        if (!Lock.GetComponent<LockBehavior>().isLocked)
        {
            GameObject Dor = GameObject.FindWithTag("Door");
            Animator anim = Dor.GetComponent<Animator>();
            anim.SetTrigger("OpenClose");
            if (isClosed == false) isClosed = true;
            else isClosed = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
