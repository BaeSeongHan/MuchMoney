using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public GameObject player; //캐릭터 받아올거
    public GameObject[] monster; //몬스터 받아올거

    public GameObject[] moveBlock;

    public GameObject[] All;

    public bool isTrue = false; //눌러졌는지 아닌지
    public bool isSoundTrue = false;

    public int nowMonster = 0;

    Renderer buttonColor;

    Color nomalColor; //원래색

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        monster = GameObject.FindGameObjectsWithTag("Monster");
        moveBlock = GameObject.FindGameObjectsWithTag("aa");

        All = FindObjectsOfType<GameObject>();

        buttonColor = gameObject.GetComponent<Renderer>();
        nomalColor = buttonColor.material.color;
    }


    public bool ISTRUE()
    {
        for (int i = 0; i < All.Length; i++)
        {
            if (All[i] != null)
            {
                if (All[i].GetComponent<ObjCode>() == true)
                {
                    if (All[i].GetComponent<ObjCode>().objStatus == 4 || All[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        if (All[i].transform.position.x == transform.position.x && All[i].transform.position.z == transform.position.z)
                        {
                            isTrue = true;
                            break;
                        }
                        else if (Mathf.Abs(All[i].transform.position.x - transform.position.x) >= 1 || Mathf.Abs(All[i].transform.position.z - transform.position.z) >= 1)
                        {

                            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1 && Mathf.Abs(transform.position.z - player.transform.position.z) < 1)
                            {
                                isTrue = true;
                                break;
                            }


                            isTrue = false;
                        }
                    }
                }
            }
        }

        return isTrue;
    }

    private void Update()
    {
        if (player != null)
        {
            if (ISTRUE())
            {
                buttonColor.material.color = Color.red;
                isTrue = true;
                if (isSoundTrue == false)
                {
                    GameManager.instance.soundManager.EffectsSound(5);
                    isSoundTrue = true;
                }
               
            }
            else if (!ISTRUE())
            {
                if (transform.position.x == player.transform.position.x && transform.position.z == player.transform.position.z)
                {
                    buttonColor.material.color = Color.red;
                    isTrue = true;

                    if (isSoundTrue == false)
                    {
                        GameManager.instance.soundManager.EffectsSound(5);
                        isSoundTrue = true;
                    }

                }
                else if(Mathf.Abs(transform.position.x - player.transform.position.x) >=1 || Mathf.Abs(transform.position.z - player.transform.position.z) >= 1)
                {
                    buttonColor.material.color = nomalColor;
                    isTrue = false;

                    if (isSoundTrue)
                    {
                        isSoundTrue = false;
                    }
                }
            }
        }




        /*
        if (player != null && monster != null)
        {
            for (int i = 0; i < monster.Length; i++)
            {
                if (monster[i] != null)
                {
                   // Debug.Log("이거 왜 실행안댐");

                    //켜진상태
                    if ((transform.position.x == monster[i].transform.position.x && transform.position.z == monster[i].transform.position.z) || (transform.position.x == player.transform.position.x && transform.position.z == player.transform.position.z))
                    {
                        buttonColor.material.color = Color.red;
                        isTrue = true;


                        break;
                    }

                    if (i == monster.Length - 1)
                    {

                        buttonColor.material.color = nomalColor;
                        isTrue = false;
                    }
                }
                else if (monster[i] == null)
                {
                    if (transform.position.x == player.transform.position.x && transform.position.z == player.transform.position.z)
                    {

                        buttonColor.material.color = Color.red;
                        isTrue = true;
                    }
                    else
                    {

                        buttonColor.material.color = nomalColor;
                        isTrue = false;
                    }
                }
            }
        }

        if (moveBlock != null)
        {
            for (int i = 0; i < moveBlock.Length; i++)
            {
                if (moveBlock[i] != null)
                {
                    if (moveBlock[i].GetComponent<ObjCode>().objStatus == 4)
                    {
                        if (moveBlock[i].transform.position.x == transform.position.x && moveBlock[i].transform.position.z == transform.position.z)
                        {
                            buttonColor.material.color = Color.red;
                            isTrue = true;
                        }
                        else
                        {
                            buttonColor.material.color = nomalColor;
                            isTrue = false;
                        }
                    }
                }
            }
        }

        //플레이어 캐릭터만 있거나 몬스터가 있다가 사라졌을때
        if (player != null && monster.Length == 0)
        {
            if (transform.position.x == player.transform.position.x && transform.position.z == player.transform.position.z)
            {

                buttonColor.material.color = Color.red;
                isTrue = true;
            }
            else
            { 

                buttonColor.material.color = nomalColor;
                isTrue = false;
            }
        }*/

    }
}
