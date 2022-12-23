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
            //LimtTime �̰� �������� �ð�.
            //�������ϴ°� �ð��� �������°� �������Ѵ�. �̼ǿ����� Ÿ�� ���� �����͸� �����´�.
            LimitTime += Time.deltaTime;
            text_Timer.text = "STAGE " + (GameManager.instance.sceneNum + 1) + " Time: " + Mathf.Round(LimitTime);
        }
    }
}
