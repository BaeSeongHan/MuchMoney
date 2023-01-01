using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.sceneNum > 11)
        {
            LimitTime += Time.deltaTime;
            text_Timer.text = "CUSTOM STAGE " + (GameManager.instance.sceneNum + 1 - 12) + " Time: " + Mathf.Round(LimitTime);
        }
        else
        {
            //LimtTime 이게 보여지는 시간.
            //만들어야하는건 시간이 지나가는걸 만들어야한다. 미션에서는 타임 관련 데이터를 가져온다.
            LimitTime += Time.deltaTime;
            text_Timer.text = "STAGE " + (GameManager.instance.sceneNum + 1) + " Time: " + Mathf.Round(LimitTime);
        }
    }
}
