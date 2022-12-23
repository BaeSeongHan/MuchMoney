using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class jsonCode : MonoBehaviour
{
    public int Stage; //현재 스테이지 알려주는 변수

    public MapData mapData;
    public MapData objData;



    public AAAA mapData_;
    public ODATA objData_;
    public STAGEDATA stageData_misson; //스테이지 행동력 미션 저장

    /*
    [ContextMenu("To Json Data1")]
    void SaveMapDataToJson_1()
    {
        string jsonData = JsonUtility.ToJson(mapData);
        string path = Path.Combine(Application.dataPath, "mapData1.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("To Json Data2")]
    void SaveMapDataToJson_2()
    {
        string jsonData = JsonUtility.ToJson(mapData);
        string path = Path.Combine(Application.dataPath, "mapData2.json");
        File.WriteAllText(path, jsonData);
    }


    [ContextMenu("From Json Data1")]
    void LoadMapDataToJson_1()
    {
        string path = Path.Combine(Application.dataPath, "mapData1.json");
        string jsonData = File.ReadAllText(path);
        mapData = JsonUtility.FromJson<MapData>(jsonData);
    }


    [ContextMenu("From Json Data2")]
    void LoadMapDataToJson_2()
    {
        string path = Path.Combine(Application.dataPath, "mapData2.json");
        string jsonData = File.ReadAllText(path);
        mapData = JsonUtility.FromJson<MapData>(jsonData);
    }

    



    [ContextMenu("To Json_Obj Data1")]
    void SaveObjDataToJson_1()
    {
        string jsonData = JsonUtility.ToJson(objData);
        string path = Path.Combine(Application.dataPath, "objData1.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json_Obj Data1")]
    void LoadObjDataToJson_1()
    {
        string path = Path.Combine(Application.dataPath, "objData1.json");
        string jsonData = File.ReadAllText(path);
        objData = JsonUtility.FromJson<MapData>(jsonData);
    }


    [ContextMenu("To Json_Obj Data2")]
    void SaveObjDataToJson_2()
    {
        string jsonData = JsonUtility.ToJson(objData);
        string path = Path.Combine(Application.dataPath, "objData2.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json_Obj Data2")]
    void LoadObjDataToJson_2()
    {
        string path = Path.Combine(Application.dataPath, "objData2.json");
        string jsonData = File.ReadAllText(path);
        objData = JsonUtility.FromJson<MapData>(jsonData);
    }*/

    //---------------------------------------------
    public void LoadMapDataToJson(string jsonName)
    {
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        string jsonData = File.ReadAllText(path);
        mapData_ = JsonUtility.FromJson<AAAA>(jsonData);
    }
    public void SaveMapDataToJson(string jsonName)
    {
        string jsonData = JsonUtility.ToJson(mapData_);
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        File.WriteAllText(path, jsonData);
    }


    public void LoadObjDataToJson(string jsonName)
    {
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        string jsonData = File.ReadAllText(path);
        objData_ = JsonUtility.FromJson<ODATA>(jsonData);
    }
    public void SaveObjDataToJson(string jsonName)
    {
        string jsonData = JsonUtility.ToJson(objData_);
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        File.WriteAllText(path, jsonData);
    }



    public void LoadStageDataToJson(string jsonName)
    {
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        string jsonData = File.ReadAllText(path);
        stageData_misson = JsonUtility.FromJson<STAGEDATA>(jsonData);
    }
    public void SaveStageDataToJson(string jsonName)
    {
        string jsonData = JsonUtility.ToJson(stageData_misson);
        string path = Path.Combine(Application.persistentDataPath, jsonName);
        File.WriteAllText(path, jsonData);
    }


    //스테이지 별 정보 저장
    public void SaveStarDataToJson()
    {
        string jsonData = JsonUtility.ToJson(GameManager.instance.stageData);
        string path = Path.Combine(Application.persistentDataPath, "stageData.json");
        File.WriteAllText(path, jsonData);
    }

    private void Awake()
    {
        Stage = GameManager.instance.sceneNum + 1;

        if (Stage == 1)
        {
            LoadMapDataToJson("mapData1.json");
            LoadObjDataToJson("objData1.json");
            LoadStageDataToJson("sData1.json");
        }
        else if (Stage == 2)
        {
            LoadMapDataToJson("mapData2.json");
            LoadObjDataToJson("objData2.json");
            LoadStageDataToJson("sData2.json");
        }
        else if (Stage == 3)
        {
            LoadMapDataToJson("mapData3.json");
            LoadObjDataToJson("objData3.json");
            LoadStageDataToJson("sData3.json");
        }
        else if (Stage == 4)
        {
            LoadMapDataToJson("mapData4.json");
            LoadObjDataToJson("objData4.json");
            LoadStageDataToJson("sData4.json");
        }
        else if (Stage == 5)
        {
            LoadMapDataToJson("mapData5.json");
            LoadObjDataToJson("objData5.json");
            LoadStageDataToJson("sData5.json");
        }
        else if (Stage == 6)
        {
            LoadMapDataToJson("mapData6.json");
            LoadObjDataToJson("objData6.json");
            LoadStageDataToJson("sData6.json");
        }
        else if (Stage == 7)
        {
            LoadMapDataToJson("mapData7.json");
            LoadObjDataToJson("objData7.json");
            LoadStageDataToJson("sData7.json");
        }
        else if (Stage == 8)
        {
            LoadMapDataToJson("mapData8.json");
            LoadObjDataToJson("objData8.json");
            LoadStageDataToJson("sData8.json");
        }
        else if (Stage == 9)
        {
            LoadMapDataToJson("mapData9.json");
            LoadObjDataToJson("objData9.json");
            LoadStageDataToJson("sData9.json");
        }
        else if (Stage == 10)
        {
            LoadMapDataToJson("mapData10.json");
            LoadObjDataToJson("objData10.json");
            LoadStageDataToJson("sData10.json");
        }
        
        //여기서부터 커스텀
        else if (Stage == 13)
        {
            LoadMapDataToJson("Custom_mapData1.json");
            LoadObjDataToJson("Custom_objData1.json");
            LoadStageDataToJson("Custom_sData1.json");
        }
        else if (Stage == 14)
        {
            LoadMapDataToJson("Custom_mapData2.json");
            LoadObjDataToJson("Custom_objData2.json");
            LoadStageDataToJson("Custom_sData2.json");
        }
        else if (Stage == 15)
        {
            LoadMapDataToJson("Custom_mapData3.json");
            LoadObjDataToJson("Custom_objData3.json");
            LoadStageDataToJson("Custom_sData3.json");
        }
        else if (Stage == 16)
        {
            LoadMapDataToJson("Custom_mapData4.json");
            LoadObjDataToJson("Custom_objData4.json");
            LoadStageDataToJson("Custom_sData4.json");
        }
        else if (Stage == 17)
        {
            LoadMapDataToJson("Custom_mapData5.json");
            LoadObjDataToJson("Custom_objData5.json");
            LoadStageDataToJson("Custom_sData5.json");
        }
        else if (Stage == 18)
        {
            LoadMapDataToJson("Custom_mapData6.json");
            LoadObjDataToJson("Custom_objData6.json");
            LoadStageDataToJson("Custom_sData6.json");
        }
        else if (Stage == 19)
        {
            LoadMapDataToJson("Custom_mapData7.json");
            LoadObjDataToJson("Custom_objData7.json");
            LoadStageDataToJson("Custom_sData7.json");
        }
        else if (Stage == 20)
        {
            LoadMapDataToJson("Custom_mapData8.json");
            LoadObjDataToJson("Custom_objData8.json");
            LoadStageDataToJson("Custom_sData8.json");
        }
        else if (Stage == 21)
        {
            LoadMapDataToJson("Custom_mapData9.json");
            LoadObjDataToJson("Custom_objData9.json");
            LoadStageDataToJson("Custom_sData9.json");
        }
        else if (Stage == 22)
        {
            LoadMapDataToJson("Custom_mapData10.json");
            LoadObjDataToJson("Custom_objData10.json");
            LoadStageDataToJson("Custom_sData10.json");
        }
    }

    private void Update()
    {
        SaveStarDataToJson();
    }
}


[System.Serializable]
public class MapX
{
    public int[] mapX = new int[10]; //맵의 x값
}
[System.Serializable]
public class MapData
{
    public MapX[] map = new MapX[20];
}