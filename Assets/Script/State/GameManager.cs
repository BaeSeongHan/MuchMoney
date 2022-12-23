using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int sceneNum = 0;   //씬 넘버
    public Transform playerPrefab;
    public bool IsPause = false;
    public int iron = 0;
    public int scenStat = 0; //씬 상태 나타내기

    public StageData stageData;









    private void Awake()
    {
        if (instance != null)
        {

            Destroy(gameObject);
            //Debug.Log("삭제");
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

[System.Serializable]
public class StageData
{
    public int[] Stage = new int[24]; //맵의 x값
}
