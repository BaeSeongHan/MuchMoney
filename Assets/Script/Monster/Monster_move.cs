using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_move : MonoBehaviour
{
    int monsterAttackType; //1:정면 한칸 2. 정면 2칸

    public Text actText; //행동력 ui 가져올 변수
    public int act_num; //현재 행동력 가져올 변수
    public int act_num2; //바뀐 행동력 가져올 변수

    //PlayerMove 컴포넌트에서 actionPoint(행동력) 변수 가져와서 이게 줄어들면? 몬스터 이동
    //몬스터는 칸칸이 이동을 만들고 싶다.

    public float Speed = 0.5f;  //이거 연동


    public Vector3 nowVector;     //현재 위치벡터
    public Vector3 moveVector;    //이동할 위치벡터
    public Vector3 targetVector;  //보고있는 방향의 위치벡터

    public bool moveBool; //몬스터 이동 가능한지 판별하는 불 변수
    public int num = 0; //방향 정하기


    private void Start()
    {
        targetVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        moveVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        nowVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        moveBool = true;
        num = 1;

        findActUi();
    }

    void Update()
    {
        //계속 이동
        transform.position = Vector3.MoveTowards(transform.position, moveVector, Speed * Time.deltaTime);

        Ray();
        monster_Move();


    }

    void findActUi()
    {
        actText = GameObject.FindWithTag("playerText").GetComponent<Text>();
    }


    //레이캐스트로 움직일수있는 범위 설정
    void Ray()
    {
        RaycastHit hit;
        Physics.Raycast(targetVector + transform.up, transform.up * -1, out hit, 2);
        Debug.DrawRay(targetVector + transform.up, transform.up * -2, Color.blue);


        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Ground"))
            {
                moveBool = true;
            }
            else if (!hit.transform.CompareTag("Ground"))
            {
                moveBool = false;
            }
        }
        else if (hit.transform == null)
        {
            moveBool = false;
        }
    }



    void monster_Move()
    {
        if (act_num == 0)
        {
            act_num = int.Parse(actText.text);
            act_num2 = act_num;
        }
        else
        {
            act_num = int.Parse(actText.text);
        }

        if (moveBool == false)
        {
            //Debug.Log(moveBool); //몬스터 이동
        }
        if (act_num != act_num2)
        {
            moveVector = targetVector; //이동할 위치벡터와 타겟벡터 같게해줘서 이동시키기
            if (transform.position == targetVector)//현재 위치가 타겟벡터와 같을때 타겟벡터 변경하기
            {
                if (nowVector != moveVector)
                {
                    Vector3 a = nowVector - moveVector;
                    targetVector = targetVector - a;
                    nowVector = moveVector;
                    act_num2 = act_num;
                }
            }
        }
        else if(act_num == act_num2)
        {
            if (!moveBool)
            {
                targetVector = new Vector3(transform.position.x - num, transform.position.y, transform.position.z);
                num = -num;
            }
        }
    }

   
}
