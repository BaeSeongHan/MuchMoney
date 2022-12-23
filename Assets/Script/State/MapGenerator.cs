using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using System.Text;



public class MapGenerator : MonoBehaviour
{
    public int mode; //현재 모드 나타내기
    public Camera get_Camera; //카메라 가져올곳
    public GameObject map_x; //x값 입력받을거 가져오는곳
    public GameObject map_y; //y값 입력받을거 가져오는곳
    //public GameObject M; //자기자신
    public Text mapT; // 맵 크기 보여주는 text 가져오는곳
    public Text brushT; //브러쉬 모드 텍스트


    public Text action; //입력받은 행동력 텍스트
    public Text misson1; //입력받은 미션1 텍스트
    public Text misson2; //입력받은 미션2 텍스트

    //-----------------------------
    public GameObject tree_ack; //나무가 소모하는 행동력 가져오는것
    //-----------------------------
    public Transform wPrefab; //타일 프리팹
    public Transform gPrefab; //타일 프리팹
    public Vector2 mapSize; //맵 사이즈
    [Range(0, 1)]
    public float blockSize;       //블럭 사이즈 지정
    public UnityEngine.UI.Slider size_B; //블럭 사이즈 슬라이더
    //-----------------------------
    public Transform playerSponObj; //플레이어 스폰 오브젝트 들어가는곳

    public Transform objPrefab_tree; //오브젝트 프리팹 들어가는곳 1
    public Transform objPrefab_rook; //오브젝트 프리팹 들어가는곳 2
    public Transform objPrefab_Button; //오브젝트 프리팹 들어가는곳 3
    public Transform objPrefab_Monster; //오브젝트 프리팹 들어가는곳 5
    public Transform objPrefab_Wall; //오브젝트 프리팹 들어가는곳 4
    public Transform objPrefab_Goal; //오브젝트 프리팹 들어가는곳 6
    public Transform objPrefab_moverook; //오브젝트 프리팹 들어가는곳 7
    public Transform objPrefab_coin; //오브젝트 프리팹 들어가는곳 8
    public Transform objPrefab_Wall_1; //오브젝트 프리팹 들어가는곳 9
    public Transform objPrefab_Wall_2; //오브젝트 프리팹 들어가는곳 10
    [Range(0, 1)]
    public float objSize;       //오브젝트 사이즈 지정
    public UnityEngine.UI.Slider size_O; //블럭 사이즈 슬라이더

    //제이슨 파일 불러오는 곳(맵) 아직 제이슨파일에서 불러오는거 아님

    //public AAAA objData_Test;

    public AAAA mapData_Test;
    public ODATA O_Test;
    public STAGEDATA stageData_Test;

    public List<Vector3> clicks = new List<Vector3>(); //클릭한거 넣을 vector3리스트


    public GameObject[] AllObj; //모든오브젝트 넣을 배열

    public GameObject[] AllTree; //모든나무오브젝트 넣을 배열

    public List<GameObject> MoveObj = new List<GameObject>(); //모든 움직일 게임오브젝트 담을 리스트





    public CanvasGroup moveGroup;


    public GameObject JasnData; //제이슨 데이터 가져올 곳
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroupOff(moveGroup);


        mapT.text = "Map Size: " + (int)mapSize.x + "x" + (int)mapSize.y; //text 초기화
        mapData_Test = reset_m((int)mapSize.x, (int)mapSize.y); //초기화
        O_Test = reset_m_Test((int)mapSize.x, (int)mapSize.y); //초기화
        stageData_Test = reset_stageData(4);//초기화

        JasnData.GetComponent<jsonCode>().mapData_ = mapData_Test;
        JasnData.GetComponent<jsonCode>().objData_ = O_Test;
        JasnData.GetComponent<jsonCode>().stageData_misson = reset_stageData(4);

