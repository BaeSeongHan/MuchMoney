using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BRUSHMODD
{
    tree,
    rock,
    button,
    wall,
    monster,
    goal,
    moverook,  //이건 돌에서 설정으로 변경 가능하게 만드는게 좋을거 같다.
    coin,
    wall_1,
    wall_2,

    G,
    W,
    move,
    delite,
    changeData,
    player
}

public class mode : MonoBehaviour
{
    public BRUSHMODD brushmode; //브러쉬 모드

    public GameObject mapGenerator; //맵 제너레이터

    public void ChangeMode()
    {
        switch (brushmode)
        {
            case BRUSHMODD.tree:
                mapGenerator.GetComponent<MapGenerator>().mode = 1;
                break;
            case BRUSHMODD.rock:
                mapGenerator.GetComponent<MapGenerator>().mode = 2;
                break;
            case BRUSHMODD.button:
                mapGenerator.GetComponent<MapGenerator>().mode = 3;
                break;
            case BRUSHMODD.wall:
                mapGenerator.GetComponent<MapGenerator>().mode = 4;
                break;
            case BRUSHMODD.monster:
                mapGenerator.GetComponent<MapGenerator>().mode = 5;
                break;
            case BRUSHMODD.goal:
                mapGenerator.GetComponent<MapGenerator>().mode = 6;
                break;
            case BRUSHMODD.moverook:
                mapGenerator.GetComponent<MapGenerator>().mode = 7;
                break;
            case BRUSHMODD.coin:
                mapGenerator.GetComponent<MapGenerator>().mode = 8;
                break;
            case BRUSHMODD.wall_1:
                mapGenerator.GetComponent<MapGenerator>().mode = 9;
                break;
            case BRUSHMODD.wall_2:
                mapGenerator.GetComponent<MapGenerator>().mode = 10;
                break;
            case BRUSHMODD.player:
                mapGenerator.GetComponent<MapGenerator>().mode = 19; //플레이어
                break;
            case BRUSHMODD.G:
                mapGenerator.GetComponent<MapGenerator>().mode = 20; //20번대 시작
                break;
            case BRUSHMODD.W:
                mapGenerator.GetComponent<MapGenerator>().mode = 21;
                break;
            case BRUSHMODD.move:
                mapGenerator.GetComponent<MapGenerator>().mode = 40; //40번대 시작
                break;
            case BRUSHMODD.delite:
                mapGenerator.GetComponent<MapGenerator>().mode = 41;
                break;
            case BRUSHMODD.changeData:
                mapGenerator.GetComponent<MapGenerator>().mode = 42;
                break;
            default:
                break;
        }
    }
}
