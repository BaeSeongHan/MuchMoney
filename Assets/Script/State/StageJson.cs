using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageJson : MonoBehaviour
{
    public Sprite y_Star;
    public Sprite b_Star;
    public Image[] Star = new Image[3]; //���� ��

    public Sprite lockButton;
    public Sprite stanButton;

    public Button sButton; //�������� ��ư

    public int stageNum; //����������� �˷��ִ� ����
    public TextMeshProUGUI resourceText; //�ؽ�Ʈ �����ð�

    //Ŭ���� �ߴ��� ���ߴ��� �Ǵ��ؼ� �� ��Ÿ���� �� �������� ��� ����

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
        //���̽� ���� �о�ͼ� stageData ����
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
            sButton.GetComponent<Image>().sprite = stanButton; //��ư Ű��
            sButton.GetComponent<Button>().interactable = true;
            resourceText.text = (stageNum + 1).ToString(); //���� ����

            //�� �˷��ֱ�
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
            sButton.GetComponent<Image>().sprite = stanButton; //��ư Ű��
            sButton.GetComponent<Button>().interactable = true;
            resourceText.text = (stageNum + 1 - 12).ToString();

            //�� �˷��ֱ�
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
                sButton.GetComponent<Image>().sprite = stanButton; //��ưŰ��
                sButton.GetComponent<Button>().interactable = true;
                resourceText.text = (stageNum + 1 - 12).ToString();

                //���׸���
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
                resourceText.text = ""; //���� ����
                //��ư ����
                sButton.GetComponent<Image>().sprite = lockButton;
                sButton.GetComponent<Button>().interactable = false;

                //���׸���
                Star[0].GetComponent<Image>().sprite = b_Star;
                Star[1].GetComponent<Image>().sprite = b_Star;
                Star[2].GetComponent<Image>().sprite = b_Star;
            }
        }
        else
        {
            if (GameManager.instance.stageData.Stage[stageNum - 1] != 0)
            {
                sButton.GetComponent<Image>().sprite = stanButton; //��ưŰ��
                sButton.GetComponent<Button>().interactable = true;
                resourceText.text = (stageNum + 1).ToString();

                //���׸���
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
                resourceText.text = ""; //���� ����
                //��ư ����
                sButton.GetComponent<Image>().sprite = lockButton;
                sButton.GetComponent<Button>().interactable = false;
                
                //���׸���
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

