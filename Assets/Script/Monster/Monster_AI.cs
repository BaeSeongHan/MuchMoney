using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour
{
    public GameObject target; //캐릭터 따라갈거
    public Vector3 t_vecter;  //캐릭터 벡터

    public int look_m; //몬스터 보는 방향
    public float Speed = 0.5f;  //몬스터 스피드

    public Vector3 nowVector;     //현재 위치벡터
    public Vector3 moveVector;    //이동할 위치벡터
    public Vector3 targetVector;  //보고있는 방향의 위치벡터

    public bool moveBool = false; //몬스터 이동 가능한지 판별하는 불 변수
    public bool objBool = false; //오브젝트가 막고있는지 아닌지 판단.

    public GameObject[] Obj;//오브젝트 판별할때 쓰는 변수
    public GameObject[] allObj; //모든오브젝트 넣을 배열
    public GameObject[] allwallObj; //모든오브젝트 넣을 배열

    private Animator animator;

    public bool atk = false; //공격 했는지 안했는지
    public bool isDie = false; //죽엇는지 판별

    public bool isMParticleTrue; //파티클이 생성 했는지
    public bool isAParticleTrue; //파티클이 생성 했는지
    public bool isSParticleTrue; //파티클이 생성 했는지



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

            //타겟 벡터를 바꿔주는게 몬스터 무브
            //몬스터의 로테이션을 정하는게 몬스터 룩


            if (targetVector.x == target.transform.position.x && targetVector.z == target.transform.position.z)
            {
                animator.SetBool("Walk Forward", false);

                if (atk == false)
                {
                    animator.SetTrigger("Stab Attack");
                    atk = true;
                    //공격을 했다.
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
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {
            moveBool = false;

            //공격이펙트
            if (isAParticleTrue == false)
            {
                SoundManger.instance.AttackSound();
                Instantiate(aParticle, target.transform.position, aParticle.transform.rotation);
                isAParticleTrue = true;
            }

            //막기 이펙트
            if (isSParticleTrue == false)
            {
                for (int i = 0; i < target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items.Count; i++)
                {
                    if (isDie == false && target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items[i].itemName == "칼" && isDie == false)
                    {

                        SoundManger.instance.BlockSound();
                        Instantiate(sParticle, target.transform.position, sParticle.transform.rotation);
                        isSParticleTrue = true;

                        break;
                    }
                }
            }
            
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }

        //애니메이션 완료 후 실행되는 부분
        for (int i = 0; i < target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items.Count; i++)
        {
            if (isDie == false && target.GetComponent<PlayerMove>().inventory.GetComponent<Inventory>().equipment_items[i].itemName == "칼" && isDie == false)
            {
                moveBool = false;

                //hp 깍기
                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;

                //아이템 제거
                if (Inventory.instance.equipment_items[i].num != 0)
                {
                    Inventory.instance.equipment_items[i].num--;

                    if (Inventory.instance.equipment_items[i].num == 0)
                    {
                        Inventory.instance.equipment_items.RemoveAt(i);  //아이템 수가 0이면 아이템 삭제
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
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < exitTime)
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }

        //애니메이션 완료 후 실행되는 부분


        //여기에 부서지는 이펙트
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

                look_m = 1; //보는방향 지정
                break;
            case 2:
                if (objBool == false)
                {
                  
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                look_m = 2; //보는방향 지정
                break;
            case 3:
                if (objBool == false)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                }

                look_m = 3; //보는방향 지정
                break;
            case 4:
                if (objBool == false)
                {
                 
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                look_m = 4; //보는방향 지정
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
                    look_m = 1; //보는방향 지정
                    targetVector = new Vector3(Mathf.Round(transform.position.x * 10) * 0.1f, transform.position.y, Mathf.Round((transform.position.z - 1) * 10) * 0.1f);
                }
                else if (this.transform.position.z < target.transform.position.z)
                {
                    Quaternion rot = Quaternion.Euler(0, 0, 0);
                    transform.rotation = rot;
                    look_m = 2; //보는방향 지정
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
                    look_m = 3; //보는방향 지정
                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                }

                if (this.transform.position.x < target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 90, 0);
                    transform.rotation = rot;
                    look_m = 4; //보는방향 지정
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
                    look_m = 3; //보는방향 지정
                    targetVector = new Vector3(Mathf.Round((transform.position.x - 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                }

                if (this.transform.position.x < target.transform.position.x)
                {
                    Quaternion rot = Quaternion.Euler(0, 90, 0);
                    transform.rotation = rot;
                    look_m = 4; //보는방향 지정
                    targetVector = new Vector3(Mathf.Round((transform.position.x + 1) * 10) * 0.1f, transform.position.y, Mathf.Round(transform.position.z * 10) * 0.1f);
                    //Debug.Log("이거");
                }
                return;
            }
        }
    }

    void Monster_move()
    {
        //움직일 수 있고 앞에 오브젝트가 없으면
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
                //아래
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
                                //플레이어가 칼 아이템을 가지고 있으면
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //플레이어가 칼 아이템을 가지고 있지 않으면
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

                    //타겟 벡터 바꿈
                    break;
                //위
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
                                //플레이어가 칼 아이템을 가지고 있으면
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //플레이어가 칼 아이템을 가지고 있지 않으면
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

                    //타겟 벡터 바꿈

                    break;
                //왼
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
                                //플레이어가 칼 아이템을 가지고 있으면
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //플레이어가 칼 아이템을 가지고 있지 않으면
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

                    //타겟 벡터 바꿈
                    break;
                //오
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
                                //플레이어가 칼 아이템을 가지고 있으면
                                target.GetComponent<PlayerMove>().actionPoint -= gameObject.GetComponent<ObjCode>().obj_Ack;
                                //플레이어가 칼 아이템을 가지고 있지 않으면
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

                    //타겟 벡터 바꿈

                    break;
            }

            

            moveBool = true;
        }

        if (targetVector.x == target.transform.position.x && targetVector.z == target.transform.position.z)
        {

        }
        else
        {
            //계속 이동
            transform.position = Vector3.MoveTowards(transform.position, moveVector, Speed * Time.deltaTime);
        }

    }

    void moster_ObjCheck()
    {

        //다음이 물이면
        if (asd == false)
        {
            objBool = true; //막혀있다고 알려준다.

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
                    if (allObj[i].transform.position.x == targetVector.x && allObj[i].transform.position.z == targetVector.z) //막혀있으면
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

                        objBool = true; //막혀있다고 알려준다.

                        //머리돌리기
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
