using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonUI : MonoBehaviour
{
    //입력 받는쪽 텍스트
    public Text action;
    public Text misson1;
    public Text misson2;
    //입력하는 쪽 텍스트
    public Text _action;  //스테이지 행동력
    public Text _misson1; //최소 보유 행동력
    public Text _misson2; //시간

    public GameObject M;

    public void ChangeMissonUI_action()
    {
        if (_action.text == "")
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[0] = 0;
        }
        else
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[0] = int.Parse(_action.text);
        }
    }
    public void ChangeMissonUI_misson1()
    {
        if (_misson1.text == "")
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[1] = 0;
        }
        else
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[1] = int.Parse(_misson1.text);
        }
    }
    public void ChangeMissonUI_misson2()
    {
        if (_misson2.text == "")
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[2] = 0;
        }
        else
        {
            M.GetComponent<MapGenerator>().stageData_Test.stageData[2] = int.Parse(_misson2.text);
        }
    }
    
    void Start()
    {
        action.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[0].ToString();
        misson1.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[1].ToString();
        misson2.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[2].ToString();
       
    }


    private void Update()
    {
        action.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[0].ToString();
        misson1.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[1].ToString();
        misson2.text = M.GetComponent<MapGenerator>().stageData_Test.stageData[2].ToString();
    }
}
