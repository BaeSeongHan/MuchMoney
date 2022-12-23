using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObj : MonoBehaviour
{
    public bool isTrue;
    public bool isObj;
    public Vector3 size;




    public void Activate()
    {
        if (transform.GetChild(0).GetComponent<ObjCode>().obj_Connection == 0)
        {
            isTrue = true;//활성화
            
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.GetChild(0).GetComponent<ObjCode>().obj_Connection == 1)
        {
            isTrue = false; //비활성화
            
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
        isObj = isTrue;
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
    }
}
