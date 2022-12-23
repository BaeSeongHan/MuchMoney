using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_obj : MonoBehaviour
{

    public GameObject[] wall; //벽
    public GameObject[] button; //버튼

    public GameObject[] pothal; //포탈


    //-------------------------

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.FindGameObjectsWithTag("wall"); //모든 벽 오브젝트 가져오기       
        button = GameObject.FindGameObjectsWithTag("button"); //모든 버튼 오브젝트 가져오기
        pothal = GameObject.FindGameObjectsWithTag("goal");  //모든 포탈 오브젝트 가져오기


    }

    // Update is called once per frame
    void Update()
    {
        b1_Check();
        b2_Check();
    }



    public void b1_Check()
    {
        for (int i = 0; i < wall.Length; i++)
        {
            bool asdf = false;

            for (int j = 0; j < button.Length; j++)
            {
                if (button[j].transform.parent.GetComponent<ObjCode>().obj_Connection == 0)
                {
                    if (wall[i].transform.GetChild(0).GetComponent<ObjCode>().obj_Connection_It == button[j].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                    {
                        if (button[j].GetComponent<Obj>().isTrue == true)
                        {
                            asdf = true;
                        }
                        else
                        {
                            asdf = false;
                            break;
                            //하나라도 안눌러져있다.
                        }
                    }
                }
            }
            //버튼눌렸는지 아닌지 판단


            //전부다 눌러져 있으면
            if (asdf)
            {
                if (wall[i].gameObject.GetComponent<ActivateObj>().isTrue == true)
                {
                    wall[i].gameObject.transform.localScale = new Vector3(wall[i].GetComponent<ActivateObj>().size.x, 0.01f, wall[i].GetComponent<ActivateObj>().size.z);
                    wall[i].gameObject.GetComponent<ActivateObj>().isObj = false;
                }
                else if (wall[i].gameObject.GetComponent<ActivateObj>().isTrue == false)
                {
                    wall[i].gameObject.transform.localScale = new Vector3(wall[i].GetComponent<ActivateObj>().size.x, wall[i].GetComponent<ActivateObj>().size.y, wall[i].GetComponent<ActivateObj>().size.z);
                    wall[i].gameObject.GetComponent<ActivateObj>().isObj = true;

                }

                //오브젝트 키기
                //wall[i].gameObject.SetActive(false);
            }
            else if (!asdf)
            {
                if (wall[i].gameObject.GetComponent<ActivateObj>().isTrue == true)
                {
                    wall[i].gameObject.transform.localScale = new Vector3(wall[i].GetComponent<ActivateObj>().size.x, wall[i].GetComponent<ActivateObj>().size.y, wall[i].GetComponent<ActivateObj>().size.z);
                    wall[i].gameObject.GetComponent<ActivateObj>().isObj = true;

                }
                else if (wall[i].gameObject.GetComponent<ActivateObj>().isTrue == false)
                {
                    wall[i].gameObject.transform.localScale = new Vector3(wall[i].GetComponent<ActivateObj>().size.x, 0.01f, wall[i].GetComponent<ActivateObj>().size.z);
                    wall[i].gameObject.GetComponent<ActivateObj>().isObj = false;
                }
                //오브젝트 키기
                //wall[i].gameObject.SetActive(true);
            }

        }
    }

    public void b2_Check()
    {
        for (int i = 0; i < pothal.Length; i++)
        {
            if (pothal[i] != null && pothal[i].GetComponent<ObjCode>().obj_State == 6)
            {
                bool asdf = false;

                for (int j = 0; j < button.Length; j++)
                {
                    if (button[j].transform.parent.GetComponent<ObjCode>().obj_Connection == 1)
                    {
                        if (pothal[i].GetComponent<ObjCode>().obj_Connection_It == button[j].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                        {
                            if (button[j].GetComponent<Obj>().isTrue == true)
                            {
                                //눌러져있다.
                                asdf = true;
                            }
                            else
                            {
                                asdf = false;
                                break;
                                //하나라도 안눌러져있다.
                            }
                        }
                    }
                }

                if (asdf) //연결이 되어있고 눌러져있다.
                {
                    //오브젝트를 현재상태의 반대로 설정
                    if (pothal[i].GetComponent<ObjCode>().obj_Connection == 0)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = false;
                    }
                    else if (pothal[i].GetComponent<ObjCode>().obj_Connection == 1)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = true;
                    }
                }
                else if (!asdf) //연결이 안되어 있거나 하나라도 안눌러져있다.
                {
                    //오브젝트를 현재 상태 그대로 설정
                    if (pothal[i].GetComponent<ObjCode>().obj_Connection == 0)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = true;
                    }
                    else if(pothal[i].GetComponent<ObjCode>().obj_Connection == 1)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = false;
                    }
                }
            }
        }
    }
}
