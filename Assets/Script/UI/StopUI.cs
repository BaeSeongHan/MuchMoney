using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopUI : MonoBehaviour
{
    //시간을 멈추고 메뉴창 띄우기

    public GameObject nenuUI;
    public GameObject optionUI;

    public void NenuUIOpen()
    {
        nenuUI.SetActive(true);

        GameManager.instance.IsPause = true;
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    public void NenuUIClose()
    {
        nenuUI.SetActive(false);

        GameManager.instance.IsPause = false;
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }

    public void OptionOpen()
    {
        optionUI.SetActive(true);
        nenuUI.SetActive(false);
    }

    public void OptionClose()
    {
        optionUI.SetActive(false);
        nenuUI.SetActive(true);
    }
}
