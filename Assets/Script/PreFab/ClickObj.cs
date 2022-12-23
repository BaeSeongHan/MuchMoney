using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObj : MonoBehaviour
{
    public Camera get_Camera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjRay();
    }

    RaycastHit obj_hit;

    void ObjRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "aa")
            {
                if (obj_hit.transform.gameObject.GetComponent<ObjCode>().objStatus == 1)
                {
                    Debug.Log("1");
                }
                else if (obj_hit.transform.gameObject.GetComponent<ObjCode>().objStatus == 2)
                {
                    Debug.Log("2");
                }
               
            }
        }
    }


}
