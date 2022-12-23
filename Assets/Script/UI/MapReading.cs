using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapReading : MonoBehaviour
{
    public Image groundImage; //���λ� 
    public Image waterImage; //�ϴû� 
    public Image treeImage;  //���� 1 
    public Image rockImage;  //ȸ�� 2
    public Image buttonImage; //������ 3
    public Image BoxImage;   //�ڽ� 4
    public Image monsterImage;  //������ 5
    public Image goalImage;     //��Ż 6
    public Image moverockImage;   //ȸ�� 7
    public Image coinImage;       //�����8
    public Image W1Image;       // 9
    public Image W2Image;       // 10
    public Image PlayerImage;       // 11

    public GameObject Json; //�� ���� ������Ʈ ��������
    public GameObject saveload; //���̺� �ε� UI ��������


    public bool isView = false; //���� �䰡 ���̸�

    public void MapReadImage()
    {
        for (int i = 0; i < Json.GetComponent<jsonCode>().mapData_.map.Length; i++)
        {
            for (int j = 0; j < Json.GetComponent<jsonCode>().mapData_.map[0].mapX.Length; j++)
            {
                if (Json.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 0 || Json.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 2)
                {
                    //����
                    if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] ==1)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(treeImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    //����
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 2)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(rockImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 3)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(buttonImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 4)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(BoxImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 5)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(monsterImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 6)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(goalImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 7)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(moverockImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 8)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(coinImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 9)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(W1Image, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 10)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(W2Image, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else if (Json.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 19)
                    {

                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(PlayerImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                    }
                    else
                    {
                        //���� Ư����ġ�� Ư�� �̹�����
                        Instantiate(groundImage, new Vector2(i * 30 + 70, j * 30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);

                    }

                }
                else if (Json.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 1)
                {
                    Instantiate(waterImage, new Vector2(i*30 + 70, j*30 + 60), Quaternion.identity, GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).transform);
                }              
            }
        }
    }

    public void clean()
    {
        Transform[] childList = GameObject.Find("MapView").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponentsInChildren<Transform>();

        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
            isView = false;
        }
    }


    string EVENT = "";
    string CURRENT_EVENT = "";

    string currentEvent
    {
        set
        {
            if (CURRENT_EVENT == value) return;

            CURRENT_EVENT = value;

            //���⿡ �ϰ���� �ൿ ����
            clean();
            Debug.Log(CURRENT_EVENT);
        }
        get
        {
            return CURRENT_EVENT;
        }
    }



    // Update is called once per frame
    void Update()
    {
        currentEvent = EVENT;

        if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_1)
        {
            EVENT = "stag_1";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_2)
        {
            EVENT = "stag_2";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_3)
        {
            EVENT = "stag_3";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_4)
        {
            EVENT = "stag_4";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_5)
        {
            EVENT = "stag_5";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_6)
        {
            EVENT = "stag_6";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_7)
        {
            EVENT = "stag_7";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_8)
        {
            EVENT = "stag_8";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_9)
        {
            EVENT = "stag_9";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.stag_10)
        {
            EVENT = "stag_10";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_1)
        {
            EVENT = "customstage_1";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_2)
        {
            EVENT = "customstage_2";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_3)
        {
            EVENT = "customstage_3";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_4)
        {
            EVENT = "customstage_4";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_5)
        {
            EVENT = "customstage_5";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_6)
        {
            EVENT = "customstage_6";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_7)
        {
            EVENT = "customstage_7";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_8)
        {
            EVENT = "customstage_8";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_9)
        {
            EVENT = "customstage_9";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
        else if (saveload.GetComponent<SaveLoadUI>().jsondatamode == SaveLoadUI.JSONDATA.customstage_10)
        {
            EVENT = "customstage_10";

            if (isView == false)
            {
                MapReadImage();
                isView = true;
            }
        }
    }
}
