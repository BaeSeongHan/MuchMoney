using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public float offsetZ;

   
    
    [Range(0, 1)]
    public float delayTime;

    public GameObject target;

    public GameObject Data; //맵 데이터 가져올거 

    public float max_X = 5; //x값으로 얼마나 떨어져 있을 수 있는지
    public float max_Z = 2; //y값으로 얼마나 떨어져 있을 수 있는지

    public Vector3 TVECTOR; // 타겟벡터

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Data.GetComponent<jsonCode>().mapData_.map.Length);
        Debug.Log(Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length);

        if (Data.GetComponent<jsonCode>().mapData_.map.Length%2 == 1)
        {
            TVECTOR.x = Data.GetComponent<jsonCode>().mapData_.map.Length / 2;
        }
        else if (Data.GetComponent<jsonCode>().mapData_.map.Length % 2 == 0)
        {
            TVECTOR.x = Data.GetComponent<jsonCode>().mapData_.map.Length / 2 + 0.5f;
        }


        if (Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length % 2 == 1)
        {
            TVECTOR.z = Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length / 2;
        }
        else if (Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length % 2 == 0)
        {
            TVECTOR.z = Data.GetComponent<jsonCode>().mapData_.map[0].mapX.Length / 2 + 0.5f;
        }


        
        TVECTOR.y = 10;


        //transform.position = TVECTOR;
    }

    //여기서 맵사이즈 받아와서 맵의 중앙의 위치를 받아오고

    void TargetPosition()
    {

        float _x, _z;

        

        //_x = M.GetComponent<MapManager>().mapSize.x; //이거는 초기화 할때 써야한다
        //_z = M.GetComponent<MapManager>().mapSize.y;


        _x = transform.position.x; 
        _z = transform.position.z;


        //절대값으로 변경해야함, 캐릭터랑 카메라가 떨어져 있는 위치가 멕스 수치를 넘었을때
        if (Mathf.Abs(target.transform.position.x - _x) - max_X >= 1)
        {
            //왼쪽으로 가서 멀어졌을때
            if (target.transform.position.x < _x)
            {
                //절대값으로 변경
                _x -= Mathf.Abs(target.transform.position.x - _x) - max_X;
            }
            //오른쪽으로 가서 멀어졌을때
            else if (target.transform.position.x > _x)
            {
                //절대값으로 변경
                _x += Mathf.Abs(target.transform.position.x - _x) - max_X;
            }
        }

        //절대값으로 변경해야함, 캐릭터랑 카메라가 떨어져 있는 위치가 멕스 수치를 넘었을때
        if (Mathf.Abs(target.transform.position.z - _z) - max_Z >= 1)
        {
            //아래로 가서 멀어졌을때
            if (target.transform.position.z < _z)
            {
                //절대값으로 변경
                _z -= Mathf.Abs(target.transform.position.z - _z) - max_Z;
            }
            //위로 가서 멀어졌을때
            else if (target.transform.position.z > _z)
            {
                //절대값으로 변경
                _z += Mathf.Abs(target.transform.position.z - _z) - max_Z;
            }
        }

        //이게 타겟 벡터
        TVECTOR = new Vector3(_x, 10, _z);

    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsPause == false)
        {
            if (target == null)
            {
                target = GameObject.FindWithTag("Player");
            }
            else if (target != null)
            {
                if (transform.GetComponent<Mouse>().changemove == true)
                {
                    Vector3 FixedPos = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);
                    //TargetPosition();

                    transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
                }
            }
        }      
    }
}
