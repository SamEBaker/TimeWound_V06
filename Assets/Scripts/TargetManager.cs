 using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetManager : MonoBehaviour
{

    public GameObject[] targets;
    public PressurePlateManager pm;

    public void Start()
    {
    }
    public void ClearAll()
    {
        for(int i = 0; i <= 15; i++)
        {
            targets[i].GetComponent<Targets>().Clear();
        }
        pm.DoorOpened = false;
        pm.ClearAll();
    }
}
