using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehavior : MonoBehaviour
{
    public Sprite RedLock;
    public Sprite BlueLock;
    public SpriteRenderer spriteRenderer;
    public bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        isLocked = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void ChangeLockedStatement()
    {
        if (isLocked)
        {
            GameObject timer = GameObject.FindWithTag("Timer");
            if (!timer.GetComponent<TimerBehaviour>().isNightTime)
            {

                    spriteRenderer.sprite = BlueLock;
                    isLocked = false;
                
            }
        }
        else
        {
            GameObject door = GameObject.FindWithTag("Door");
            GameObject freezer = GameObject.FindWithTag("FreezerDoor");
            if (door.GetComponent<OpenCloseMainDoor>().isClosed && freezer.GetComponent<OpenCloseFreezerDoor>().isClosed)
            {
                spriteRenderer.sprite = RedLock;
                isLocked = true;
            }
        }
    }
}
