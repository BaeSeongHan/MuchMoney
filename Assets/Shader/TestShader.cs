using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShader : MonoBehaviour
{
  



    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //이때 오브젝트의 외각선을 킨다.
        {
            this.gameObject.layer = 6;  
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.gameObject.layer = 7;

        }
    }
}
