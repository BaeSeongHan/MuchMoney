using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public float monsterSpeed = 1.0f;
    public Vector3 moveMonsterVector; //몬스터 이동 위치
    public Vector3 targetMonsterVector;  //몬스터가 보고있는 방향의 위치벡터

    public bool moveMonsterBool; //몬스터 이동 가능한지 판별하는 불 변수

    public int num = 0;

    //몬스터 이동

    //몬스터 플레이어 인식 범위

    public bool lookingPlayer = false;
    public GameObject player; //플레이어 찾아서 넣기





    // Start is called before the first frame update
    void Start()
    {
        targetMonsterVector = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);

        num = 1;



    }

    // Update is called once per frame
    void Update()
    {
        RecognitionRange();
        if (lookingPlayer == false)
        {
            monsterSpeed = 3;
            RayMonster();
            if (moveMonsterBool)
            {
                if (targetMonsterVector == transform.position)
                {
                    targetMonsterVector = new Vector3(transform.position.x + num, transform.position.y, transform.position.z);
                }
            }

            if (!moveMonsterBool)
            {

                //gameObject.transform.Rotate(Vector3.up, 180); //로컬좌표에서 90도 회전
                targetMonsterVector = new Vector3(transform.position.x - num, transform.position.y, transform.position.z);
                num = -num;
            }


            transform.position = Vector3.MoveTowards(transform.position, targetMonsterVector, monsterSpeed * Time.deltaTime);
        }

        else if (lookingPlayer == true)
        {

            monsterSpeed = 7;

            //if (player.GetComponent<PlayerMove>().moveVector != player.GetComponent<PlayerMove>().nowVector)
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, monsterSpeed * Time.deltaTime);
            }
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }*/


    void RayMonster()
    {
        RaycastHit hit;
        Physics.Raycast(targetMonsterVector + transform.up, transform.up * -1, out hit, 15);
        Debug.DrawRay(targetMonsterVector + transform.up, transform.up * -2, Color.blue);





        if (hit.transform == null)
        {
            moveMonsterBool = false;
        }
        else if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Ground"))
            {

                moveMonsterBool = true;
            }
            else if (!hit.transform.CompareTag("Ground") && !hit.transform.CompareTag("Monster"))
            {
                moveMonsterBool = false;
            }
        }


    }

    //인식범위
    void RecognitionRange()
    {
        RaycastHit hitOBj; //오브젝트 체크 레이
        Physics.Raycast(gameObject.transform.position, transform.forward * 1, out hitOBj, 2.5f);
        Debug.DrawRay(gameObject.transform.position, transform.forward * 2.5f, Color.red);



        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (player.GetComponent<PlayerMove>().moveVector == player.GetComponent<PlayerMove>().nowVector)
            {


                if (distance <= 2.0f)
                {

                    lookingPlayer = true;
                    transform.LookAt(player.transform);

                    if (distance <= 0.75f)
                    {
                        Destroy(gameObject);

                        for (int i = 0; i < Inventory.instance.equipment_items.Count; i++)
                        {
                            if (Inventory.instance.equipment_items[i].itemName == "칼")
                            {
                                if (Inventory.instance.equipment_items[i].num != 0)
                                {
                                    Inventory.instance.equipment_items[i].num--;

                                    if (Inventory.instance.equipment_items[i].num == 0)
                                    {
                                        Inventory.instance.equipment_items.RemoveAt(i);  //아이템 수가 0이면 아이템 삭제
                                    }
                                }
                                
                                player.GetComponent<PlayerMove>().actionPoint += 4;

                                break;
                            }
                            else if(Inventory.instance.equipment_items[i].itemName != "칼")
                            {
                                continue;
                            }


                        }
                        player.GetComponent<PlayerMove>().actionPoint -= 5;
                    }

                }
                else if (distance > 2.0f)
                {
                    lookingPlayer = false;
                    transform.LookAt(targetMonsterVector);
                }
            }
        }

    }
}
