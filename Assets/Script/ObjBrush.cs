using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBrush : MonoBehaviour
{
    public Camera get_Camera; //카메라 가져올곳

    public List<Vector3> clicks = new List<Vector3>(); //클릭한거 넣을 vector3리스트

    // Start is called before the first frame update
    void Start()
    {
        
    }

    RaycastHit obj_hit;

    
    void BrushRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground" || Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Water")
            {
                Vector3 a = obj_hit.transform.position;

                if (clicks.Contains(a))
                {
                    Debug.Log("같은게 있다.");
                }
                else
                {
                    clicks.Add(a); //리스트에 더하기
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //위치에 해당하는 오브젝트를 생성하고, 리스트를 초기화한다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))//마우스버튼 누르고 있는 동안
        {
            //레이를 쏴서 오브젝트에 닿으면 그 오브젝트 위치 위에 오브젝트 생성 오브젝트 위치에 다른게
            //있으면 오브젝트 생성하지 않음
            //

            Debug.Log("누르는동안");
        }*/
        BrushRay();
    }

    

}
