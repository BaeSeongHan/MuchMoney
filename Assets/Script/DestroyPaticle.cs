using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPaticle : MonoBehaviour
{
    float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 2)
        {
            Destroy(gameObject);
        }
    }
}
