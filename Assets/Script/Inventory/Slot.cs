using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public static Slot instance;

    public bool dragBoll; //드래그 했는지 안했는지 판단

    private void Awake()
    {
        instance = this;
        dragBoll = false;
    }

    

}
