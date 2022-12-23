using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using System.Text;



public class MapGenerator : MonoBehaviour
{
    public int mode; //���� ��� ��Ÿ����
    public Camera get_Camera; //ī�޶� �����ð�
    public GameObject map_x; //x�� �Է¹����� �������°�
    public GameObject map_y; //y�� �Է¹����� �������°�
    //public GameObject M; //�ڱ��ڽ�
    public Text mapT; // �� ũ�� �����ִ� text �������°�
    public Text brushT; //�귯�� ��� �ؽ�Ʈ


    public Text action; //�Է¹��� �ൿ�� �ؽ�Ʈ
    public Text misson1; //�Է¹��� �̼�1 �ؽ�Ʈ
    public Text misson2; //�Է¹��� �̼�2 �ؽ�Ʈ

    //-----------------------------
    public GameObject tree_ack; //������ �Ҹ��ϴ� �ൿ�� �������°�
    //-----------------------------
    public Transform wPrefab; //Ÿ�� ������
    public Transform gPrefab; //Ÿ�� ������
    public Vector2 mapSize; //�� ������
    [Range(0, 1)]
    public float blockSize;       //�� ������ ����
    public UnityEngine.UI.Slider size_B; //�� ������ �����̴�
    //-----------------------------
    public Transform playerSponObj; //�÷��̾� ���� ������Ʈ ���°�

    public Transform objPrefab_tree; //������Ʈ ������ ���°� 1
    public Transform objPrefab_rook; //������Ʈ ������ ���°� 2
    public Transform objPrefab_Button; //������Ʈ ������ ���°� 3
    public Transform objPrefab_Monster; //������Ʈ ������ ���°� 5
    public Transform objPrefab_Wall; //������Ʈ ������ ���°� 4
    public Transform objPrefab_Goal; //������Ʈ ������ ���°� 6
    public Transform objPrefab_moverook; //������Ʈ ������ ���°� 7
    public Transform objPrefab_coin; //������Ʈ ������ ���°� 8
    public Transform objPrefab_Wall_1; //������Ʈ ������ ���°� 9
    public Transform objPrefab_Wall_2; //������Ʈ ������ ���°� 10
    [Range(0, 1)]
    public float objSize;       //������Ʈ ������ ����
    public UnityEngine.UI.Slider size_O; //�� ������ �����̴�

    //���̽� ���� �ҷ����� ��(��) ���� ���̽����Ͽ��� �ҷ����°� �ƴ�

    //public AAAA objData_Test;

    public AAAA mapData_Test;
    public ODATA O_Test;
    public STAGEDATA stageData_Test;

    public List<Vector3> clicks = new List<Vector3>(); //Ŭ���Ѱ� ���� vector3����Ʈ


    public GameObject[] AllObj; //��������Ʈ ���� �迭

    public GameObject[] AllTree; //��糪��������Ʈ ���� �迭

    public List<GameObject> MoveObj = new List<GameObject>(); //��� ������ ���ӿ�����Ʈ ���� ����Ʈ





    public CanvasGroup moveGroup;


    public GameObject JasnData; //���̽� ������ ������ ��
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroupOff(moveGroup);


        mapT.text = "Map Size: " + (int)mapSize.x + "x" + (int)mapSize.y; //text �ʱ�ȭ
        mapData_Test = reset_m((int)mapSize.x, (int)mapSize.y); //�ʱ�ȭ
        O_Test = reset_m_Test((int)mapSize.x, (int)mapSize.y); //�ʱ�ȭ
        stageData_Test = reset_stageData(4);//�ʱ�ȭ

        JasnData.GetComponent<jsonCode>().mapData_ = mapData_Test;
        JasnData.GetComponent<jsonCode>().objData_ = O_Test;
        JasnData.GetComponent<jsonCode>().stageData_misson = reset_stageData(4);

