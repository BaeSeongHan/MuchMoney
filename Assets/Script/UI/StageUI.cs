using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using System.IO;


public class StageUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform buttonScale;
    [SerializeField] private BTN_StageType currentType;
    private Vector3 defaultScale;

    private CanvasGroup mainGroup;
    private CanvasGroup optionGroup;
    private CanvasGroup stageGroup;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnStageBtnClick()
    {
        switch (currentType)
        {
            case BTN_StageType.S_1:
                LoadingSceneController.LoadScene("SampleScene 3");
                break;
            case BTN_StageType.S_2:
                //이걸로 다음스테이지를 알려줌
                if(GameManager.instance.sceneNum != 10 && GameManager.instance.sceneNum != 23)
                    GameManager.instance.sceneNum++;
                LoadingSceneController.LoadScene("SampleScene 3");
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
        GameManager.instance.soundManager.EffectsSound(12);
        buttonScale.localScale = defaultScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}

