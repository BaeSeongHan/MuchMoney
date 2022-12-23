using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalObj : MonoBehaviour
{
    public bool isTrue = false; //���� ������Ʈ�� ��Ҵ��� �ƴ���

    //Ȱ��ȭ ��Ȱ��ȭ
    
    public void ActivatePotal()
    {
        if (transform.GetComponent<ObjCode>().obj_Connection == 0)
        {
            //Ȱ��ȭ
            isTrue = true;
        }
        else if (transform.GetComponent<ObjCode>().obj_Connection == 1)
        {
            //��Ȱ��ȭ
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
