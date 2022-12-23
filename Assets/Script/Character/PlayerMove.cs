using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10.0f;  //플레이어 스피드
    public float playerRotateSpeed = 10.0f;  //플레이어 회전 스피드

    public Vector3 nowVector;     //현재 위치벡터
    public Vector3 moveVector;    //이동할 위치벡터
    public Vector3 targetVector;  //보고있는 방향의 위치벡터

    private Quaternion startingRotation;   //플레이어가 가지고 있는 회전 값의 쿼터니언

    //------------------------------------------------------

    public Transform lookObj; //보고있는 방향의 오브젝트 넣는 곳 
    public Transform L_Obj; //선택한 오브젝트 넣는 곳 

    public GameObject[] allObj; //모든오브젝트 넣을 배열

    //------------------------------------------------------

    public int actionPoint; //행동력
    public int coinCount; //코인 먹어야 하는 수 -> 바꿔야함
    public int minActionPoint; //최소 보유 행동력
    public int LimitTimer;
    public GameObject timer; //시간 오브젝트 가져올거



    public int coin_Count; //스테이지에 있는 코인 수

    public GameObject[] coin; //코인 오브젝트
    public int nowCoinCount; //현재 먹은 코인 카운트


    //------------------------------------------------------

    public GameObject stayBlook;  //현재 서있는 블럭
    public GameObject lookBlook;  //보고있는 방향의 블럭

    //------------------------------------------------------
    public bool moveBool; //이동 가능한지 불가능한지 판별
    //------------------------------------------------------

    public GameObject inventory; //인벤토리

    public GameObject endUI; //끝나는창 UI
    //------------------------------------------------------

    private Animator animator; //캐릭터 애니메이터 관리?
    //------------------------------------------------------

    public Transform goal; //골인지점 찾기

    public GameObject Map; //맵 데이터 가져올 곳

    public GameObject StageText; //스테이지 텍스트 가져올거
    public GameObject FAIL; //스테이지 텍스트 가져올거
    public GameObject NextButton; //다음스테이지 버튼 가져올거


    public bool isAtk = false; //공격을 받았는지
    public bool isEnd = false; //끝났는지 알려주기 

    public GameObject hpbar;

    int llll; //보는방향 인트




    //------------------------------------------------------
    public ParticleSystem pRock; //파티클 넣을거
    public ParticleSystem pWood;
    public GameObject moveParticle; //움직일때 파티클 생성

    public bool moveParticleTrue = true; // 움직이는 파티클 이미 켰는지 아닌지 판단
                                         //------------------------------------------------------


    //------------------------------------------------------

    public GameObject objStateText; //오브젝트 상태 받아올 텍스트


    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        //초기화
        moveParticleTrue = true;
        startingRotation = transform.rotation;
        targetVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        objStateText = GameObject.Find("SSS");

        inventory = GameObject.Find("InventoryObj");
        endUI = GameObject.Find("EndUI");
        StageText = GameObject.Find("StageText");
        FAIL = GameObject.Find("Fail");
        NextButton = GameObject.Find("Next");
        endUI.SetActive(false);
        moveBool = true;

        Map = GameObject.Find("MapData(1)");

        allObj = GameObject.FindGameObjectsWithTag("aa");
        //스테이지 데이터 상태 초기화
        actionPoint = GameObject.Find("GameManager").GetComponent<MapManager>().actionPoint;

        coin_Count = GameObject.Find("GameManager").GetComponent<MapManager>().coin_Count;
        minActionPoint = GameObject.Find("GameManager").GetComponent<MapManager>().minActionPoint;
        LimitTimer = GameObject.Find("GameManager").GetComponent<MapManager>().limttime;
        timer = GameObject.Find("Timer");


        nowCoinCount = 0;

        FindUi();
        animator = GetComponent<Animator>();


        //===========================================================
        potal = GameObject.FindGameObjectsWithTag("goal");
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        Look_Player();
        Move_Player();
        Obj_Action();
        Find_Obj();
        Obj_Ui();
        Player_Ui();


        if (isEnd == false)
        {
            Action_Point();
            EndGame();//게임 끝나는지 판단
        }
        


        Potal();



        transform.position = Vector3.MoveTowards(transform.position, moveVector, playerSpeed * Time.deltaTime);
    }

    


    void Look_Player() //플레이어가 보는 방향 설정
    {
        if (transform.position == nowVector)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) //위
            {
                SoundManger.instance.TurnSound();
                StopAllCoroutines();
                StartCoroutine(Rotate(-90));
                llll = 1;
                targetVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) //오른쪽
            {
                SoundManger.instance.TurnSound();
                StopAllCoroutines();
                StartCoroutine(Rotate(0));
                llll = 2;
                targetVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))  //왼쪽
            {
                SoundManger.instance.TurnSound();
                StopAllCoroutines();
                StartCoroutine(Rotate(-180));
                llll = 3;
                targetVector = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow))    //아래
            {
                SoundManger.instance.TurnSound();
                StopAllCoroutines();
                StartCoroutine(Rotate(90));
                llll = 4;
                targetVector = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
        }
    }

    //회전 코루틴
    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, rotationAmount, 0) * startingRotation;

        while (transform.rotation != finalRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * playerRotateSpeed);
            yield return 0;
        }
    }



    void Move_Player() //스페이스바 눌렀을때 보는 방향으로 한칸 이동
    {

        if (moveBool == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //파티클생성
                if (moveParticleTrue)
                {
                    SoundManger.instance.MoveSound();
                    Instantiate(moveParticle, gameObject.transform.position, moveParticle.transform.rotation);
                    moveParticleTrue = false;
                }
                


                moveVector = targetVector; //이동할 위치벡터와 타겟벡터 같게해줘서 이동시키기
                //애니메이션 키기
                //animator.SetFloat("Walk", 0.0f);
                //animator.SetFloat("Walk", 1.0f);
            }


            if (transform.position == targetVector) //현재 위치가 타겟벡터와 같을때 타겟벡터 변경하기
            {
                if (nowVector != moveVector)
                {
                    Vector3 a = nowVector - moveVector;

                    //Debug.Log(a);
                    //Debug.Log(targetVector);
                    //Debug.Log(targetVector - a);
                    targetVector = targetVector - a;
                    nowVector = moveVector;

                    moveParticleTrue = true;
                    actionPoint -= 1; //행동력 소모

                    //애니메이션 꺼주기
                    //animator.SetFloat("Walk", 0.0f);
                }
            }
        }

        if (moveBool == false  && lookObj == null)
        {
            //화면 흔들림

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManger.instance.DontMoveSound();

            }
        }
        else if (moveBool == false && lookObj != null)
        {
            if (lookObj.GetComponent<ObjCode>().objStatus == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SoundManger.instance.DontMoveSound();

                }
            }
        }
    }


    public Sprite image;
    public Sprite image_wood;




    void Obj_Action() //오브젝트와 상호작용
    {
        if (lookObj != null)
        {
            if (lookObj.transform.position.x == targetVector.x && lookObj.transform.position.z == targetVector.z)  // 변경부분
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //L_Obj = lookObj;

                    //스테이지 클리어 이거 왜있음?
                    if (lookObj.GetComponent<ObjCode>().objStatus == 0)
                    {
                        Debug.Log("스테이지 클리어");
                    }



                    if (lookObj.GetComponent<ObjCode>().objStatus == 4) //저게 4이라면
                    {
                        if ((lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).x < 0 || (lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).z < 0)
                        {
                            lookObj.GetComponent<ObjCode>().moveObj = false; //움직이지 말아라
                        }
                        else
                        {
                            for (int i = 0; i < Map.GetComponent<jsonCode>().mapData_.map.Length; i++)
                            {
                                for (int j = 0; j < Map.GetComponent<jsonCode>().mapData_.map[0].mapX.Length; j++)
                                {
                                    if ((lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).x == i && (lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).z == j)
                                    {

                                        for (int k = 0; k < allObj.Length; k++)
                                        {
                                            if (allObj[k] != null)
                                            {
                                                //이조건은 움직여야하는 오브젝트가 움직이는곳에 오브젝트가 있으면
                                                if (allObj[k].transform.position.x == i && allObj[k].transform.position.z == j)
                                                {
                                                    lookObj.GetComponent<ObjCode>().moveObj = false; //움직이지 말아라
                                                    return;
                                                }
                                                else
                                                {
                                                }
                                            }
                                        }

                                        if (Map.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 1) //물이면
                                        {
                                            lookObj.GetComponent<ObjCode>().moveObj = false; //움직이지 말아라
                                            break;
                                        }
                                        else
                                        {
                                            lookObj.GetComponent<ObjCode>().moveObj = true; //움직이라고 알려주기
                                            lookObj.GetComponent<ObjCode>().moveVector_Obj = lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector);

                                            SoundManger.instance.MoveObjSound();
                                            actionPoint -= lookObj.GetComponent<ObjCode>().obj_Ack;
                                            break;
                                        }
                                    } 
                                }
                            }   
                        }
                        return;
                    }                    //움직이는 오브젝트
                    else if (lookObj.GetComponent<ObjCode>().objStatus == 5)
                    {
                        Debug.Log("제거가능한 오브젝트");
                        //아이템을 획득하면 아이템슬롯으로 이동?
                        if (lookObj.GetComponent<ObjCode>().obj_State == 2) //저게 1이라면
                        {

                            Item _item = new Item();

                            _item.itemName = "철광석";
                            _item.itemImage = image;
                            _item.itemType = ItemType.Etc;
                            GameManager.instance.iron--; //철 카운트 내리기?

                            if (Inventory.instance.items.Count < Inventory.instance.SlotCnt)
                            {
                                if (Inventory.instance.items.Count == 0)
                                {
                                    Inventory.instance.items.Add(_item);
                                }
                                for (int i = 0; i < Inventory.instance.items.Count; i++)
                                {
                                    if (Inventory.instance.items[i].itemName == _item.itemName)
                                    {
                                        Inventory.instance.items[i].num++;
                                        //Debug.Log("break");
                                        break;
                                    }
                                    else if (Inventory.instance.items[i].itemName != _item.itemName)
                                    {
                                        if (i < Inventory.instance.items.Count - 1)
                                        {
                                            //Debug.Log("continue");
                                            continue;
                                        }
                                    }

                                    Inventory.instance.items.Add(_item);

                                }
                            }


                            SoundManger.instance.DestroySound();
                            actionPoint -= lookObj.GetComponent<ObjCode>().obj_Ack;
                            Instantiate(pRock, lookObj.gameObject.transform.position, pRock.transform.rotation);
                            Destroy(lookObj.gameObject);
                            return;
                        }
                        else if (lookObj.GetComponent<ObjCode>().obj_State == 1) //저게 2이라면
                        {
                            Item _item = new Item();

                            _item.itemName = "나무";
                            _item.itemImage = image_wood;
                            _item.itemType = ItemType.Etc;

                            if (Inventory.instance.items.Count < Inventory.instance.SlotCnt)
                            {
                                if (Inventory.instance.items.Count == 0)
                                {
                                    Inventory.instance.items.Add(_item);
                                }
                                for (int i = 0; i < Inventory.instance.items.Count; i++)
                                {

                                    if (Inventory.instance.items[i].itemName == _item.itemName)
                                    {
                                        Inventory.instance.items[i].num++;
                                        //Debug.Log("break");
                                        break;
                                    }
                                    else if (Inventory.instance.items[i].itemName != _item.itemName)
                                    {
                                        if (i < Inventory.instance.items.Count - 1)
                                        {
                                            //Debug.Log("continue");
                                            continue;
                                        }
                                    }

                                    Inventory.instance.items.Add(_item);

                                }
                            }

                            SoundManger.instance.DestroySound();

                            actionPoint -= lookObj.GetComponent<ObjCode>().obj_Ack;
                            Instantiate(pWood, lookObj.gameObject.transform.position, pWood.transform.rotation);
                            Destroy(lookObj.gameObject);
                            return;
                        }


                    }               //제거 가능한거
                    else if (lookObj.GetComponent<ObjCode>().objStatus == 6)
                    {
                        //여기에 멀 해야할 수 있다.
                        return;
                    }               //몬스터
                    else if (lookObj.GetComponent<ObjCode>().objStatus == 7) 
                    {
                        if (lookObj.GetComponent<ObjCode>().obj_State == 8) //코인이면
                        {

                            SoundManger.instance.CoinSound();

                            nowCoinCount++; //코인 먹었다고 알려줌
                                            //GameObject.Find("GameManager").GetComponent<MapManager>().nowCoinCount = nowCoinCount;
                            Destroy(lookObj.gameObject); //오브젝트 삭제
                        }
                    }               //안움직이는 오브젝트
                    else if (lookObj.GetComponent<ObjCode>().objStatus == 8)
                    {
                        return;
                    }               //버튼
                    else if (lookObj.GetComponent<ObjCode>().objStatus == 9)
                    {
                        return;
                    }               //버튼과 연결되는 오브젝트

                }
            }
        }
    }

    void Find_Obj()  //오브젝트 찾기함수
    {
        for (int i = 0; i < allObj.Length; i++)
        {
            if (allObj[i] != null && lookObj == null)
            {
                if (allObj[i].transform.position.x == targetVector.x && allObj[i].transform.position.z == targetVector.z) // 변경부분
                {
                    lookObj = allObj[i].transform;
                    lookObj.GetComponent<ObjCode>().Change_Bool(); //true
                }
            }
        }
        if (lookObj != null)
        {
            if (lookObj.transform.position.x != targetVector.x || lookObj.transform.position.z != targetVector.z) // 변경부분
            {
                lookObj.GetComponent<ObjCode>().Change_Bool2(); //false
                lookObj = null;
            }
        }
    }

    public GameObject[] potal; 
    public bool isPotal = false; //순간이동 했는지 안했는지 알려주기(지금 막 순간이동 했는지 안했는지 체크)
    Vector3 nowPosition; //현재 캐릭터 포지션

    //포탈로 들어갔을 때
    void Potal()
    {
        for (int i = 0; i < potal.Length; i++)
        {
            //포탈위치랑 같아질 때
            if (transform.position.x == potal[i].transform.position.x && transform.position.z == potal[i].transform.position.z && isPotal == false && potal[i].GetComponent<PortalObj>().isTrue == true)
            {
                for (int j = 0; j < potal.Length; j++)
                {
                    if (i != j)
                    {
                        if (potal[i].GetComponent<ObjCode>().obj_Connection_It == potal[j].GetComponent<ObjCode>().obj_Connection_It)
                        {
                            //캐릭터의 위치를 바꾼다
                            nowPosition = new Vector3(potal[j].transform.position.x, transform.position.y, potal[j].transform.position.z);
                            transform.position = new Vector3(potal[j].transform.position.x, transform.position.y, potal[j].transform.position.z);

                            //움직임 관련 벡터들 초기화
                            if (llll == 1)
                            {
                                targetVector = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                                moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            }
                            else if (llll == 2)
                            {
                                targetVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                                moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            }
                            else if (llll == 3)
                            {
                                targetVector = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                                moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            }
                            else if (llll == 4)
                            {
                                targetVector = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                                moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            }
                            else
                            {
                                targetVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                                moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            }

                            //순간이동 했다고 알려줌
                            isPotal = true;

                            SoundManger.instance.PotalSound();
                        }
                    } 
                }
            }
        }



        //막 순간이동 했으면
        if (isPotal == true)
        {
            if (transform.position != nowPosition)
            {
                isPotal = false;// 다시 포탈 탈수있게 바꾸기
                nowPosition = new Vector3(0, 0, 0);
            }
        }
    }
   



    //끝나는조건
    void EndGame()
    {
        if (coin_Count == nowCoinCount && moveVector == nowVector)
        {
            int _star = 1; //별 카운트 지역변수
            if (GameManager.instance.IsPause == false)
            {
                GameManager.instance.IsPause = true;

                //여기가 문제다
                //이거 시간 가져와야함
                if (coinCount <= nowCoinCount)
                {
                    _star++;
                }


                if (timer.GetComponent<Timer>().LimitTime <= LimitTimer)
                {
                    _star++;
                }

                if (GameManager.instance.stageData.Stage[GameManager.instance.sceneNum] >= _star)
                {

                }
                else
                {
                    GameManager.instance.stageData.Stage[GameManager.instance.sceneNum] = _star; //별 수 체크
                }

                Time.timeScale = 0;
                Debug.Log(Time.timeScale);

                Debug.Log("클리어");
                Debug.Log(nowCoinCount);
                isEnd = true;
                endUI.GetComponent<EndUI>().isClear = true;


                SoundManger.instance.ClearSound();

                //UI 띄우기
                endUI.SetActive(true);
                StageText.SetActive(true);
                FAIL.SetActive(false);
            }
        }
    }

    //끝나는 조건 행동력 관련
    void Action_Point()
    {
        if (actionPoint <= 0 || isAtk == true)
        {
            if (GameManager.instance.IsPause == false)
            {
                GameManager.instance.IsPause = true;
                Time.timeScale = 0;
                Debug.Log(Time.timeScale);


                endUI.GetComponent<EndUI>().isClear = false;

                //스테이지 클리어 정보 알려주기

                isEnd = true;
                SoundManger.instance.FailSound();

                endUI.SetActive(true);
                //스테이지 클리어 실패
                StageText.SetActive(false);
                FAIL.SetActive(true);
                NextButton.SetActive(false);
                //UI 띄우기
            }     
        }
    }


    

    void FindUi()  //ui 찾는 함수
    {

        playerText = GameObject.FindWithTag("playerText").GetComponent<Text>();
        hpbar = GameObject.FindWithTag("hpbar");
    }


    //레이캐스트로 움직일수있는 범위 설정
    void Ray()
    {
        RaycastHit hit;
        Physics.Raycast(targetVector + transform.up, transform.up * -1, out hit, 2);
        Debug.DrawRay(targetVector + transform.up, transform.up * -2, Color.blue);


        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Ground") || hit.transform.CompareTag("button") || hit.transform.CompareTag("goal"))
            {
                moveBool = true;
            }
            else if (hit.transform.CompareTag("Water"))
            {
                moveBool = false;

                for (int i = 0; i < inventory.GetComponent<Inventory>().equipment_items.Count; i++)
                {
                    if (inventory.GetComponent<Inventory>().equipment_items[i].itemName == "판자")
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            hit.transform.GetChild(0).gameObject.SetActive(true);


                            //HP 소모
                            actionPoint -= 1;

                            if (Inventory.instance.equipment_items[i].num != 0)
                            {
                                Inventory.instance.equipment_items[i].num--;

                                if (Inventory.instance.equipment_items[i].num == 0)
                                {
                                    Inventory.instance.equipment_items.RemoveAt(i);  //아이템 수가 0이면 아이템 삭제
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (hit.transform.CompareTag("aa") && hit.transform.GetComponent<ObjCode>().objStatus == 4) //움직이는 오브젝트
                {
                    if (lookObj != null)
                    {
                        if ((lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).x < 0 || (lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).z < 0)
                        {
                            moveBool = false;
                        }
                        else
                        {
                            for (int i = 0; i < Map.GetComponent<jsonCode>().mapData_.map.Length; i++)
                            {
                                for (int j = 0; j < Map.GetComponent<jsonCode>().mapData_.map[0].mapX.Length; j++)
                                {
                                    if ((lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).x == i && (lookObj.GetComponent<ObjCode>().nowVector_Obj + (targetVector - nowVector)).z == j)
                                    {

                                        for (int k = 0; k < allObj.Length; k++)
                                        {
                                            if (allObj[k] != null)
                                            {
                                                //이조건은 움직여야하는 오브젝트가 움직이는곳에 오브젝트가 있으면
                                                if (allObj[k].transform.position.x == i && allObj[k].transform.position.z == j)
                                                {
                                                    moveBool = false;
                                                    return;
                                                }
                                                else
                                                {

                                                }
                                            }
                                        }


                                        if (Map.GetComponent<jsonCode>().mapData_.map[i].mapX[j] == 1) //물이면
                                        {
                                            moveBool = false;
                                            break;
                                        }
                                        else
                                        {
                                            moveBool = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (hit.transform.CompareTag("aa") && hit.transform.GetComponent<ObjCode>().obj_State == 8)
                {
                    moveBool = true;
                }
                else if (hit.transform.CompareTag("aa") && hit.transform.GetComponent<ObjCode>().objStatus == 9)
                {
                    if (hit.transform.parent.GetComponent<ActivateObj>().isObj == true)
                    {
                        moveBool = false;
                    }
                    else if (hit.transform.parent.GetComponent<ActivateObj>().isObj == false)
                    {
                        moveBool = true;
                    }
                }
                else
                {
                    moveBool = false;
                }
            }

        }
        else if (hit.transform == null)
        {
            moveBool = false;
        }
    }



    //보고있는 오브젝트 ui창 띄우기
    void Obj_Ui()
    {
        //보고있는 오브젝트가있을때
        if (lookObj != null)
        {
            if (lookObj.GetComponent<ObjCode>() == true)
            {
                if (lookObj.GetComponent<ObjCode>().objStatus == 4)
                {
                    objStateText.GetComponent<Text>().text = "Move" + "\n" + "HP -" + (lookObj.GetComponent<ObjCode>().obj_Ack + 1);
                }
                else if (lookObj.GetComponent<ObjCode>().objStatus == 5)
                {
                    objStateText.GetComponent<Text>().text = "Crush" + "\n" + "HP -" + lookObj.GetComponent<ObjCode>().obj_Ack;
                }
                else
                {
                    objStateText.GetComponent<Text>().text = "NULL";
                }
            }
        }
        else
        {
            objStateText.GetComponent<Text>().text = "NULL";
        }
    }

    public Text playerText; //플레이어 행동력 text

    void Player_Ui()
    {
        playerText.text = actionPoint.ToString();
        hpbar.GetComponent<HPbar>().hitPoint = actionPoint;
    }

}
