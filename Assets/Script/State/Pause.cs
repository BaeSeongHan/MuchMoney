using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
   public void PUS()
    {
        if (GameManager.instance.IsPause)
        {
            Debug.Log("다시 시작");
            Time.timeScale = 1;
            Debug.Log(Time.timeScale);
            GameManager.instance.IsPause = false;
            return;
        }
    }
}
