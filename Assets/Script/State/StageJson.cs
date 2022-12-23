using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageJson : MonoBehaviour
{
    public Sprite y_Star;
    public Sprite b_Star;
    public Image[] Star = new Image[3]; //현재 별

    public Sprite lockButton;
    public Sprite stanButton;

    public Button sButton; //스테이지 버튼

    public int stageNum; //몇스테이지인지 알려주는 변수
    public TextMeshProUGUI resourceText; //텍스트 가져올거

    //클리어 했는지 안했는지 판단해서 별 나타내기 및 스테이지 잠금 해제

    // Start is called before the first frame update
    void Start()
    {
        if (stageNum > 11)
        {
            resourceText.text = (stageNum + 1 - 12).ToString();
        }
        else
        {
            resourceText.text = (stageNum + 1).ToString();
        }
        //제이슨 파일 읽어와서 stageData 변경
    }

    // Update is called once per frame
    void Update()
    {
        ReadStageJson();
    }

    void ReadStageJson()
    {
        if (stageNum == 0)
        {
            sButton.GetComponent<Image>().sprite = stanButton; //버튼 키고
            sButton.GetComponent<Button>().interactable = true;
            resourceText.text = (stageNum + 1).ToString(); //숫자 적고

            //별 알려주기
            if (GameManager.instance.stageData.Stage[stageNum] == 0)
            {
                Star[0].GetComponent<Image>().sprite = b_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 1)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 2)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = y_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 3)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = y_Star;
                Star[2].GetComponent<Image>().sprite = y_Star;
            }
        }
        else if (stageNum == 12)
        {
            sButton.GetComponent<Image>().sprite = stanButton; //버튼 키고
            sButton.GetComponent<Button>().interactable = true;
            resourceText.text = (stageNum + 1 - 12).ToString();

            //별 알려주기
            if (GameManager.instance.stageData.Stage[stageNum] == 0)
            {
                Star[0].GetComponent<Image>().sprite = b_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 1)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 2)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = y_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
            else if (GameManager.instance.stageData.Stage[stageNum] == 3)
            {
                Star[0].GetComponent<Image>().sprite = y_Star;
                Star[1].GetComponent<Image>().sprite = y_Star;
                Star[2].GetComponent<Image>().sprite = y_Star;
            }
        }
        else if (stageNum > 12)
        {
            if (GameManager.instance.stageData.Stage[stageNum - 1] != 0)
            {
                sButton.GetComponent<Image>().sprite = stanButton; //버튼키고
                sButton.GetComponent<Button>().interactable = true;
                resourceText.text = (stageNum + 1 - 12).ToString();

                //별그리기
                if (GameManager.instance.stageData.Stage[stageNum] == 0)
                {
                    Star[0].GetComponent<Image>().sprite = b_Star;
                    Star[1].GetComponent<Image>().sprite = b_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 1)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = b_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 2)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = y_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 3)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = y_Star;
                    Star[2].GetComponent<Image>().sprite = y_Star;
                }
            }
            else
            {
                resourceText.text = ""; //숫자 끄기
                //버튼 끄고
                sButton.GetComponent<Image>().sprite = lockButton;
                sButton.GetComponent<Button>().interactable = false;

                //별그리기
                Star[0].GetComponent<Image>().sprite = b_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
        }
        else
        {
            if (GameManager.instance.stageData.Stage[stageNum - 1] != 0)
            {
                sButton.GetComponent<Image>().sprite = stanButton; //버튼키고
                sButton.GetComponent<Button>().interactable = true;
                resourceText.text = (stageNum + 1).ToString();

                //별그리기
                if (GameManager.instance.stageData.Stage[stageNum] == 0)
                {
                    Star[0].GetComponent<Image>().sprite = b_Star;
                    Star[1].GetComponent<Image>().sprite = b_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 1)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = b_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 2)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = y_Star;
                    Star[2].GetComponent<Image>().sprite = b_Star;
                }
                else if (GameManager.instance.stageData.Stage[stageNum] == 3)
                {
                    Star[0].GetComponent<Image>().sprite = y_Star;
                    Star[1].GetComponent<Image>().sprite = y_Star;
                    Star[2].GetComponent<Image>().sprite = y_Star;
                }
            }
            else
            {
                resourceText.text = ""; //숫자 끄기
                //버튼 끄고
                sButton.GetComponent<Image>().sprite = lockButton;
                sButton.GetComponent<Button>().interactable = false;
                
                //별그리기
                Star[0].GetComponent<Image>().sprite = b_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
        }
    }

    public void SenceNumChange()
    {
        GameManager.instance.sceneNum = stageNum;
        Debug.Log(GameManager.instance.sceneNum);
    }
}

