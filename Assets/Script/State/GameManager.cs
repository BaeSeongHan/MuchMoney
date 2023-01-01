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

    public StageData stageData; //->나중에 변경합시다.
    public SoundManger soundManager; 

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
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
