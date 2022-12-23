using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObj : MonoBehaviour
{
    public bool isTrue = false; //현재 오브젝트를 밟았는지 아닌지

    //활성화 비활성화
    
    public void ActivatePotal()
    {
        if (transform.GetComponent<ObjCode>().obj_Connection == 0)
        {
            //활성화
            isTrue = true;
        }
        else if (transform.GetComponent<ObjCode>().obj_Connection == 1)
        {
            //비활성화
            isTrue = false;
        }
    }

    public void ShowEfact()
    {
        if (isTrue == true)
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
        }

        if (isTrue == false)
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivatePotal();
    }

    // Update is called once per frame
    void Update()
    {
        ShowEfact();
    }
}
