using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGround : MonoBehaviour
{
    public Camera get_Camera;

    public List<Vector3> clicks = new List<Vector3>(); //클릭한거 넣을 vector3리스트





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundRay();
    }


    RaycastHit obj_hit;


    void GroundRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground")
            {
                Vector3 a = obj_hit.transform.position;

                if (clicks.Contains(a))
                {
                    Debug.Log("같은게 있다.");
                }
                else
                {
                    clicks.Add(a);
                }
            }
        }
    }


    public void change_G()
    {

    }




}
