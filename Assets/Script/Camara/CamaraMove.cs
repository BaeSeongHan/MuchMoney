using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    private GameObject target;
    private float dist;
    private float timer;
    private bool inside;
    private bool changeMove; //이게 켜져야 다른 카메라 이동 시작
    private Vector3 MouseStart;
    private Vector3 derp;
    
    [Range(0, 1)]
    [SerializeField] private float delayTime; //카메라가 target 따라가는 속도
    [SerializeField] private Vector3 offset; //얼마많큼 target에서 떯어져 있을 건지
    [SerializeField] private int waitingTime; //마우스로 움직인 다음 돌아가기까지 기다리는 시간
    [SerializeField] private float speed; //돌아가는 속도
    [SerializeField] private GameObject mixUI;

    private void Awake()
    {
        Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }

        if (GameManager.instance.IsPause == false && !mixUI.activeSelf)
        {
            BasicMove();
            MouseMove();
        }      
    }

    void BasicMove()
    {
        if(target && changeMove)
        {
            Vector3 FixedPos = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
        }
    }

    void MouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = new Vector3(Input.mousePosition.x * speed, Input.mousePosition.y, dist * speed);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.y = transform.position.y;
            inside = false;
            changeMove = false;
            timer = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            var MouseMove = new Vector3(Input.mousePosition.x * speed, Input.mousePosition.y, dist * speed);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.y = transform.position.y;
            transform.position = transform.position - (MouseMove - MouseStart);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            inside = true;
        }

        if (inside == true)
        {
            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                changeMove = true;
                timer = 0;
            }
        }
    }

    public void Initialized()
    {
        dist = transform.position.y;
        timer = 0.0f;
        inside = false;
        changeMove = true;
    }
}
