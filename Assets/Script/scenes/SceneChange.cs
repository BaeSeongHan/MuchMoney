using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAA");
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(GameManager.instance.sceneNum);
            GameManager.instance.sceneNum++;
        }
    }

    

    public void Change_Scene2()
    {
        GameManager.instance.sceneNum = 2;
        LoadingSceneController.LoadScene("SampleScene 3");
    }



    public void Change_Main()
    {
        if (GameManager.instance.IsPause)
        {
            GameManager.instance.sceneNum = 1;
            SceneManager.LoadScene(GameManager.instance.sceneNum);
            Debug.Log("다시 시작");
            Time.timeScale = 1;
            Debug.Log(Time.timeScale);
            GameManager.instance.IsPause = false;
            GameManager.instance.iron = 0;
        } 
    }
}
