using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform blockPrefab; //블록 프리팹 들어가는곳
    public Transform wPrefab; //물 프리팹 들어가는곳 예시

    public Transform objPrefab; //오브젝트 프리팹 들어가는곳 1
    public Transform objPrefab_rook; //오브젝트 프리팹 들어가는곳 2
    public Transform objPrefab_Button; //오브젝트 프리팹 들어가는곳 3

    public Transform objPrefab_Monster; //오브젝트 프리팹 들어가는곳 5
    public Transform objPrefab_Wall; //오브젝트 프리팹 들어가는곳 4
    public Transform objPrefab_Goal; //오브젝트 프리팹 들어가는곳 6
    public Transform objPrefab_moverook; //오브젝트 프리팹 들어가는곳 7
    public Transform objPrefab_coin; //오브젝트 프리팹 들어가는곳 8


    public Transform objPrefab_Wall_1; //오브젝트 프리팹 들어가는곳 9
    public Transform objPrefab_Wall_2; //오브젝트 프리팹 들어가는곳 10


    public Vector2 mapSize;       //맵 사이즈 정하는곳 -> 맵구조를 넣는걸로 변경


    //제이슨 파일 불러오는곳
    public Transform Data; //데이터 가져오는거


    public GameObject actionBar; //행동력 오브젝트 가져올거

    public int actionPoint; //행동력 설정
    
    public int minActionPoint; //최소 보유 행동력
    public int limttime; // 별얻을수있는 최소 시간
    public int coin_Count; //스테이지에 있는 코인 수

    //public int nowCoinCount; //현재 먹은 코인 카운트

    //??
    public Button_obj b_obj;


    public void GenerateMap()
    {
        int a = Data.GetComponent<jsonCode>().mapData_.map.Length; //x값
        int b = Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length; //y값

        mapSize = new Vector2(a, b);

                string holderName = "MMM";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform; //맵 블럭 상위 트렌스폼 만들어서 부모로 넣기
        mapHolder.parent = transform;

        //맵 생성
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                Vector3 blockPos = CoordToPosition(i, j);


                if (Data.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 0 || Data.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 2)
                {
                    Transform newBlock = Instantiate(blockPrefab, blockPos, Quaternion.identity);
                    newBlock.localScale = Vector3.one;
                    newBlock.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 1)
                {
                    Transform newBlock = Instantiate(wPrefab, blockPos, Quaternion.identity);
                    newBlock.localScale = Vector3.one;
                    newBlock.parent = mapHolder;
                }
            }
        }
        //오브젝트 생성
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                Vector3 blockPos = CoordToPosition(i, j);


                if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 1)
                {
                    Transform newObj = Instantiate(objPrefab, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 2)
                {
                    Transform newObj = Instantiate(objPrefab_rook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 3)
                {
                    Transform newObj = Instantiate(objPrefab_Button, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];


                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 4)
                {
                    Transform newObj = Instantiate(objPrefab_Wall, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.transform.GetChild(0).GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 5)
                {
                    Transform newObj = Instantiate(objPrefab_Monster, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }


                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 6)
                {
                    Transform newObj = Instantiate(objPrefab_Goal, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 7)
                {
                    Transform newObj = Instantiate(objPrefab_moverook, blockPos + Vector3.up * 0.1f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 8)
                {
                    Transform newObj = Instantiate(objPrefab_coin, blockPos + Vector3.up * 0.3f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 9)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_1, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.transform.GetChild(0).GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }

                else if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 10)
                {
                    Transform newObj = Instantiate(objPrefab_Wall_2, blockPos + Vector3.up * 0.01f, Quaternion.identity) as Transform;   //오브젝트 생성
                    newObj.localScale = Vector3.one * (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[1]);      //오브젝트 크기 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Ack = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[2];//오브젝트 소모 행동력 설정
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Speed = Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[3];   //오브젝트 스피드 설정

                    newObj.transform.GetChild(0).GetComponent<ObjCode>().monster_Speed = (float)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[4];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[5];
                    newObj.transform.GetChild(0).GetComponent<ObjCode>().obj_Connection_It = (int)Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[6];

                    newObj.parent = mapHolder;
                }
            }
        }      
    }

    //위 맵 생성 타일 포지션
    Vector3 CoordToPosition(int i, int j)
    {
        return new Vector3(i,0 ,j);
    }

    // Start is called before the first frame update
    void Start()
    {
        actionPoint = Data.GetComponent<jsonCode>().stageData_misson.stageData[0]; //스테이지 행동력 Load
        actionBar.GetComponent<HPbar>().maxHitPoint = actionPoint; //Hp바
        minActionPoint = Data.GetComponent<jsonCode>().stageData_misson.stageData[1]; //미션 1 최소 보유 행동력
        limttime = Data.GetComponent<jsonCode>().stageData_misson.stageData[2]; //미션2 시간
        coin_Count = Data.GetComponent<jsonCode>().stageData_misson.stageData[3];  //스테이지에 있는 코인 수 초기화

        GenerateMap();
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                if (Data.GetComponent<jsonCode>().objData_.map[i].mapX[j].oData[0] == 19) //2. 플레이어 소환하는곳
                {
                    Debug.Log("플레이어 소환");
                    Vector3 playerSpown = CoordToPosition(i, j);
                    Quaternion rotation = Quaternion.identity;
                    rotation.eulerAngles = new Vector3(0, 90, 0);
                    Instantiate(GameManager.instance.playerPrefab, playerSpown, rotation);
                }
            }
        }

        //GameManager.instance.iron = objCount_rook;
    }
}

[System.Serializable]
public class Wall_Pos
{
    public int[] wall_Pos = new int[2]; //맵의 x값
}

[System.Serializable]
public class Wall_C
{
    public Wall_Pos[] wall_Pos_C = new Wall_Pos[2]; //맵의 x값
    
}
[System.Serializable]
public class Button_obj
{
    public Wall_C[] button = new Wall_C[5];
}
