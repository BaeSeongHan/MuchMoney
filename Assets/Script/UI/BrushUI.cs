using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUI : MonoBehaviour
{
    public GameObject brushView; //�귯�� ���� UI ���� ��

    public void ClickBrushUI()
    {
        brushView.SetActive(!brushView.activeSelf);
    }

    public void OtherUI()
    {
        if (brushView.activeSelf == true)
        {
            brushView.SetActive(false);
        }
    }
}
