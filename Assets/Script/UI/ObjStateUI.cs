using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjStateUI : MonoBehaviour
{
    public Slider sizeSlider; //������ �����̴�

    public Text inputSizeText; //�Է��ϴ°� ������ �ؽ�Ʈ
    public Text inputActionText; //�Է��ϴ� �Ҹ� HP �ؽ�Ʈ
    public Text inputMonsterSpeedText; //�Է��ϴ� ���� �ӵ� �ؽ�Ʈ
    public Dropdown inputButtonConnectionDropdown; //�Է��ϴ� ��ư���� ��Ӵٿ�
    public Text inputWhatConnectionText; //�Է��ϴ� ���� text;

    public Toggle activateToggle; //������Ʈ�� �ʱ���°� ��� �˷��ִ� ���

    public Text actionText; //�Ҹ� HP �˷��ִ� �ؽ�Ʈ
    public Text sizeText;
    public Text stateText;
    public Text monsterText;
    public Text buttonText;
    public Text whatconnectionText;

    public GameObject M;

    public enum BUTTONCONNECT
    {
        NUM,
        WALL,
        POTAL
    }

    public BUTTONCONNECT connectmode = BUTTONCONNECT.WALL;

    public void showStateText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    //��ư�� �� ����
                    if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        continue;
                    }
                    //�ϳ��� ��ư�� �ȵ� ����
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().objStatus)
                        {
                            //������Ʈ ���°� ����
                            continue;
                        }
                        else
                        {
                            //������Ʈ ���°� �ٸ���
                            stateText.text = "ObjState: - ";
                            return;
                        }
                    }
                    //�ϳ��� ��ư�� �� ����
                    else
                    {
                        //������Ʈ ���°� �ٸ���
                        stateText.text = "ObjState: - ";
                        return;
                    }

                }
            }
            //�����Ű� ������ �����°� ���°� ��� ���� ������Ʈ��.

            if (M.GetComponent<MapGenerator>().sameobj[0].tag == "button")
            {
                if (M.GetComponent<MapGenerator>().sameobj[0].transform.parent.GetComponent<ObjCode>().objStatus == 8)
                {
                    stateText.text = "ObjState: Button";
                    return;
                }
            }
            else
            {
                if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 4)
                {
                    stateText.text = "ObjState: Move";
                    return;
                }
                else if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 5)
                {
                    stateText.text = "ObjState: Delet";
                    return;
                }
                else if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 6)
                {
                    stateText.text = "ObjState: Monster";
                    return;
                }
                else if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 7)
                {
                    stateText.text = "ObjState: Fix";
                    return;
                }
                else if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 9)
                {
                    stateText.text = "ObjState: Interaction";
                    return;
                }
                else if (M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().objStatus == 0)
                {
                    stateText.text = "ObjState: NULL";
                    return;
                }
            }
        }
    }

    public void showSizeText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Size)
                        {
                            //����� ������
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //����� �ٸ���
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Size)
                        {
                            //����� ������
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //����� �ٸ���
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Size)
                        {
                            //����� ������
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //����� �ٸ���
                        }
                    }
                    else
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Size)
                        {
                            //����� ������
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //����� �ٸ���
                        }
                    }
                }
            }

            //����� ������
            sizeText.text = "ObjSize: " + M.GetComponent<MapGenerator>().objSize_Test.ToString("F2");
            return;
        }
    }
    public void showActionValueText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //�׿��� �͵�
                    actionText.text = "Attack -HP: - ";
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 4 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 5 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //4.����,5.�����̴°�,6.���� ������Ʈ�̸� ����
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        actionText.text = "Attack -HP: - ";
                        return;
                    }
                }                             
            }

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Ack == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Ack)
                    {
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        actionText.text = "Attack -HP: - ";
                        return;
                    }
                }
            }

            actionText.text = "Attack -HP: " + ((int)M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().obj_Ack).ToString();
            return;
        }
    }
    public void showMonsterSpeedText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //�׿��� �͵�
                    monsterText.text = "MonsterSpeed: - ";
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        monsterText.text = "MonsterSpeed: - ";
                        return;
                    }
                }
            }

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().monster_Speed == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().monster_Speed)
                    {
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        monsterText.text = "MonsterSpeed: - ";
                        return;
                    }
                }
            }

            monsterText.text = "MonsterSpeed: " + ((int)M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().monster_Speed).ToString();
            return;
        }
    }
    public void showButtonConnectionText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    continue;
                }
                else
                {
                    //�׿��� �͵�
                    buttonText.text = "Button: - ";
                    return;
                }
            }
            //���⼭ ������ �� ��ư�±׸� ������ �ִ� ������Ʈ��

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Connection)
                    {
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        buttonText.text = "Button: - ";
                        return;
                    }
                }
            }

            if (M.GetComponent<MapGenerator>().sameobj[0].transform.parent.GetComponent<ObjCode>().obj_Connection == 0)
            {
                buttonText.text = "Button: " + "Wall";
                return;
            }
            else if (M.GetComponent<MapGenerator>().sameobj[0].transform.parent.GetComponent<ObjCode>().obj_Connection == 1)
            {
                buttonText.text = "Button: " + "Potal";
                return;
            }
        }
    }
    public void showWhatConnectionText()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    continue;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 9)
                    {
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        whatconnectionText.text = "Connection: - ";
                        return;
                    }  
                }
            }
            //���⼭ ������ ��ư�̰ų� ��ư�� ����Ǵ� ������Ʈ

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection == M.GetComponent<MapGenerator>().sameobj[i+1].transform.parent.GetComponent<ObjCode>().obj_Connection)
                        {
                            if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                            {
                                continue;
                            }
                            else
                            {
                                //�׿��� �͵�
                                whatconnectionText.text = "Connection: - ";
                                return;
                            }
                        }
                        else
                        {
                            //�׿��� �͵�
                            whatconnectionText.text = "Connection: - ";
                            return;
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {

                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Connection_It)
                        {
                            continue;
                        }
                        else
                        {
                            //�׿��� �͵�
                            whatconnectionText.text = "Connection: - ";
                            return;
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i+1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                        {
                            continue;
                        }
                        else
                        {
                            //�׿��� �͵�
                            whatconnectionText.text = "Connection: - ";
                            return;
                        }
                    }
                    else
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Connection_It)
                        {
                            if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_State == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_State)
                            {
                                continue;
                            }
                            else
                            {
                                //�׿��� �͵�
                                whatconnectionText.text = "Connection: - ";
                                return;
                            }
                        }
                        else
                        {
                            //�׿��� �͵�
                            whatconnectionText.text = "Connection: - ";
                            return;
                        }
                    }
                }
            }
            //���⼭ ������ ������ ������Ʈ�� ���� ����� ������Ʈ��


            if (M.GetComponent<MapGenerator>().sameobj[0].tag == "button")
            {
                whatconnectionText.text = "Connection: " + M.GetComponent<MapGenerator>().sameobj[0].transform.parent.GetComponent<ObjCode>().obj_Connection_It;
                return;
            }
            else
            {
                whatconnectionText.text = "Connection: " + M.GetComponent<MapGenerator>().sameobj[0].GetComponent<ObjCode>().obj_Connection_It;
                return;
            }
        }
    }




    public void showToggle()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    activateToggle.gameObject.SetActive(false);
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 9)
                    {
                        continue;
                    }
                    else
                    {
                        activateToggle.gameObject.SetActive(false);
                        return;
                    }
                }
            }
            //���⼭ �����°� ��� �� ��ư�� ����Ǵ� ������Ʈ

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i +1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection == M.GetComponent<MapGenerator>().sameobj[i+1].GetComponent<ObjCode>().obj_Connection)
                    {
                        continue;
                    }
                    else
                    {
                        activateToggle.gameObject.SetActive(false);
                        return;
                    }
                }
            }
            //���⸦ ������ ��� ������Ʈ�� Ȱ��ȭ ���ΰ� ����.

            activateToggle.gameObject.SetActive(true);
        }
    }


    public void ChangeSliderValue()
    {
        sizeSlider.value = float.Parse(inputSizeText.text);
    }
    public void ChangeActionValue()
    {
        //������ �ʿ�
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //�׿��� �͵�
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 4 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 5 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //4.����,5.�����̴°�,6.���� ������Ʈ�̸� ����
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        return;
                    }
                }  
            }
            M.GetComponent<MapGenerator>().action_Obj = float.Parse(inputActionText.text);
            return;
        }
    }
    public void ChangeMonsterSpeedValue()
    {
        //������ �ʿ�
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //�׿��� �͵�
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //6.���� ������Ʈ�̸� ����
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        return;
                    }
                } 
            }
            M.GetComponent<MapGenerator>().monsterspeed_Obj = float.Parse(inputMonsterSpeedText.text);
            return;
        }
    }
    public void ChangeButtenConnectionValue()
    {
        //������ �ʿ�
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().objStatus == 8)
                    {
                        //8.��ư ������Ʈ�� ����
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        return;
                    }
                }
                else
                {
                    //�׿��� �͵�
                    return;
                }
            }

            switch (inputButtonConnectionDropdown.value)
            {
                case 0:
                    connectmode = BUTTONCONNECT.WALL;
                    M.GetComponent<MapGenerator>().connection_Obj = 0;
                    break;
                case 1:
                    connectmode = BUTTONCONNECT.POTAL;
                    M.GetComponent<MapGenerator>().connection_Obj = 1;
                    break;
                default:
                    break;
            }
            
            return;
        }
    }
    public void ChangeWhatConnectionValue()
    {
        //������ �ʿ�
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().objStatus == 8)
                    {
                        //8.��ư ������Ʈ�� ����
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        return;
                    }
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 9)
                    {
                        //9.��ư�� ����Ǵ� ������Ʈ
                        continue;
                    }
                    else
                    {
                        //�׿��� �͵�
                        return;
                    }
                }
            }
            //�̰� ������ 8.��ư 9.��ư���� �ΰŸ� ������ ����

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection == M.GetComponent<MapGenerator>().sameobj[i+1].transform.parent.GetComponent<ObjCode>().obj_Connection)
                        {
                            if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                            {
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Connection_It)
                        {
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Connection_It)
                        {
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection_It == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Connection_It)
                        {
                            if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_State == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_State)
                            {
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            //�̰ſ��� ������ ���ᰡ���� ������Ʈ�� ����

            M.GetComponent<MapGenerator>().connection_it_Obj = float.Parse(inputWhatConnectionText.text);
            return;
        }
    }

    public void ChangeActivateToggleValue()
    {
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 9)
                    {
                        continue;
                    }
                    else
                    {

                        return;
                    }
                }
            }
            //���⼭ �����°� ��� �� ��ư�� ����Ǵ� ������Ʈ

            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj.Count > i + 1)
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Connection == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Connection)
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                   
                }
            }
            //���⸦ ������ Ȱ��ȭ ��Ȱ��ȭ ���ΰ� ���� ������Ʈ
            



            if (activateToggle.isOn == true)
            {
                Debug.Log("�̰Ž���");
                M.GetComponent<MapGenerator>().connection_Obj = 0; //Ȱ��ȭ�� 0 �ƴϸ� 1
                return;
            }
            else
            {
                M.GetComponent<MapGenerator>().connection_Obj = 1;
                return;
            }
        }
    }
}
