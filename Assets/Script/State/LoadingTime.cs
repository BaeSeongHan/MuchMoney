using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change_Main", 1f);
    }

    void Change_Main()
    {
        SceneManager.LoadScene(1);
    }
}
