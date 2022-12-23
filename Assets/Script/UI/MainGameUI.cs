using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    TextMeshProUGUI[] resourceText; //텍스트 가져올거

    private void Start()
    {
        
        for (int i = 0; i < resourceText.Length; i++)
        {
            if (GameManager.instance.stageData.Stage[i] == 0)
            {
                resourceText[i + 1] = GetComponent<TextMeshProUGUI>();
                resourceText[i + 1].text = "";
            }
        }
    }

    private void Update()
    {
        
    }
}
