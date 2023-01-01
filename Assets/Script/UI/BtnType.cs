using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup stageGroup;


    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    private void Update()
    {
        if (GameManager.instance.scenStat == 1)
        {
            CanvasGroupOn(stageGroup);
            CanvasGroupOff(mainGroup);

            GameManager.instance.scenStat = 0;
        }
    }

    bool isSound;

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.Start:
                CanvasGroupOn(stageGroup);
                CanvasGroupOff(mainGroup);
                Debug.Log("게임 시작");
                break;
            case BTNType.Edit:
                LoadingSceneController.LoadScene("egit");
                break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
            case BTNType.Sound:
                if (isSound)
                {
                    Debug.Log("사운드 off");
                }
                else
                {
                    Debug.Log("사운드 on");
                }
                isSound = !isSound;
                break;
            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                CanvasGroupOff(stageGroup);
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("종료");
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
