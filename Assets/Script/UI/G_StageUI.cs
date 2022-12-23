using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_StageUI : MonoBehaviour
{
    public GameObject M_UI;
    public GameObject C_UI;


    public void stateM_UI()
    {
        if(M_UI.activeSelf == false)
        {
            M_UI.SetActive(true);
        }
        else if (M_UI.activeSelf == true)
        {
            M_UI.SetActive(false);
        } 
    }


    public void stateC_UI()
    {
        if (C_UI.activeSelf == false)
        {
            C_UI.SetActive(true);
        }
        else if (C_UI.activeSelf == true)
        {
            C_UI.SetActive(false);
        }
    }
}
