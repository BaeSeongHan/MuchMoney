using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjStateUI : MonoBehaviour
{
    public Slider sizeSlider; //사이즈 슬라이더

    public Text inputSizeText; //입력하는곳 사이즈 텍스트
    public Text inputActionText; //입력하는 소모 HP 텍스트
    public Text inputMonsterSpeedText; //입력하는 몬스터 속도 텍스트
    public Dropdown inputButtonConnectionDropdown; //입력하는 버튼연결 드롭다운
    public Text inputWhatConnectionText; //입력하는 연결 text;

    public Toggle activateToggle; //오브젝트의 초기상태가 어떤지 알려주는 토글

    public Text actionText; //소모 HP 알려주는 텍스트
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
                    //버튼만 들어간 상태
                    if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        continue;
                    }
                    //하나도 버튼이 안들어간 상태
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().objStatus)
                        {
                            //오브젝트 상태가 같다
                            continue;
                        }
                        else
                        {
                            //오브젝트 상태가 다르다
                            stateText.text = "ObjState: - ";
                            return;
                        }
                    }
                    //하나라도 버튼이 들어간 상태
                    else
                    {
                        //오브젝트 상태가 다르다
                        stateText.text = "ObjState: - ";
                        return;
                    }

                }
            }
            //위에거가 끝나고 나오는건 상태가 모두 같은 오브젝트다.

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
                            //사이즈가 같으면
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //사이즈가 다르면
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag != "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag == "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].transform.parent.GetComponent<ObjCode>().obj_Size)
                        {
                            //사이즈가 같으면
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //사이즈가 다르면
                        }
                    }
                    else if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button" && M.GetComponent<MapGenerator>().sameobj[i + 1].tag != "button")
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Size)
                        {
                            //사이즈가 같으면
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //사이즈가 다르면
                        }
                    }
                    else
                    {
                        if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().obj_Size == M.GetComponent<MapGenerator>().sameobj[i + 1].GetComponent<ObjCode>().obj_Size)
                        {
                            //사이즈가 같으면
                            continue;
                        }
                        else
                        {
                            sizeText.text = "ObjSize: - ";
                            return;
                            //사이즈가 다르면
                        }
                    }
                }
            }

            //사이즈가 같으면
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
                    //그외의 것들
                    actionText.text = "Attack -HP: - ";
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 4 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 5 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //4.제거,5.움직이는거,6.몬스터 오브젝트이면 실행
                        continue;
                    }
                    else
                    {
                        //그외의 것들
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
                        //그외의 것들
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
                    //그외의 것들
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
                        //그외의 것들
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
                        //그외의 것들
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
                    //그외의 것들
                    buttonText.text = "Button: - ";
                    return;
                }
            }
            //여기서 나오면 다 버튼태그를 가지고 있는 오브젝트다

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
                        //그외의 것들
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
                        //그외의 것들
                        whatconnectionText.text = "Connection: - ";
                        return;
                    }  
                }
            }
            //여기서 나오면 버튼이거나 버튼과 연결되는 오브젝트

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
                                //그외의 것들
                                whatconnectionText.text = "Connection: - ";
                                return;
                            }
                        }
                        else
                        {
                            //그외의 것들
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
                            //그외의 것들
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
                            //그외의 것들
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
                                //그외의 것들
                                whatconnectionText.text = "Connection: - ";
                                return;
                            }
                        }
                        else
                        {
                            //그외의 것들
                            whatconnectionText.text = "Connection: - ";
                            return;
                        }
                    }
                }
            }
            //여기서 나오면 선택한 오브젝트는 전부 연결된 오브젝트다


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
            //여기서 나오는건 모두 다 버튼과 연결되는 오브젝트

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
            //여기를 나오면 모든 오브젝트의 활성화 여부가 같다.

            activateToggle.gameObject.SetActive(true);
        }
    }


    public void ChangeSliderValue()
    {
        sizeSlider.value = float.Parse(inputSizeText.text);
    }
    public void ChangeActionValue()
    {
        //조건이 필요
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //그외의 것들
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 4 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 5 || M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //4.제거,5.움직이는거,6.몬스터 오브젝트이면 실행
                        continue;
                    }
                    else
                    {
                        //그외의 것들
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
        //조건이 필요
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    //그외의 것들
                    return;
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 6)
                    {
                        //6.몬스터 오브젝트이면 실행
                        continue;
                    }
                    else
                    {
                        //그외의 것들
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
        //조건이 필요
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().objStatus == 8)
                    {
                        //8.버튼 오브젝트면 실행
                        continue;
                    }
                    else
                    {
                        //그외의 것들
                        return;
                    }
                }
                else
                {
                    //그외의 것들
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
        //조건이 필요
        if (M.GetComponent<MapGenerator>().sameobj.Count != 0 && M.GetComponent<MapGenerator>().mode == 42)
        {
            for (int i = 0; i < M.GetComponent<MapGenerator>().sameobj.Count; i++)
            {
                if (M.GetComponent<MapGenerator>().sameobj[i].tag == "button")
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].transform.parent.GetComponent<ObjCode>().objStatus == 8)
                    {
                        //8.버튼 오브젝트면 실행
                        continue;
                    }
                    else
                    {
                        //그외의 것들
                        return;
                    }
                }
                else
                {
                    if (M.GetComponent<MapGenerator>().sameobj[i].GetComponent<ObjCode>().objStatus == 9)
                    {
                        //9.버튼과 연결되는 오브젝트
                        continue;
                    }
                    else
                    {
                        //그외의 것들
                        return;
                    }
                }
            }
            //이게 끝나면 8.버튼 9.버튼연결 인거만 밖으로 나옴

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
            //이거에서 나오면 연결가능한 오브젝트만 설정

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
            //여기서 나오는건 모두 다 버튼과 연결되는 오브젝트

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
            //여기를 나오면 활성화 비활성화 여부가 같은 오브젝트
            



            if (activateToggle.isOn == true)
            {
                Debug.Log("이거실행");
                M.GetComponent<MapGenerator>().connection_Obj = 0; //활성화면 0 아니면 1
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
