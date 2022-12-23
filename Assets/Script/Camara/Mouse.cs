using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private float dist;
    private Vector3 MouseStart;
    private Vector3 derp;

    public float speed;


    float timer;
    int waitingTime;
    bool inside;

    public bool changemove; //이게 켜져야 다른 카메라 이동 시작


    public GameObject UI; //이게 켜져있으면 카메라 움직임 멈춤


    private void Start()
    {
        if (UI.activeSelf == true)
        {
            dist = transform.position.y;
            speed = 0.6f;


            timer = 0.0f;
            waitingTime = 1;
            inside = false;
            changemove = true;
        }
        else if (UI.activeSelf == false)
        {
            dist = transform.position.y;
            speed = 0.6f;


            timer = 0.0f;
            waitingTime = 1;
            inside = false;
            changemove = true;
        }
        
    }

    private void Update()
    {

        if (UI.activeSelf == true)
        {

        }
        else if (UI.activeSelf == false)
        {
            if (GameManager.instance.IsPause == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    MouseStart = new Vector3(-Input.mousePosition.x * speed, -Input.mousePosition.y, dist * speed);
                    MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
                    MouseStart.y = transform.position.y;
                    inside = false;
                    changemove = false;
                    timer = 0;
                }
                else if (Input.GetMouseButton(0))
                {
                    var MouseMove = new Vector3(-Input.mousePosition.x * speed, -Input.mousePosition.y, dist * speed);
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
                        //Action
                        changemove = true;

                        timer = 0;
                    }
                }
            }
        }
    }
}
