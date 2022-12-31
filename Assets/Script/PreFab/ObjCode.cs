using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCode : MonoBehaviour
{
    public static ObjCode instance;

    public bool uiOpen; //ui 키고 끄는 불값
    public int objStatus; //오브젝트 상태 나타내는 변수  0. 스테이지 클리어, 1. 철광석, 2. 나무, 3. 미정, 4. 움직이는것들, 5.
    public bool moveObj; //오브젝트 움직이는지 아닌지 설명하는 변수

    public Vector3 nowVector_Obj;     //현재 위치벡터
    public Vector3 moveVector_Obj;    //이동할 위치벡터


    public int obj_State = 1; //오브젝트 상태 표현 1.
    public float obj_Size = 0.5f; // 2.
    public int obj_Ack = 1; //오브젝트와 상호작용시 소모하는 행동력 3.
    public float obj_Speed = 10.0f;  //오브젝트 스피드 4.
    public float monster_Speed = 10.0f; //몬스터 스피드 5.
    public int obj_Connection = 0;  //어떤 오브젝트랑 연결되어 있는지 0. 벽. 1. 포탈    (6.) 포탈이나 벽일때 이거숫자에 따라 오브젝트가 활성화인지 아닌지 판단.
    public int obj_Connection_It = 0; //어떤것들이 연결되어 있는지 알려주는 변수(같은 수끼리 연결) 7.

    private void Awake()
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        uiOpen = false;
        moveObj = false;
        nowVector_Obj = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //움직이는 오브젝트
        if (objStatus == 4)
        {
            if (moveObj)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveVector_Obj, obj_Speed * Time.deltaTime);
            }

            if (moveVector_Obj == transform.position)
            {
                moveObj = false;
                nowVector_Obj = transform.position;
            }
        }
    }

    public void Change_Bool()
    {
        uiOpen = true;
    }

    public void Change_Bool2()
    {
        uiOpen = false;
    }
}
