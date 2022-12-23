using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using System.IO;


public class StageUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

        
    public BTN_StageType currentType;

    public Transform buttonScale;
    Vector3 defaultScale;

    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup stageGroup;



    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnStageBtnClick()
    {
        switch (currentType)
        {
            case BTN_StageType.S_1:
                if (GameManager.instance.sceneNum == 0)
                {
                    GameManager.instance.sceneNum = 0;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 1)
                {
                    GameManager.instance.sceneNum = 1;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 2)
                {
                    GameManager.instance.sceneNum = 2;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 3)
                {
                    GameManager.instance.sceneNum = 3;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 4)
                {
                    GameManager.instance.sceneNum = 4;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 5)
                {
                    GameManager.instance.sceneNum = 5;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 6)
                {
                    GameManager.instance.sceneNum = 6;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 8)
                {
                    GameManager.instance.sceneNum = 8;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 9)
                {
                    GameManager.instance.sceneNum = 9;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 10)
                {
                    GameManager.instance.sceneNum = 10;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                //여기부터 커스텀
                else if (GameManager.instance.sceneNum == 12)
                {
                    GameManager.instance.sceneNum = 12;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 13)
                {
                    GameManager.instance.sceneNum = 13;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 14)
                {
                    GameManager.instance.sceneNum = 14;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 15)
                {
                    GameManager.instance.sceneNum = 15;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 16)
                {
                    GameManager.instance.sceneNum = 16;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 17)
                {
                    GameManager.instance.sceneNum = 17;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 18)
                {
                    GameManager.instance.sceneNum = 18;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 19)
                {
                    GameManager.instance.sceneNum = 19;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 20)
                {
                    GameManager.instance.sceneNum = 20;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 21)
                {
                    GameManager.instance.sceneNum = 21;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 22)
                {
                    GameManager.instance.sceneNum = 22;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 23)
                {
                    GameManager.instance.sceneNum = 23;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }

                break;
            case BTN_StageType.S_2:

                //이걸로 다음스테이지를 알려줌
                GameManager.instance.sceneNum++;

                if (GameManager.instance.sceneNum == 0)
                {
                    GameManager.instance.sceneNum = 0;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 1)
                {
                    GameManager.instance.sceneNum = 1;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 2)
                {
                    GameManager.instance.sceneNum = 2;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 3)
                {
                    GameManager.instance.sceneNum = 3;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 4)
                {
                    GameManager.instance.sceneNum = 4;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 5)
                {
                    GameManager.instance.sceneNum = 5;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 6)
                {
                    GameManager.instance.sceneNum = 6;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 8)
                {
                    GameManager.instance.sceneNum = 8;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 9)
                {
                    GameManager.instance.sceneNum = 9;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 10)
                {
                    GameManager.instance.sceneNum = 10;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                //여기부터 커스텀
                else if (GameManager.instance.sceneNum == 12)
                {
                    GameManager.instance.sceneNum = 12;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 13)
                {
                    GameManager.instance.sceneNum = 13;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 14)
                {
                    GameManager.instance.sceneNum = 14;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 15)
                {
                    GameManager.instance.sceneNum = 15;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 16)
                {
                    GameManager.instance.sceneNum = 16;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 17)
                {
                    GameManager.instance.sceneNum = 17;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 18)
                {
                    GameManager.instance.sceneNum = 18;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 19)
                {
                    GameManager.instance.sceneNum = 19;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 20)
                {
                    GameManager.instance.sceneNum = 20;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 21)
                {
                    GameManager.instance.sceneNum = 21;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 22)
                {
                    GameManager.instance.sceneNum = 22;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 23)
                {
                    GameManager.instance.sceneNum = 23;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }
                else if (GameManager.instance.sceneNum == 24)
                {
                    GameManager.instance.sceneNum = 23;
                    LoadingSceneController.LoadScene("SampleScene 3");
                }






                break;
            case BTN_StageType.S_3:
                break;
            case BTN_StageType.S_4:
                break;
            case BTN_StageType.S_5:
                break;
            case BTN_StageType.S_6:
                break;
            case BTN_StageType.Stage:
                GameManager.instance.scenStat = 1;
                Time.timeScale = 1;

                Debug.Log("스테이지로");
                GameManager.instance.IsPause = false;
                LoadingSceneController.LoadScene("G_Main");
                break;
            case BTN_StageType.Start:
                //stage제이슨 파일 불러오기
                Time.timeScale = 1; //변경해야한다
                GameManager.instance.IsPause = false;

                
                string path = Path.Combine(Application.persistentDataPath, "stageData.json");
                string jsonData = File.ReadAllText(path);
                GameManager.instance.stageData = JsonUtility.FromJson<StageData>(jsonData);


                LoadingSceneController.LoadScene("G_Main");
                break;

            case BTN_StageType.Back:
                if (mainGroup != null && stageGroup != null)
                {
                    CanvasGroupOn(mainGroup);
                    CanvasGroupOff(stageGroup);
                }
               
                break;
            default:
                break;
        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {

        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {

        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManger.instance.MouseOnSound();
        buttonScale.localScale = defaultScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}

