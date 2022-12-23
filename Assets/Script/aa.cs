using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour
{
    public GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -8; i < 7; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Instantiate(a, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