        GenerateMap();
    }

    //�� �� ���� Ÿ�� ������
    Vector3 CoordToPosition(int i, int j)
    {
        return new Vector3(i, 0, j);
    }

    //�ʵ����� ����
    public AAAA reset_m(int a, int b)
    {
        AAAA num = new AAAA();
        num.map = new BBBB[b];
        BBBB[] aaa = new BBBB[b];
        for (int i = 0; i < aaa.Length; i++)
        {
            aaa[i] = new BBBB();
        }
        for (int i = 0; i < aaa.Length; i++)
        {
            aaa[i].mapX = new int[a];
        }
        for (int i = 0; i < num.map.Length; i++)
        {
            num.map[i] = aaa[i];
        }

        return num;
    }
    public AAAA change_m(int a, int b, AAAA mapData)
    {
        AAAA num = new AAAA();
        num.map = new BBBB[b];
        BBBB[] aaa = new BBBB[b];
        for (int i = 0; i < aaa.Length; i++)
        {
            aaa[i] = new BBBB();
        }
        for (int i = 0; i < aaa.Length; i++)
        {
            aaa[i].mapX = new int[a];
        }
        for (int i = 0; i < num.map.Length; i++)
        {
            num.map[i] = aaa[i];
        }

        for (int i = 0; i < mapData.map.Length; i++)
        {
            if (num.map.Length <= i)
            {
                break;
            }

            for (int j = 0; j < mapData.map[0].mapX.Length; j++)
            {
                if (num.map[i].mapX.Length <= j)
                {
                    break;
                }
                else
                {
                    num.map[i].mapX[j] = mapData.map[i].mapX[j];
                }
            }
        }

        return num;
    }
    //������Ʈ ������ ����
    public ODATA reset_m_Test(int a, int b)
    {
        //1
        ODATA TA = new ODATA();
        //2
        TA.map = new odata[b];
        odata[] _ta = new odata[b];
        //_1
        for (int i = 0; i < _ta.Length; i++)
        {

            odata ta = new odata();
            ta.mapX = new od[a];
            od[] _d = new od[a];

            for (int j = 0; j < _d.Length; j++)
            {
                _d[j] = new od();
            }
            for (int j = 0; j < _d.Length; j++)
            {
                _d[j].oData = new float[7];
            }
            for (int j = 0; j < ta.mapX.Length; j++)
            {
                ta.mapX[j] = _d[j];
            }

            _ta[i] = ta;
        }
        for (int i = 0; i < TA.map.Length; i++)
        {
            TA.map[i] = _ta[i];
        }

        return TA;
    }
    public ODATA change_ODATA(int a, int b, ODATA objData)
    {
        //1
        ODATA TA = new ODATA();
        //2
        TA.map = new odata[b];
        odata[] _ta = new odata[b];
        //_1
        for (int i = 0; i < _ta.Length; i++)
        {

            odata ta = new odata();
            ta.mapX = new od[a];
            od[] _d = new od[a];

            for (int j = 0; j < _d.Length; j++)
            {
                _d[j] = new od();
            }
            for (int j = 0; j < _d.Length; j++)
            {
                _d[j].oData = new float[7];
            }
            for (int j = 0; j < ta.mapX.Length; j++)
            {
                ta.mapX[j] = _d[j];
            }

            _ta[i] = ta;
        }
        for (int i = 0; i < TA.map.Length; i++)
        {
            TA.map[i] = _ta[i];
        }



        for (int i = 0; i < objData.map.Length; i++)
        {
            if (TA.map.Length <= i)
            {
                break;
            }

            for (int j = 0; j < objData.map[0].mapX.Length; j++)
            {
                if (TA.map[i].mapX.Length <= j)
                {
                    break;
                }
                else
                {
                    TA.map[i].mapX[j] = objData.map[i].mapX[j];
                }
            }
        }

        return TA;
    }
    //�������� ������ ����

    public STAGEDATA reset_stageData(int a)
    {
        STAGEDATA num = new STAGEDATA();
        num.stageData = new int[a];

        return num;
    }
    public STAGEDATA change_STAGEDATA(STAGEDATA stage)
    {
        STAGEDATA num = new STAGEDATA();
        num.stageData = new int[4];

        num.stageData[0] = stage.stageData[0];
        num.stageData[1] = stage.stageData[1];
        num.stageData[2] = stage.stageData[2];
        num.stageData[3] = coinc;

        return num;
    }

    public int coinc = 0; //����ī���� �����ð�

    public void GenerateMap()
    {
        coinc = 0; //���� ī���� �ٽ� �ʱ�ȭ
        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        //�� �����ڵ�
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 blockPos = CoordToPosition(y, x);

                if (mapData_Test.map[y].mapX[x] == 0)
                {
                    Transform newBlock = Instantiate(gPrefab, blockPos, Quaternion.identity);
                    newBlock.localScale = Vector3.one * (1 - blockSize);
                    newBlock.parent = mapHolder;
                }

                else if (mapData_Test.map[y].mapX[x] == 1)
                {
                    Transform newBlock = Instantiate(wPrefab, blockPos, Quaternion.identity);
                    newBlock.localScale = Vector3.one * (1 - blockSize);
                    newBlock.parent = mapHolder;
                }
                else if (mapData_Test.map[y].mapX[x] == 2)
                {
                    Transform newBlock = Instantiate(gPrefab, blockPos, Quaternion.identity);
                    newBlock.localScale = Vector3.one * (1 - blockSize);
                    newBlock.parent = mapHolder;
                }



                //Transform newBlock = Instantiate(wPrefab, blockPos, Quaternion.identity);
                //newBlock.localScale = Vector3.one * (1 - blockSize);
                //newBlock.parent = mapHolder;
            }
        }
        //-----------------------------
        //������Ʈ �����ڵ�
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 blockPos = CoordToPosition(y, x);


                if (O_Test.map[y].mapX[x].oData[0] == 1)
                {
                    Transform newObj = Instantiate(objPrefab_tree, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }
                else if (O_Test.map[y].mapX[x].oData[0] == 2)
                {
                    Transform newObj = Instantiate(objPrefab_rook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 3)
                {
                    Transform newObj = Instantiate(objPrefab_Button, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 4)
                {
                    Transform newObj = Instantiate(objPrefab_Wall, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 5)
                {
                    Transform newObj = Instantiate(objPrefab_Monster, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 6)
                {
                    Transform newObj = Instantiate(objPrefab_Goal, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 7)
                {
                    Transform newObj = Instantiate(objPrefab_moverook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 8)
                {
                    Transform newObj = Instantiate(objPrefab_coin, blockPos + Vector3.up * 0.3f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];
                    coinc++;
                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 9)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_1, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 10)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_2, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }
                else if (O_Test.map[y].mapX[x].oData[0] == 19)
                {
                    Transform newObj = Instantiate(playerSponObj, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //������Ʈ ����
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //������Ʈ ������
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //������Ʈ �Ҹ� �ൿ��

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }
            }
        }

        stageData_Test.stageData[3] = coinc;
    }


    //change_m������
    //------------------------------------


    //------------------------------------
    //������Ʈ ���¸� ����
    public void change_obj_Prefab(int prefab, int num)
    {
        //�ν��°� ������ ������Ʈ
        if (num == 1)
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 2) //�����̴� ������Ʈ
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 10.0f; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 3) //����
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.2f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 3; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 10.0f; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 4) //��ȣ�ۿ� �Ұ��� ������Ʈ
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 5) //��ư
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 6) //��Ż or ����� ������� �ϴ� ������Ʈ
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����(Ȱ��ȭ ��Ȱ��ȭ)
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����
            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 7) //�÷��̾� ����
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.4f; //1��°�� �������� ����
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2��°�� �Ҹ� �ൿ���� ����
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4��°�� ���� ���ǵ� ����
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����(Ȱ��ȭ ��Ȱ��ȭ)
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6��°�� ��͵��� ����Ǿ� �ִ��� ����

            }
            GenerateMap();
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
    } //mode 1~18
    public void change_player_Prefab(int prefab, int aaaaaaa)
    {
        for (int i = 0; i < clicks.Count; i++)
        {
            int g_x;
            int g_y;
            g_x = (int)clicks[i].x;
            g_y = (int)clicks[i].z;

            O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0��°�� 1�� ����
            O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1��°�� �������� ����
            O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2��°�� �Ҹ� �ൿ���� ����
            O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3��°�� ���ǵ� ����
        }
        GenerateMap();
        //����Ʈ �ʱ�ȭ
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    }
    public void change_obj_Data(float size, float state, float speed, float monsterspeed, float connection, float connection_it)
    {
        for (int i = 0; i < clicks.Count; i++)
        {
            int g_x;
            int g_y;
            g_x = (int)clicks[i].x;
            g_y = (int)clicks[i].z;

            O_Test.map[g_x].mapX[g_y].oData[1] = size; //1��°�� �������� ����
            O_Test.map[g_x].mapX[g_y].oData[2] = state; //2��°�� �Ҹ� �ൿ���� ����
            O_Test.map[g_x].mapX[g_y].oData[3] = speed; //3��°�� ���ǵ� ����
            O_Test.map[g_x].mapX[g_y].oData[4] = monsterspeed; //4��°�� ���� ���ǵ� ����
            O_Test.map[g_x].mapX[g_y].oData[5] = connection; //5��°�� �������Ʈ�� ����Ǿ��ִ��� ����(Ȱ��ȭ ��Ȱ��ȭ)
            O_Test.map[g_x].mapX[g_y].oData[6] = connection_it; //6��°�� ��͵��� ����Ǿ� �ִ��� ����


        }
        GenerateMap();
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    } //mode 12

    public void change_toggle(float connection)
    {
        for (int i = 0; i < clicks.Count; i++)
        {
            int g_x;
            int g_y;
            g_x = (int)clicks[i].x;
            g_y = (int)clicks[i].z;

            O_Test.map[g_x].mapX[g_y].oData[5] = connection;
        }
        GenerateMap();
    }
    public void adfssdfas()
    {
        change_toggle(connection_Obj);
    }


    public void obj_Delete()
    {
        for (int i = 0; i < clicks.Count; i++)
        {
            int g_x;
            int g_y;
            g_x = (int)clicks[i].x;
            g_y = (int)clicks[i].z;

            for (int j = 0; j < 7; j++)
            {
                O_Test.map[g_x].mapX[g_y].oData[j] = 0;
            }
            mapData_Test.map[g_x].mapX[g_y] = 0; //������ �����
        }
        GenerateMap();
        //����Ʈ �ʱ�ȭ
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    } 
    public void move_Prefab()
    {
        for (int i = 0; i < AllObj.Length; i++)
        {
            if (AllObj[i].gameObject.tag == "aa" || AllObj[i].gameObject.tag == "goal" || AllObj[i].gameObject.tag == "Monster")
            {
                if (MoveObj.Contains(AllObj[i]))
                {
                    //�ߺ��Ѱ� ������ �ƹ��͵� �ȳֱ�
                }
                else
                {
                    MoveObj.Add(AllObj[i]);

                }
            }
            else if (AllObj[i].gameObject.tag == "button")
            {
                if (MoveObj.Contains(AllObj[i].gameObject.transform.parent.gameObject))
                {
                    //�ߺ��Ѱ� ������ �ƹ��͵� �ȳֱ�
                }
                else
                {
                    MoveObj.Add(AllObj[i].gameObject.transform.parent.gameObject);
                }
            }
            else if (AllObj[i].gameObject.tag == "PlayerSpon")
            {
                if (MoveObj.Contains(AllObj[i]))
                {
                    //�ߺ��Ѱ� ������ �ƹ��͵� �ȳֱ�
                }
                else
                {
              
                    MoveObj.Add(AllObj[i]);
                }
            }
        }
        //���⿡ ���� �̵� �־�� �Ѵ�.

        
        O_Test = reset_m_Test((int)mapSize.x, (int)mapSize.y); //�ʱ�ȭ
        for (int i = 0; i < MoveObj.Count; i++)
        {

            //�ʱ�ȭ �߰�
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[0] = (float)MoveObj[i].GetComponent<ObjCode>().obj_State;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[1] = (float)MoveObj[i].GetComponent<ObjCode>().obj_Size;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[2] = (float)MoveObj[i].GetComponent<ObjCode>().obj_Ack;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[3] = (float)MoveObj[i].GetComponent<ObjCode>().obj_Speed;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[4] = (float)MoveObj[i].GetComponent<ObjCode>().monster_Speed;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[5] = (float)MoveObj[i].GetComponent<ObjCode>().obj_Connection;
            O_Test.map[(int)MoveObj[i].transform.position.x].mapX[(int)MoveObj[i].transform.position.z].oData[6] = (float)MoveObj[i].GetComponent<ObjCode>().obj_Connection_It;

        }
    } 
    public void move_obj_clean()
    {
        MoveObj = new List<GameObject>();
    }
    public void change_ground_Prefab(int prefab)
    {
        for (int i = 0; i < clicks.Count; i++)
        {
            int g_x;
            int g_y;
            g_x = (int)clicks[i].x;
            g_y = (int)clicks[i].z;
            if (O_Test.map[g_x].mapX[g_y].oData[0] == 0)
            {
                mapData_Test.map[g_x].mapX[g_y] = prefab;
            }
        }
        GenerateMap();
        //����Ʈ �ʱ�ȭ
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    }
    public void change_stage_Data(int a,int b, int c, int data)
    {
        stageData_Test.stageData[0] = a;
        stageData_Test.stageData[1] = b;
        stageData_Test.stageData[2] = c;
        stageData_Test.stageData[3] = data;
    }
    //------------------------------------



    public int stagedataaction; //�������� ������ ����
    public int stagedatamisson1;
    public int stagedatamisson2;


    public void sizeSlider_B()
    {
        blockSize = size_B.value;
    }
    public void sizeSlider_O()
    {
        objSize = size_O.value;
    }

    public void loadmap()
    {
        mapT.text = "Map Size: " + map_x.GetComponent<InputField>().text.ToString() + "x" + map_y.GetComponent<InputField>().text.ToString();
        mapSize.x = int.Parse(map_x.GetComponent<InputField>().text);
        mapSize.y = int.Parse(map_y.GetComponent<InputField>().text);

        mapData_Test = change_m((int)mapSize.x, (int)mapSize.y, mapData_Test); //�ʱ�ȭ (������ �ִ� ���� �״�� ������ �ʱ�ȭ �ϰ�ʹ�)
        O_Test = change_ODATA((int)mapSize.x, (int)mapSize.y, O_Test); //�ʱ�ȭ (������ �ִ� ���� �״�� ������ �ʱ�ȭ �ϰ�ʹ�)
        stageData_Test = change_STAGEDATA(stageData_Test);


        JasnData.GetComponent<jsonCode>().mapData_ = mapData_Test;
        JasnData.GetComponent<jsonCode>().objData_ = O_Test;
        JasnData.GetComponent<jsonCode>().stageData_misson = stageData_Test;

        GenerateMap();
    }


    RaycastHit obj_hit;

    //������Ʈ �����Ѱ� �˷��ִ� ���̴� ����
    void chk(int num)
    {
        //clicks�� ���Ͱ��� ���� ������Ʈ�� ������ �� ������Ʈ�� ���̾ �����Ѵ�.

        AllObj = GameObject.FindObjectsOfType<GameObject>();

        for (int i = 0; i < AllObj.Length; i++)
        {
            if (AllObj[i] != null)
            {
                for (int j = 0; j < clicks.Count; j++)
                {
                    if (AllObj[i].transform.position == clicks[j])
                    {
                        AllObj[i].gameObject.layer = num;
                    }
                }
            }
        }
    }

    void BrushRay()
    {
        //Ʈ�� �귯��
        if (mode == 1) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + " Stump";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_tree();
                        change_obj_Prefab(1, 1);
                    }
                }
            }
        }
        //���� �귯��
        else if (mode == 2) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Rock";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_rook();
                        change_obj_Prefab(2, 1);
                    }
                }
            }
        }
        //��ư �귯��
        else if (mode == 3) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Button";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_button();
                        change_obj_Prefab(3, 5);
                    }
                }
            }
        }
        //�� �귯��
        else if (mode == 4) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Box";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_wall();
                        change_obj_Prefab(4, 6);
                    }
                }
            }
        }
        //���� �귯��
        else if (mode == 5) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Monster";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_monster();
                        change_obj_Prefab(5, 3);
                    }
                }
            }
        }
        //�������� �귯��
        else if (mode == 6) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Potal";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_goal();
                        change_obj_Prefab(6, 6);
                    }
                }
            }
        }
        //�����̴� ���� �귯��
        else if (mode == 7) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Move Rock";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_moverook();
                        change_obj_Prefab(7, 2);
                    }
                }
            }
        }
        //���� �귯��
        else if (mode == 8) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Coin";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_moverook();
                        change_obj_Prefab(8, 4);
                    }
                }
            }
        }
        //��1
        else if (mode == 9)
        {
            brushT.text = "Brush Mode: " + "Wall_1";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_moverook();
                        change_obj_Prefab(9, 4);
                    }
                }
            }
        }
        //��2
        else if (mode == 10)
        {
            brushT.text = "Brush Mode: " + "Wall_2";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_moverook();
                        change_obj_Prefab(10, 4);
                    }
                }
            }
        }
        //�÷��̾� ������ġ
        else if (mode == 19) //�̰� �϶� ���콺 ������ ����
        {
            brushT.text = "Brush Mode: " + "Player";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
                {
                    Vector3 a = obj_hit.transform.position;

                    for (int i = 0; i < AllObj.Length; i++)
                    {
                        if (AllObj[i].gameObject.tag == "PlayerSpon")
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        change_obj_Prefab(19, 7);
                    }
                }
            }
        }


        //�׶��� �귯��
        else if (mode == 20)
        {
            brushT.text = "Brush Mode: " + "Ground";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground" || Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Water")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_tree();
                        change_ground_Prefab(0);
                    }
                }
            }
        }
        //���� �귯��
        else if (mode == 21)
        {
            brushT.text = "Brush Mode: " + "Water";
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground" || Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Water")
                {
                    Vector3 a = obj_hit.transform.position;

                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a); //����Ʈ�� ���ϱ�
                        //change_obj_tree();
                        change_ground_Prefab(1);
                    }
                }
            }
        }
        //���� �귯��
        if (mode == 41)
        {
            brushT.text = "Brush Mode: " + "Delete";
            if ((Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl)) && (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift)))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && (obj_hit.transform.tag == "aa" || obj_hit.transform.tag == "button" || obj_hit.transform.tag == "Monster" || obj_hit.transform.tag == "PlayerSpon" || obj_hit.transform.tag == "goal"))
                {
                    Vector3 a = obj_hit.transform.position;
                    if (clicks.Contains(a))
                    {
                        Debug.Log("������ �ִ�.");
                    }
                    else
                    {
                        clicks.Add(a);
                        //D_obj();
                        obj_Delete();
                    }
                }
            }
        }
        if ((Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)) && mode != 42)
        {
            obj_Delete();
            move_obj_clean();
            dragarea_obj = new List<GameObject>();
        }
        //������Ʈ ���� ����
        if (mode == 42)
        {
            brushT.text = "Brush Mode: " + "Data Change";
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && (obj_hit.transform.tag == "aa" || obj_hit.transform.tag == "button" || obj_hit.transform.tag == "Monster" || obj_hit.transform.tag == "goal"))
                {
                    Vector3 a = obj_hit.transform.position;
                    if (clicks.Contains(a))
                    {
                        
                        Debug.Log("������ �ִ�.");
                        clicks.Remove(a);

                    }
                    else
                    {
                        clicks.Add(a);
                    }
                }
            }

            sizeSlider_O_Test();
            //ActionChange();
            //SpeedChange();

            //change_obj_Data(objSize_Test, action_Obj, speed_Obj);
        }
    }

    public string EVENT = "0";
    string CURRENT_EVENT = "0";
    string currentEvent
    {
        set
        {
            if (CURRENT_EVENT == value) return;

            CURRENT_EVENT = value;

            //���⿡ �ϰ���� �ൿ ����

            OnBtnClick(int.Parse(EVENT));

            Debug.Log(CURRENT_EVENT);
        }
        get
        {
            return CURRENT_EVENT;
        }
    }


    //������ ���� �� ����

    public  List<GameObject> sameobj = new List<GameObject>(); //Ŭ���� ������Ʈ ���� ����Ʈ
    public GameObject objUI; //������Ʈ UI
    
    
    public void clickUI()
    {
        //���̾� ����
        chk(0);

        //����Ʈ �ʱ�ȭ
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    }


    //���º���â ���� �ڵ�
    public void objuiopen()
    {
        currentEvent = EVENT;

        if (mode == 42)
        {
            for (int i = 0; i < sameobj.Count; i++)
            {
                if (sameobj.Count == 1)
                {
                    if (sameobj[i].gameObject.tag == "button")
                    {
                        if (sameobj[i].transform.parent.gameObject.GetComponent<ObjCode>().objStatus == 8)
                        {
                            EVENT = "8";
                        }
                    }
                    else
                    {
                        if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 4)
                        {
                            EVENT = "4"; //�����̴°�
                        }
                        else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 5)
                        {
                            EVENT = "5";
                        }
                        else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 6)
                        {
                            EVENT = "6";
                        }
                        else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 7)
                        {
                            EVENT = "7";
                        }

                        else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 9)
                        {
                            EVENT = "9";
                        }
                        else
                        {
                            EVENT = "0";
                            break;
                        }
                    }
                    
                }
                else
                {
                    if (sameobj.Count > i + 1)
                    {
                        if (sameobj[i].gameObject.name == sameobj[i + 1].gameObject.name)
                        {
                            if (i + 1 == sameobj.Count - 1)
                            {
                                if (sameobj[i].gameObject.tag == "button")
                                {
                                    if (sameobj[i].transform.parent.gameObject.GetComponent<ObjCode>().objStatus == 8)
                                    {
                                        EVENT = "8";
                                    }
                                }
                                else
                                {
                                    if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 4)
                                    {
                                        EVENT = "4"; //�����̴°�
                                    }
                                    else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 5)
                                    {
                                        EVENT = "5";
                                    }
                                    else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 6)
                                    {
                                        EVENT = "6";
                                    }
                                    else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 7)
                                    {
                                        EVENT = "7";
                                    }

                                    else if (sameobj[i].gameObject.GetComponent<ObjCode>().objStatus == 9)
                                    {
                                        EVENT = "9";
                                    }
                                    else
                                    {
                                        EVENT = "0";
                                        break;
                                    }
                                }                                
                            }
                            continue;
                        }
                        else
                        {
                            EVENT = "0";
                            break;
                        }
                    }
                }
            }
        }
    }
    public void changclick()
    {
        if (mode == 42)
        {
            change_obj_Data(objSize_Test, action_Obj, playerspeed, monsterspeed_Obj, connection_Obj, connection_it_Obj); //�÷��̾� �ӵ��� ������Ʈ �ӵ��� ����
        }

        //�ʱ�ȭ
    }

    void tastdsdt()
    {
        for (int i = 0; i < AllObj.Length; i++)
        {
            for (int j = 0; j < clicks.Count; j++)
            {
                if (AllObj[i].transform.position == clicks[j] && AllObj[i].gameObject.tag != "Untagged")
                {
                    if (sameobj.Contains(AllObj[i]))
                    {
                        //������ �ִ�.
                    }
                    else
                    {
                        sameobj.Add(AllObj[i]);
                    }
                }
            }
        }

        //UI�� ������ �����ض�
        if (sameobj.Count != 0)
        {
            objUI.GetComponent<ObjStateUI>().showSizeText();
            objUI.GetComponent<ObjStateUI>().showStateText();
            objUI.GetComponent<ObjStateUI>().showActionValueText();
            objUI.GetComponent<ObjStateUI>().showMonsterSpeedText();
            objUI.GetComponent<ObjStateUI>().showButtonConnectionText();
            objUI.GetComponent<ObjStateUI>().showWhatConnectionText();
            objUI.GetComponent<ObjStateUI>().showToggle();
        }
    }


    [Range(0, 1)]
    public float objSize_Test = 0.5f;       //������Ʈ ������ ����
    public float action_Obj = 1;
    public float speed_Obj = 0;
    public float monsterspeed_Obj = 10.0f;
    public float connection_Obj = 0;
    public float connection_it_Obj = 0;

    public float playerspeed = 10.0f; //�÷��̾� ���ǵ�



    public UnityEngine.UI.Slider size_O_Test; //�� ������ �����̴�
    public Text actionText; //�Ҹ� �ൿ�� �ؽ�Ʈ
    public Text speedText; //���� ���ǵ� �ؽ�Ʈ


    private void sizeSlider_O_Test()
    {
        objSize_Test = size_O_Test.value;
    }
    private void ActionChange()
    {
        if (actionText.text != "")
        {
            action_Obj = int.Parse(actionText.text);
        }
    }
    private void SpeedChange()
    {
        if (speedText.text != "")
        {
            speed_Obj = float.Parse(speedText.text);
        }
    }


    public void mapSizeChange()
    {
        mapSize.y = JasnData.GetComponent<jsonCode>().mapData_.map.Length;
        mapSize.x = JasnData.GetComponent<jsonCode>().mapData_.map[0].mapX.Length;
    }



    bool isSelecting = false;
    Vector3 mousePosition1;
    public List<GameObject> dragarea_obj = new List<GameObject>(); //Ʈ���������� �ٲ���ҵ�

    //���߼���
    private void multipleSelection()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out obj_hit) && (obj_hit.transform.tag == "aa" || obj_hit.transform.tag == "button" || obj_hit.transform.tag == "Monster" || obj_hit.transform.tag == "PlayerSpon" || obj_hit.transform.tag == "goal"))
                {
                    Vector3 a = obj_hit.transform.position;
                    if (clicks.Contains(a))
                    {
                        obj_hit.transform.gameObject.layer = 0;
                        sameobj = new List<GameObject>();
                        Debug.Log("������ �ִ�.");
                        clicks.Remove(a);
                    }
                    else
                    {
                        clicks.Add(a);
                    }
                }
            }
        }
        //chk(7);
    }
    private float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;
    private void DoubleClick()
    {
        if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
        {
            m_IsOneClick = false;
        }

        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!m_IsOneClick)
            {
                m_Timer = Time.time;
                m_IsOneClick = true;
            }
            else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
            {
                m_IsOneClick = false;

                chk(0);
                //����Ʈ �ʱ�ȭ
                clicks = new List<Vector3>();
                sameobj = new List<GameObject>();
            }
        }
    }
    
    private void mouseDragArea()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            chk(0);
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }

        if (Input.GetMouseButtonDown(0) && isSelecting == false)
        {
            dragarea_obj = new List<GameObject>();
        }

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;

            chk(0);
            //����Ʈ �ʱ�ȭ
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }

        if (Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.LeftControl))
        {
            var selectedObjects = new List<GameObject>();
            foreach (var selectableObject in FindObjectsOfType<GameObject>())
            {
                if (IsWithinSelectionBounds(selectableObject.gameObject))
                {
                    selectedObjects.Add(selectableObject);
                    //-----------------
                    if (selectableObject.tag == "aa" || selectableObject.tag == "Monster" || selectableObject.tag == "PlayerSpon" || selectableObject.tag == "goal")
                    {
                        dragarea_obj.Add(selectableObject);
                    }
                    else if (selectableObject.tag == "button")
                    {
                        dragarea_obj.Add(selectableObject.transform.parent.gameObject);
                    }
                }
            }

            for (int i = 0; i < dragarea_obj.Count; i++)
            {
                clicks.Add(dragarea_obj[i].gameObject.transform.position);
            }

            isSelecting = false;
        }
    }
    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!isSelecting)
            return false;

        var camera = Camera.main;
        var viewportBounds = Utils.GetViewportBounds(camera, mousePosition1, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
    }
    void OnGUI()
    {
        if (isSelecting)
        {
            // Create a rect from both mouse positions
            var rect = Utils.GetScreenRect(mousePosition1, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    //public void 

    //-------------------------------------------------------------------------

    public void OnBtnClick(int num) //���42���� ������ ������Ʈ�� ������ �̰� ����
    {         
        if (num == 0) //�ʱ�ȭ
        {
            CanvasGroupOff(moveGroup);
        }
        else
        {
            CanvasGroupOn(moveGroup);
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



    //�Է� �޴��� �ؽ�Ʈ
    public Text action_;
    public Text misson1_;
    public Text misson2_;


   


    //-------------------------------------------------------------------------
    private void Update()
    {
        mapT.text = "Map Size: " + (int)mapSize.x + "x" + (int)mapSize.y; //text �ʱ�ȭ

        if (mode == 0)
        {
            brushT.text = "Brush Mode: " + "NULL";
        }

        BrushRay();
        chk(7); //���̾� ����
        DoubleClick(); //����Ŭ��
        mouseDragArea(); //�巡��
        multipleSelection(); //���߼���
        //changestage_Data();
        tastdsdt(); //Ŭ���� ������Ʈ �����ϴ°�
        //�̵��ϴ� ����
        if (mode == 40)
        {
            brushT.text = "Brush Mode: " + "Move";
            //move_obj();
            if (Input.GetMouseButtonUp(0))
            {
                move_Prefab();
            }
        }
        else
        {
            move_obj_clean();
        }

        //objuiopen();

        if (mode == 42)
        {
            if (clicks.Count == 0)
            {
                currentEvent = EVENT;
                EVENT = "0";
            }
            else
            {
                currentEvent = EVENT;
                EVENT = "4";
            }
        }

    }
}



//-------------------------------------------------------------------------
[System.Serializable]
public class BBBB
{
    public int[] mapX = new int[10]; //���� x��
    //public int[] mapY = new int[10]; //���� y��
}
[System.Serializable]
public class AAAA
{
    public BBBB[] map = new BBBB[10];
}



[System.Serializable]
public class od
{
    public float[] oData = new float[7]; //1.������Ʈ ����, 2. ������Ʈ ũ��, 3.�Ҹ��ൿ��, 4. ���ǵ� , 5.���� ���ǵ�, 6.�������Ʈ�� ����Ǿ� �ִ���, 7.��͵��� ����Ǿ� �ִ���
}
[System.Serializable]
public class odata
{
    public od[] mapX = new od[5]; //���� x��
}
[System.Serializable]
public class ODATA
{
    public odata[] map = new odata[5]; //���� y��
}

[System.Serializable]
public class STAGEDATA //1.�������� �ൿ�� 2. �̼�1(�ð�) 3. �̼�2(�ּ� ���� �ൿ��), 4. ���� ���� �� ���� ��
{
    public int[] stageData = new int[4];
}