        GenerateMap();
    }

    //위 맵 생성 타일 포지션
    Vector3 CoordToPosition(int i, int j)
    {
        return new Vector3(i, 0, j);
    }

    //맵데이터 변경
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
    //오브젝트 데이터 변경
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
    //스테이지 데이터 변경

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

    public int coinc = 0; //코인카운터 가져올거

    public void GenerateMap()
    {
        coinc = 0; //코인 카운터 다시 초기화
        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        //맵 생성코드
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
        //오브젝트 생성코드
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 blockPos = CoordToPosition(y, x);


                if (O_Test.map[y].mapX[x].oData[0] == 1)
                {
                    Transform newObj = Instantiate(objPrefab_tree, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }
                else if (O_Test.map[y].mapX[x].oData[0] == 2)
                {
                    Transform newObj = Instantiate(objPrefab_rook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 3)
                {
                    Transform newObj = Instantiate(objPrefab_Button, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 4)
                {
                    Transform newObj = Instantiate(objPrefab_Wall, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 5)
                {
                    Transform newObj = Instantiate(objPrefab_Monster, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 6)
                {
                    Transform newObj = Instantiate(objPrefab_Goal, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 7)
                {
                    Transform newObj = Instantiate(objPrefab_moverook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 8)
                {
                    Transform newObj = Instantiate(objPrefab_coin, blockPos + Vector3.up * 0.3f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];
                    coinc++;
                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 9)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_1, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (O_Test.map[y].mapX[x].oData[0] == 10)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_2, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Speed = (float)O_Test.map[y].mapX[x].oData[3];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().monster_Speed = (float)O_Test.map[y].mapX[x].oData[4];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection = (int)O_Test.map[y].mapX[x].oData[5];
                    newObj.transform.GetChild(0).gameObject.GetComponent<ObjCode>().obj_Connection_It = (int)O_Test.map[y].mapX[x].oData[6];

                    newObj.parent = mapHolder;
                }
                else if (O_Test.map[y].mapX[x].oData[0] == 19)
                {
                    Transform newObj = Instantiate(playerSponObj, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (O_Test.map[y].mapX[x].oData[1]); //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Size = (float)O_Test.map[y].mapX[x].oData[1]; //오브젝트 사이즈
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)O_Test.map[y].mapX[x].oData[2]; //오브젝트 소모 행동력

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


    //change_m같은거
    //------------------------------------


    //------------------------------------
    //오브젝트 상태만 변경
    public void change_obj_Prefab(int prefab, int num)
    {
        //부스는거 가능한 오브젝트
        if (num == 1)
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 2) //움직이는 오브젝트
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 10.0f; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 3) //몬스터
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.2f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 3; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 10.0f; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 4) //상호작용 불가능 오브젝트
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 5) //버튼
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 6) //포탈 or 생겼다 사라졌다 하는 오브젝트
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장(활성화 비활성화)
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장
            }
            GenerateMap();
            //리스트 초기화
            clicks = new List<Vector3>();
            sameobj = new List<GameObject>();
        }
        else if (num == 7) //플레이어 스폰
        {
            for (int i = 0; i < clicks.Count; i++)
            {
                int g_x;
                int g_y;
                g_x = (int)clicks[i].x;
                g_y = (int)clicks[i].z;

                O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
                O_Test.map[g_x].mapX[g_y].oData[1] = 0.4f; //1번째에 사이즈을 저장
                O_Test.map[g_x].mapX[g_y].oData[2] = 0; //2번째에 소모 행동력을 저장
                O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[4] = 0; //4번째에 몬스터 스피드 저장
                O_Test.map[g_x].mapX[g_y].oData[5] = 0; //5번째에 어떤오브젝트랑 연결되어있는지 저장(활성화 비활성화)
                O_Test.map[g_x].mapX[g_y].oData[6] = 0; //6번째에 어떤것들이 연결되어 있는지 저장

            }
            GenerateMap();
            //리스트 초기화
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

            O_Test.map[g_x].mapX[g_y].oData[0] = (float)prefab; //0번째에 1을 저장
            O_Test.map[g_x].mapX[g_y].oData[1] = 0.5f; //1번째에 사이즈을 저장
            O_Test.map[g_x].mapX[g_y].oData[2] = 1; //2번째에 소모 행동력을 저장
            O_Test.map[g_x].mapX[g_y].oData[3] = 0; //3번째에 스피드 저장
        }
        GenerateMap();
        //리스트 초기화
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

            O_Test.map[g_x].mapX[g_y].oData[1] = size; //1번째에 사이즈을 저장
            O_Test.map[g_x].mapX[g_y].oData[2] = state; //2번째에 소모 행동력을 저장
            O_Test.map[g_x].mapX[g_y].oData[3] = speed; //3번째에 스피드 저장
            O_Test.map[g_x].mapX[g_y].oData[4] = monsterspeed; //4번째에 몬스터 스피드 저장
            O_Test.map[g_x].mapX[g_y].oData[5] = connection; //5번째에 어떤오브젝트랑 연결되어있는지 저장(활성화 비활성화)
            O_Test.map[g_x].mapX[g_y].oData[6] = connection_it; //6번째에 어떤것들이 연결되어 있는지 저장


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
            mapData_Test.map[g_x].mapX[g_y] = 0; //땅으로 만들기
        }
        GenerateMap();
        //리스트 초기화
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
                    //중복한게 있으면 아무것도 안넣기
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
                    //중복한게 있으면 아무것도 안넣기
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
                    //중복한게 있으면 아무것도 안넣기
                }
                else
                {
              
                    MoveObj.Add(AllObj[i]);
                }
            }
        }
        //여기에 동시 이동 넣어야 한다.

        
        O_Test = reset_m_Test((int)mapSize.x, (int)mapSize.y); //초기화
        for (int i = 0; i < MoveObj.Count; i++)
        {

            //초기화 추가
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
        //리스트 초기화
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



    public int stagedataaction; //스테이지 데이터 변경
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

        mapData_Test = change_m((int)mapSize.x, (int)mapSize.y, mapData_Test); //초기화 (기존에 있던 수는 그대로 가지고 초기화 하고싶다)
        O_Test = change_ODATA((int)mapSize.x, (int)mapSize.y, O_Test); //초기화 (기존에 있던 수는 그대로 가지고 초기화 하고싶다)
        stageData_Test = change_STAGEDATA(stageData_Test);


        JasnData.GetComponent<jsonCode>().mapData_ = mapData_Test;
        JasnData.GetComponent<jsonCode>().objData_ = O_Test;
        JasnData.GetComponent<jsonCode>().stageData_misson = stageData_Test;

        GenerateMap();
    }


    RaycastHit obj_hit;

    //오브젝트 선택한거 알려주는 쉐이더 설정
    void chk(int num)
    {
        //clicks의 벡터값과 같은 오브젝트가 있으면 그 오브젝트의 레이어를 변경한다.

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
        //트리 브러쉬
        if (mode == 1) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_tree();
                        change_obj_Prefab(1, 1);
                    }
                }
            }
        }
        //바위 브러쉬
        else if (mode == 2) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_rook();
                        change_obj_Prefab(2, 1);
                    }
                }
            }
        }
        //버튼 브러쉬
        else if (mode == 3) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_button();
                        change_obj_Prefab(3, 5);
                    }
                }
            }
        }
        //벽 브러쉬
        else if (mode == 4) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_wall();
                        change_obj_Prefab(4, 6);
                    }
                }
            }
        }
        //몬스터 브러쉬
        else if (mode == 5) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_monster();
                        change_obj_Prefab(5, 3);
                    }
                }
            }
        }
        //골인지점 브러쉬
        else if (mode == 6) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_goal();
                        change_obj_Prefab(6, 6);
                    }
                }
            }
        }
        //움직이는 바위 브러쉬
        else if (mode == 7) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_moverook();
                        change_obj_Prefab(7, 2);
                    }
                }
            }
        }
        //코인 브러쉬
        else if (mode == 8) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_moverook();
                        change_obj_Prefab(8, 4);
                    }
                }
            }
        }
        //벽1
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_moverook();
                        change_obj_Prefab(9, 4);
                    }
                }
            }
        }
        //벽2
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_moverook();
                        change_obj_Prefab(10, 4);
                    }
                }
            }
        }
        //플레이어 스폰위치
        else if (mode == 19) //이거 일때 마우스 포인터 변경
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        change_obj_Prefab(19, 7);
                    }
                }
            }
        }


        //그라운드 브러쉬
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_tree();
                        change_ground_Prefab(0);
                    }
                }
            }
        }
        //워터 브러쉬
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
                        Debug.Log("같은게 있다.");
                    }
                    else
                    {
                        clicks.Add(a); //리스트에 더하기
                        //change_obj_tree();
                        change_ground_Prefab(1);
                    }
                }
            }
        }
        //제거 브러쉬
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
                        Debug.Log("같은게 있다.");
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
        //오브젝트 스텟 변경
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
                        
                        Debug.Log("같은게 있다.");
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

            //여기에 하고싶은 행동 실행

            OnBtnClick(int.Parse(EVENT));

            Debug.Log(CURRENT_EVENT);
        }
        get
        {
            return CURRENT_EVENT;
        }
    }


    //변경이 있을 때 실행

    public  List<GameObject> sameobj = new List<GameObject>(); //클릭한 오브젝트 넣을 리스트
    public GameObject objUI; //오브젝트 UI
    
    
    public void clickUI()
    {
        //레이어 변겨
        chk(0);

        //리스트 초기화
        clicks = new List<Vector3>();
        sameobj = new List<GameObject>();
    }


    //상태변경창 띄우는 코드
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
                            EVENT = "4"; //움직이는거
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
                                        EVENT = "4"; //움직이는거
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
            change_obj_Data(objSize_Test, action_Obj, playerspeed, monsterspeed_Obj, connection_Obj, connection_it_Obj); //플레이어 속도와 오브젝트 속도는 동일
        }

        //초기화
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
                        //같은게 있다.
                    }
                    else
                    {
                        sameobj.Add(AllObj[i]);
                    }
                }
            }
        }

        //UI의 스텟을 변경해라
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
    public float objSize_Test = 0.5f;       //오브젝트 사이즈 지정
    public float action_Obj = 1;
    public float speed_Obj = 0;
    public float monsterspeed_Obj = 10.0f;
    public float connection_Obj = 0;
    public float connection_it_Obj = 0;

    public float playerspeed = 10.0f; //플레이어 스피드



    public UnityEngine.UI.Slider size_O_Test; //블럭 사이즈 슬라이더
    public Text actionText; //소모 행동력 텍스트
    public Text speedText; //몬스터 스피드 텍스트


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
    public List<GameObject> dragarea_obj = new List<GameObject>(); //트랜스폼으로 바꿔야할듯

    //다중선택
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
                        Debug.Log("같은게 있다.");
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
                //리스트 초기화
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
            //리스트 초기화
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
            //리스트 초기화
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

    public void OnBtnClick(int num) //모드42에서 선택한 오브젝트가 있으면 이거 실행
    {         
        if (num == 0) //초기화
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



    //입력 받는쪽 텍스트
    public Text action_;
    public Text misson1_;
    public Text misson2_;


   


    //-------------------------------------------------------------------------
    private void Update()
    {
        mapT.text = "Map Size: " + (int)mapSize.x + "x" + (int)mapSize.y; //text 초기화

        if (mode == 0)
        {
            brushT.text = "Brush Mode: " + "NULL";
        }

        BrushRay();
        chk(7); //레이어 변경
        DoubleClick(); //더블클릭
        mouseDragArea(); //드래그
        multipleSelection(); //다중선택
        //changestage_Data();
        tastdsdt(); //클릭한 오브젝트 저장하는곳
        //이동하는 모드면
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
    public int[] mapX = new int[10]; //맵의 x값
    //public int[] mapY = new int[10]; //맵의 y값
}
[System.Serializable]
public class AAAA
{
    public BBBB[] map = new BBBB[10];
}



[System.Serializable]
public class od
{
    public float[] oData = new float[7]; //1.오브젝트 상태, 2. 오브젝트 크기, 3.소모행동력, 4. 스피드 , 5.몬스터 스피드, 6.어떤오브젝트랑 연결되어 있는지, 7.어떤것들이 연결되어 있는지
}
[System.Serializable]
public class odata
{
    public od[] mapX = new od[5]; //맵의 x값
}
[System.Serializable]
public class ODATA
{
    public odata[] map = new odata[5]; //맵의 y값
}

[System.Serializable]
public class STAGEDATA //1.스테이지 행동력 2. 미션1(시간) 3. 미션2(최소 보유 행동력), 4. 현제 게임 의 코인 수
{
    public int[] stageData = new int[4];
}
