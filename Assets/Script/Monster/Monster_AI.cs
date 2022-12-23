using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour
{
    public GameObject target; //ĳ���� ���󰥰�
    public Vector3 t_vecter;  //ĳ���� ����

    public int look_m; //���� ���� ����
    public float Speed = 0.5f;  //���� ���ǵ�

    public Vector3 nowVector;     //���� ��ġ����
    public Vector3 moveVector;    //�̵��� ��ġ����
    public Vector3 targetVector;  //�����ִ� ������ ��ġ����

    public bool moveBool = false; //���� �̵� �������� �Ǻ��ϴ� �� ����
    public bool objBool = false; //������Ʈ�� �����ִ��� �ƴ��� �Ǵ�.

    public GameObject[] Obj;//������Ʈ �Ǻ��Ҷ� ���� ����
    public GameObject[] allObj; //��������Ʈ ���� �迭
    public GameObject[] allwallObj; //��������Ʈ ���� �迭

    private Animator animator;

    public bool atk = false; //���� �ߴ��� ���ߴ���
    public bool isDie = false; //�׾����� �Ǻ�

    public bool isMParticleTrue; //��ƼŬ�� ���� �ߴ���
    public bool isAParticleTrue; //��ƼŬ�� ���� �ߴ���
    public bool isSParticleTrue; //��ƼŬ�� ���� �ߴ���



    public ParticleSystem mParticle;
    public GameObject aParticle;
    public GameObject sParticle;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isMParticleTrue = false;
        isAParticleTrue = false;
        isSParticleTrue = false;
    }

    private void Start()
    {
        Monster_initialization();


        allObj = GameObject.FindGameObjectsWithTag("aa");

    }

    void Update()
    {
        Ray();

        
        moster_ObjCheck();
       
        if (target != null)
        {
            Look_Monster();
            Monster_move();
        }

        if (target != null)
        {
            if (objBool == false)
            {
                animator.SetBool("Walk Forward", true);
            }
            else
            {
                animator.SetBool("Walk Forward", false);
            }

            //Ÿ�� ���͸� �ٲ��ִ°� ���� ����
            //������ �����̼��� ���ϴ°� ���� ��


            if (targetVector.x == target.transform.position.x && targetVector.z == target.transform.position.z)
            {
                animator.SetBool("Walk Forward", false);

                if (atk == false)
                {
                    animator.SetTrigger("Stab Attack");
                    atk = true;
                    //������ �ߴ�.
                }
            }
            StartCoroutine(CheckAnimationStateAttack());
            StartCoroutine(CheckAnimationStateDie());
        }


       
    }


    float exitTime = 0.8f;

    IEnumerator CheckAnimationStateAttack()
    {

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Stab Attack"))
        {
            //��ȯ ���� �� ����Ǵ� �κ�
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {
            moveBool = false;

            //��������Ʈ
            if (isAParticleTrue == false)
            {
                SoundManger.instance.AttackSound();
                Instantiate(aParticle, target.transform.position, aParticle.transform.rotation);
                isAParticleTrue = true;
            }

            //���� ����Ʈ
            if (isSParticleTrue == false)
            {
                for (int i = 0; i < target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items.Count; i++)
                {
                    if (isDie == false && target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items[i].itemName == "Į" && isDie == false)
                    {

                        SoundManger.instance.BlockSound();
                        Instantiate(sParticle, target.transform.position, sParticle.transform.rotation);
                        isSParticleTrue = true;

                        break;
                    }
                }
            }
            
            //�ִϸ��̼� ��� �� ����Ǵ� �κ�
            yield return null;
        }

        //�ִϸ��̼� �Ϸ� �� ����Ǵ� �κ�
        for (int i = 0; i < target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items.Count; i++)
        {
            if (isDie == false && target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items[i].itemName == "Į" && isDie == false)
            {
                moveBool = false;

                //hp ���
                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;

                //������ ����
                if (Inventory.instance.equipment_items[i].num != 0)
                {
                    Inventory.instance.equipment_items[i].num--;

                    if (Inventory.instance.equipment_items[i].num == 0)
                    {
                        Inventory.instance.equipment_items.RemoveAt(i);  //������ ���� 0�̸� ������ ����
                    }
                }

                
                animator.SetTrigger("Die");
                isDie = true;

                break;
            }
        }

        if (isDie == false)
        {
            target.GetComponent<PlayerMove>().isAtk = true;
        }
    }
    IEnumerator CheckAnimationStateDie()
    {

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            //��ȯ ���� �� ����Ǵ� �κ�
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {
            //�ִϸ��̼� ��� �� ����Ǵ� �κ�
            yield return null;
        }

        //�ִϸ��̼� �Ϸ� �� ����Ǵ� �κ�


        //���⿡ �μ����� ����Ʈ
        if (isMParticleTrue == false)
        {
            SoundManger.instance.DestroySound();
            Instantiate(mParticle, gameObject.transform.position, mParticle.transform.rotation);
            isMParticleTrue = true;
        }
        

        Destroy(gameObject);
    }


    void Look_Monster()
    {
        switch (look_m)
        {
            case 1:
                if (objBool == false)
                {

                    transform.rotation = Quaternion.Euler(0, 180, 0);

                }

                look_m = 1; //���¹��� ����
                break;
            case 2:
                if (objBool == false)
                {
                  
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                look_m = 2; //���¹��� ����
                break;
            case 3:
                if (objBool == false)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                }

                look_m = 3; //���¹��� ����
                break;
            case 4:
                if (objBool == false)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                look_m = 4; //���¹��� ����
                break;

            default:
                break;
        }
    }

    void Monster_initialization()
    {
        target = GameObject.FindWithTag("Player");
        moveVector = gameObject.transform.position;
        if (target != null)
        {
            if (Mathf.Round(transform.position.x * 10) * 0.1f == Mathf.Round(target.transform.position.x * 10) * 0.1f)
            {
                if (this.transform.position.z > target.transform.position.z)
                {
                    Quaternion rot = Quaternion.Euler(0, 180, 0);
                    transform.rotation = rot;
                    look_m = 1; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                }
                else if (this.transform.position.z < target.transform.position.z)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    transform.rotation = rot;
                    look_m = 2; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                }

                return;
            }
            else if (Mathf.Round(transform.position.z * 10) * 0.1f == Mathf.Round(target.transform.position.z * 10) * 0.1f)
            {
                if (this.transform.position.x > target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 270, 0);
                    transform.rotation = rot;
                    look_m = 3; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                }

                if (this.transform.position.x < target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 90, 0);
                    transform.rotation = rot;
                    look_m = 4; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                }
                return;
            }
            else
            {
                if (this.transform.position.x > target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 270, 0);
                    transform.rotation = rot;
                    look_m = 3; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                }

                if (this.transform.position.x < target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 90, 0);
                    transform.rotation = rot;
                    look_m = 4; //���¹��� ����
                    targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                    //Debug.Log("�̰�");
                }
                return;
            }
        }
    }

    void Monster_move()
    {
        //������ �� �ְ� �տ� ������Ʈ�� ������
        if (moveBool && !objBool)
        {
            moveVector = targetVector;
            moveBool = false;

            return;
        }

        if (transform.position == targetVector)
        {
            switch (look_m)
            {
                //�Ʒ�
                case 1:
                    if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                        {
                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                        }
                        else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                        {
                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                            look_m = 2;
                        }
                        else if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                        {
                            if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);

                                look_m = 3;
                            }
                            else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);

                                look_m = 4;
                            }
                            else if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                //�÷��̾ Į �������� ������ ������
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //�÷��̾ Į �������� ������ ���� ������
                                Destroy(gameObject);
                            }
                        }
                    }

                    else if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 3;
                    }
                    else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 4;
                    }

                    //Ÿ�� ���� �ٲ�
                    break;
                //��
                case 2:
                    if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                        else if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                        {
                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                            look_m = 1;
                        }
                        else if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                        {
                            if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);

                                look_m = 3;
                                
                            }
                            else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);

                                look_m = 4;
                                
                            }
                            else if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                            {
                                //�÷��̾ Į �������� ������ ������
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //�÷��̾ Į �������� ������ ���� ������
                                Destroy(gameObject);
                            }
                        }
                    }

                    else if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 3;
                    }
                    else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                    {
                        targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 4;
                    }

                    //Ÿ�� ���� �ٲ�

                    break;
                //��
                case 3:
                    if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                            targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                        {
                            targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                            look_m = 4;
                        }

                        else if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                        {
                            if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);

                                look_m = 1;
                               
                            }
                            else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);

                                look_m = 2;
                                
                            }
                            else if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                //�÷��̾ Į �������� ������ ������
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //�÷��̾ Į �������� ������ ���� ������
                                Destroy(gameObject);
                            }
                        }
                    }
                    if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                        look_m = 1;
                    }
                    else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                        look_m = 2;
                    }

                    //Ÿ�� ���� �ٲ�
                    break;
                //��
                case 4:
                    if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                            targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        else if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                        {
                            targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                            look_m = 3;
                        }
                        else if (transform.position.x == target.GetComponent<PlayerMove>().moveVector.x)
                        {
                            if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);

                                look_m = 1;
                                
                            }
                            else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);

                                look_m = 2;
                                
                            }
                            else if (transform.position.z == target.GetComponent<PlayerMove>().moveVector.z)
                            {
                                //�÷��̾ Į �������� ������ ������
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //�÷��̾ Į �������� ������ ���� ������
                                Destroy(gameObject);
                            }
                        }
                    }
                    if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                        look_m = 1;
                    }
                    else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                    {
                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                        look_m = 2;
                    }

                    //Ÿ�� ���� �ٲ�

                    break;
            }

            

            moveBool = true;
        }

        if (targetVector.x == target.transform.position.x && targetVector.z == target.transform.position.z)
        {

        }
        else
        {
            //��� �̵�
            transform.position = Vector3.MoveTowards(transform.position, moveVector, Speed * Time.deltaTime);
        }

    }

    void moster_ObjCheck()
    {

        //������ ���̸�
        if (asd == false)
        {
            objBool = true; //�����ִٰ� �˷��ش�.

            switch (look_m)
            {
                case 1:
                    if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                    {

                        targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 3;
                        moveBool = true;
                    }
                    else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                    {


                        targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 4;
                        moveBool = true;
                    }
                    break;
                case 2:
                    if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                    {

                        targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 3;
                        moveBool = true;
                    }
                    else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                    {

                        targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                        look_m = 4;
                        moveBool = true;
                    }
                    break;
                case 3:
                    if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                    {

                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                        look_m = 1;
                        moveBool = true;
                    }
                    else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                    {


                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                        look_m = 2;
                        moveBool = true;
                    }
                    break;
                case 4:
                    if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                    {

                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                        look_m = 1;
                        moveBool = true;
                    }
                    else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                    {

                        targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                        look_m = 2;
                        moveBool = true;
                    }
                    break;
                default:
                    break;
            }


            return;
        }

        for (int i = 0; i < allObj.Length; i++)
        {
            if (allObj[i] != null && allObj[i].activeSelf == true)
            {
                if (true)
                {
                    if (allObj[i].transform.position.x == targetVector.x && allObj[i].transform.position.z == targetVector.z) //����������
                    {


                        if (allObj[i].gameObject.name == "Wall")
                        {
                            if (allObj[i].transform.parent.GetComponent<ActivateObj>().isObj)
                            {
                                objBool = true;
                                switch (look_m)
                                {
                                    case 1:
                                        if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                                        {

                                            targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                            look_m = 3;
                                            moveBool = true;
                                        }
                                        else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                                        {


                                            targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                            look_m = 4;
                                            moveBool = true;
                                        }
                                        break;
                                    case 2:
                                        if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                                        {

                                            targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                            look_m = 3;
                                            moveBool = true;
                                        }
                                        else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                                        {

                                            targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                            look_m = 4;
                                            moveBool = true;
                                        }
                                        break;
                                    case 3:
                                        if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                                        {

                                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                                            look_m = 1;
                                            moveBool = true;
                                        }
                                        else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                                        {


                                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                                            look_m = 2;
                                            moveBool = true;
                                        }
                                        break;
                                    case 4:
                                        if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                                        {

                                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                                            look_m = 1;
                                            moveBool = true;
                                        }
                                        else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                                        {

                                            targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                                            look_m = 2;
                                            moveBool = true;
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            }
                            else
                            {
                                objBool = false;
                                break;
                            }
                        }

                        objBool = true; //�����ִٰ� �˷��ش�.

                        //�Ӹ�������
                        switch (look_m)
                        {
                            case 1:
                                if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                                {
                                   
                                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                    look_m = 3;
                                    moveBool = true;
                                }
                                else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                                {

                                    
                                    targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                    look_m = 4;
                                    moveBool = true;
                                }
                                break;
                            case 2:
                                if (transform.position.x > target.GetComponent<PlayerMove>().moveVector.x)
                                {
                                    
                                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                    look_m = 3;
                                    moveBool = true;
                                }
                                else if (transform.position.x < target.GetComponent<PlayerMove>().moveVector.x)
                                {
                                   
                                    targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                                    look_m = 4;
                                    moveBool = true;
                                }
                                break;
                            case 3:
                                if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                                {
                                    
                                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                                    look_m = 1;
                                    moveBool = true;
                                }
                                else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                                {

                                    
                                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                                    look_m = 2;
                                    moveBool = true;
                                }
                                break;
                            case 4:
                                if (transform.position.z > target.GetComponent<PlayerMove>().moveVector.z)
                                {
                                    
                                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                                    look_m = 1;
                                    moveBool = true;
                                }
                                else if (transform.position.z < target.GetComponent<PlayerMove>().moveVector.z)
                                {
                                   
                                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z + 1) * 10) * 0.1f);
                                    look_m = 2;
                                    moveBool = true;
                                }
                                break;
                            default:
                                break;
                        }


                        break;
                    }
                    else
                    {
                        objBool = false;
                    }
                }  
            }
        }
    }

    public bool asd;

    public void Ray()
    {
        RaycastHit hit;
        Physics.Raycast(targetVector + transform.up, transform.up * -1, out hit, 2);
        Debug.DrawRay(targetVector + transform.up, transform.up * -2, Color.blue);


        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Water"))
            {
                asd = false;
            }
            else
            {
                asd = true;
            }
        }
        else if (hit.transform == null)
        {
            asd = false;
        }
    }
}
