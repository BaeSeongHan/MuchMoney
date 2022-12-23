using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_move : MonoBehaviour
{
    int monsterAttackType; //1:���� ��ĭ 2. ���� 2ĭ

    public Text actText; //�ൿ�� ui ������ ����
    public int act_num; //���� �ൿ�� ������ ����
    public int act_num2; //�ٲ� �ൿ�� ������ ����

    //PlayerMove ������Ʈ���� actionPoint(�ൿ��) ���� �����ͼ� �̰� �پ���? ���� �̵�
    //���ʹ� ĭĭ�� �̵��� ����� �ʹ�.

    public float Speed = 0.5f;  //�̰� ����


    public Vector3 nowVector;     //���� ��ġ����
    public Vector3 moveVector;    //�̵��� ��ġ����
    public Vector3 targetVector;  //�����ִ� ������ ��ġ����

    public bool moveBool; //���� �̵� �������� �Ǻ��ϴ� �� ����
    public int num = 0; //���� ���ϱ�


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
        //��� �̵�
        transform.position = Vector3.MoveTowards(transform.position, moveVector, Speed * Time.deltaTime);

        Ray();
        monster_Move();


    }

    void findActUi()
    {
        actText = GameObject.FindWithTag("playerText").GetComponent<Text>();
    }


    //����ĳ��Ʈ�� �����ϼ��ִ� ���� ����
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
            //Debug.Log(moveBool); //���� �̵�
        }
        if (act_num != act_num2)
        {
            moveVector = targetVector; //�̵��� ��ġ���Ϳ� Ÿ�ٺ��� �������༭ �̵���Ű��
            if (transform.position == targetVector)//���� ��ġ�� Ÿ�ٺ��Ϳ� ������ Ÿ�ٺ��� �����ϱ�
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
