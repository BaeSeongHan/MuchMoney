using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_obj : MonoBehaviour
{

    public GameObject[] wall; //��
    public GameObject[] button; //��ư

    public GameObject[] pothal; //��Ż


    //-------------------------

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.FindGameObjectsWithTag("wall"); //��� �� ������Ʈ ��������       
        button = GameObject.FindGameObjectsWithTag("button"); //��� ��ư ������Ʈ ��������
        pothal = GameObject.FindGameObjectsWithTag("goal");  //��� ��Ż ������Ʈ ��������


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
                            //�ϳ��� �ȴ������ִ�.
                        }
                    }
                }
            }
            //��ư���ȴ��� �ƴ��� �Ǵ�


            //���δ� ������ ������
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

                //������Ʈ Ű��
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
                //������Ʈ Ű��
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
                                //�������ִ�.
                                asdf = true;
                            }
                            else
                            {
                                asdf = false;
                                break;
                                //�ϳ��� �ȴ������ִ�.
                            }
                        }
                    }
                }

                if (asdf) //������ �Ǿ��ְ� �������ִ�.
                {
                    //������Ʈ�� ��������� �ݴ�� ����
                    if (pothal[i].GetComponent<ObjCode>().obj_Connection == 0)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = false;
                    }
                    else if (pothal[i].GetComponent<ObjCode>().obj_Connection == 1)
                    {
                        pothal[i].GetComponent<PortalObj>().isTrue = true;
                    }
                }
                else if (!asdf) //������ �ȵǾ� �ְų� �ϳ��� �ȴ������ִ�.
                {
                    //������Ʈ�� ���� ���� �״�� ����
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
