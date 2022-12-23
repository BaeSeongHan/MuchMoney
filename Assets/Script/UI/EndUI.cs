using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    public Sprite y_Star;
    public Sprite b_Star;

    public Image[] Star = new Image[3]; //현재 별

    public GameObject misson; //미션 가져올 오브젝트

    public int[] star = new int[3];
    public int starNum = 0; //획득한 별 수 

    public bool isClear; //클리어 했는지 아닌지 알려주는 변수

    // Start is called before the first frame update
    void Start()
    {
        if (isClear == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (misson.GetComponent<mission>().Star[i].sprite == y_Star)
                {
                    star[i] = 1;
                }
                else
                    star[i] = 0;
            }

            starNum = star[0] + star[1] + star[2];
        }
        else if (isClear == false)
        {
            starNum = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (isClear == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (misson.GetComponent<mission>().Star[i].sprite == y_Star)
                {
                    star[i] = 1;
                }
                else
                    star[i] = 0;
            }
            starNum = star[0] + star[1] + star[2];

            for (int i = 0; i < starNum; i++)
            {
                Star[i].sprite = y_Star;
            }
        }
        else if (isClear == false)
        {
            for (int i = 0; i < starNum; i++)
            {
                Star[i].sprite = y_Star;
            }
        }
       
    }
}
