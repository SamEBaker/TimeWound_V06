 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegDoorUnlock : MonoBehaviour
{
    public GameObject LockedDoor;
    public GameObject openPos;

    public void OnUnlocked()
    {
        LockedDoor.transform.position = openPos.transform.position;
    }
    
} 
    