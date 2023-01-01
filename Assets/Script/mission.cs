using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mission : MonoBehaviour
{
    public Sprite y_Star;
    public Sprite b_Star;

    public Image[] Star = new Image[3]; //���� ��

    public Text missonAction; //�̼� 1 ���� text �ּ�hp
    public Text time_Text; //�̼� 2 ���� text �ð�

    public GameObject M; //MapData ���� ��
    public GameObject C; //ĳ���� ������

    public GameObject T; //�ð� ������ ������Ʈ

    private void Start()
    {
        if (C == null)
        {
            C = GameObject.FindWithTag("Player");
        }

        missonAction.text = "Min HP : " + M.GetComponent<MapManager>().minActionPoint.ToString();
        time_Text.text = "StageClear Time : " + M.GetComponent<MapManager>().limttime.ToString();



        if (C != null)
        {
            Star[0].sprite = y_Star;

            if (M.GetComponent<MapManager>().limttime >= T.GetComponent<Timer>().LimitTime)
            {
                Star[1].sprite = y_Star;
            }
            else
                Star[1].sprite = b_Star;

            if (M.GetComponent<MapManager>().minActionPoint <= C.GetComponent<PlayerMove>().actionPoint)
            {
                Star[2].sprite = y_Star;
            }
            else
                Star[2].sprite = b_Star;
        }
    }

    private void Update()
    {

        if (C != null)
        {
            Star[0].sprite = y_Star;

            if (M.GetComponent<MapManager>().limttime >= T.GetComponent<Timer>().LimitTime)
            {
                Star[1].sprite = y_Star;
            }
            else
                Star[1].sprite = b_Star;

            if (M.GetComponent<MapManager>().minActionPoint <= C.GetComponent<PlayerMove>().actionPoint)
            {
                Star[2].sprite = y_Star;
            }
            else
                Star[2].sprite = b_Star;
        }
    }
}
