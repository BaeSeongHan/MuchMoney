using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadUI : MonoBehaviour
{
    public GameObject Json; //제이슨 파일 가져올곳

    public Dropdown drop;
    public GameObject mapgenerator; //맵 제너레이터 가져올곳

    public Text stage;

    public enum JSONDATA
    {
        num,
        stag_1,
        stag_2,
        stag_3,
        stag_4,
        stag_5,
        stag_6,
        stag_7,
        stag_8,
        stag_9,
        stag_10,

        customstage_1,
        customstage_2,
        customstage_3,
        customstage_4,
        customstage_5,
        customstage_6,
        customstage_7,
        customstage_8,
        customstage_9,
        customstage_10,

    }

    public JSONDATA jsondatamode = JSONDATA.num; //제이슨 데이터 모드

    public void jsondatamodeChange()
    {
        switch (drop.value)
        {/*
            case 1:
                jsondatamode = JSONDATA.stag_1;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData1.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData1.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData1.json");
                break;
            case 2:
                jsondatamode = JSONDATA.stag_2;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData2.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData2.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData2.json");
                break;
            case 3:
                jsondatamode = JSONDATA.stag_3;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData3.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData3.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData3.json");
                break;
            case 4:
                jsondatamode = JSONDATA.stag_4;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData4.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData4.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData4.json");
                break;
            case 5:
                jsondatamode = JSONDATA.stag_5;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData5.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData5.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData5.json");
                break;
            case 6:
                jsondatamode = JSONDATA.stag_6;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData6.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData6.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData6.json");
                break;
            case 7:
                jsondatamode = JSONDATA.stag_7;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData7.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData7.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData7.json");
                break;
            case 8:
                jsondatamode = JSONDATA.stag_8;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData8.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData8.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData8.json");
                break;
            case 9:
                jsondatamode = JSONDATA.stag_9;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData9.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData9.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData9.json");
                break;
            case 10:
                jsondatamode = JSONDATA.stag_10;
                Json.GetComponent<jsonCode>().LoadMapDataToJson("mapData10.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("objData10.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("sData10.json");
                break;
                */
            case 0:
                jsondatamode = JSONDATA.num;
                stage.text = "Stage Data: NULL";
                break;
                
            case 1:
                jsondatamode = JSONDATA.customstage_1;
                stage.text = "Stage Data: Customstage_1";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData1.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData1.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData1.json");
                break;
            case 2:
                jsondatamode = JSONDATA.customstage_2;
                stage.text = "Stage Data: Customstage_2";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData2.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData2.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData2.json");
                break;
            case 3:
                jsondatamode = JSONDATA.customstage_3;
                stage.text = "Stage Data: Customstage_3";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData3.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData3.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData3.json");
                break;
            case 4:
                jsondatamode = JSONDATA.customstage_4;
                stage.text = "Stage Data: Customstage_4";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData4.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData4.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData4.json");
                break;
            case 5:
                jsondatamode = JSONDATA.customstage_5;
                stage.text = "Stage Data: Customstage_5";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData5.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData5.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData5.json");
                break;
            case 6:
                jsondatamode = JSONDATA.customstage_6;
                stage.text = "Stage Data: Customstage_6";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData6.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData6.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData6.json");
                break;
            case 7:
                jsondatamode = JSONDATA.customstage_7;
                stage.text = "Stage Data: Customstage_7";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData7.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData7.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData7.json");
                break;
            case 8:
                jsondatamode = JSONDATA.customstage_8;
                stage.text = "Stage Data: Customstage_8";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData8.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData8.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData8.json");
                break;
            case 9:
                jsondatamode = JSONDATA.customstage_9;
                stage.text = "Stage Data: Customstage_9";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData9.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData9.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData9.json");
                break;
            case 10:
                jsondatamode = JSONDATA.customstage_10;
                stage.text = "Stage Data: Customstage_10";
                Json.GetComponent<jsonCode>().LoadMapDataToJson("Custom_mapData10.json");
                Json.GetComponent<jsonCode>().LoadObjDataToJson("Custom_objData10.json");
                Json.GetComponent<jsonCode>().LoadStageDataToJson("Custom_sData10.json");
                break;
                
            default:
                break;
        }
    }

    public void Click_Load()
    {
        /*
        switch (jsondatamode)
        {
            case JSONDATA.stag_1:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.stag_2:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.stag_3:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.stag_4:
                
                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.stag_5:
                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.stag_6:
                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.customstage_1:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.customstage_2:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.customstage_3:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.customstage_4:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            case JSONDATA.customstage_5:

                mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
                mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
                mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
                mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
                mapgenerator.GetComponent<MapGenerator>().GenerateMap();

                break;
            default:
                break;
        }
        */

        mapgenerator.GetComponent<MapGenerator>().mode = 0;

        mapgenerator.GetComponent<MapGenerator>().mapData_Test = Json.GetComponent<jsonCode>().mapData_;
        mapgenerator.GetComponent<MapGenerator>().O_Test = Json.GetComponent<jsonCode>().objData_;
        mapgenerator.GetComponent<MapGenerator>().stageData_Test = Json.GetComponent<jsonCode>().stageData_misson;
        mapgenerator.GetComponent<MapGenerator>().mapSizeChange();
        mapgenerator.GetComponent<MapGenerator>().GenerateMap();
    }

    public void Click_Save()
    {
        mapgenerator.GetComponent<MapGenerator>().mode = 0;

        switch (jsondatamode)
        {
            case JSONDATA.stag_1:

                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData1.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData1.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData1.json");

                break;
            case JSONDATA.stag_2:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData2.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData2.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData2.json");

                break;
            case JSONDATA.stag_3:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData3.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData3.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData3.json");

                break;
            case JSONDATA.stag_4:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData4.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData4.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData4.json");

                break;
            case JSONDATA.stag_5:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData5.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData5.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData5.json");

                break;
            case JSONDATA.stag_6:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData6.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData6.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData6.json");
                break;
            case JSONDATA.stag_7:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData7.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData7.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData7.json");
                break;
            case JSONDATA.stag_8:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData8.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData8.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData8.json");
                break;
            case JSONDATA.stag_9:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData9.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData9.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData9.json");
                break;
            case JSONDATA.stag_10:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("mapData10.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("objData10.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("sData10.json");
                break;

            case JSONDATA.customstage_1:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData1.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData1.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData1.json");

                break;
            case JSONDATA.customstage_2:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData2.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData2.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData2.json");

                break;
            case JSONDATA.customstage_3:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData3.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData3.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData3.json");

                break;
            case JSONDATA.customstage_4:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData4.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData4.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData4.json");

                break;
            case JSONDATA.customstage_5:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData5.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData5.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData5.json");
                break;
            case JSONDATA.customstage_6:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData6.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData6.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData6.json");
                break;
            case JSONDATA.customstage_7:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData7.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData7.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData7.json");
                break;
            case JSONDATA.customstage_8:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData8.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData8.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData8.json");
                break;
            case JSONDATA.customstage_9:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData9.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData9.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData9.json");
                break;
            case JSONDATA.customstage_10:
                Json.GetComponent<jsonCode>().mapData_ = mapgenerator.GetComponent<MapGenerator>().mapData_Test;
                Json.GetComponent<jsonCode>().objData_ = mapgenerator.GetComponent<MapGenerator>().O_Test;
                Json.GetComponent<jsonCode>().stageData_misson = mapgenerator.GetComponent<MapGenerator>().stageData_Test;

                Json.GetComponent<jsonCode>().SaveMapDataToJson("Custom_mapData10.json");
                Json.GetComponent<jsonCode>().SaveObjDataToJson("Custom_objData10.json");
                Json.GetComponent<jsonCode>().SaveStageDataToJson("Custom_sData10.json");
                break;

            default:
                break;
        }
    }
}
