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
    moverook,  //�̰� ������ �������� ���� �����ϰ� ����°� ������ ����.
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
    public BRUSHMODD brushmode; //�귯�� ���

    public GameObject mapGenerator; //�� ���ʷ�����

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
                mapGenerator.GetComponent<MapGenerator>().mode = 19; //�÷��̾�
                break;
            case BRUSHMODD.G:
                mapGenerator.GetComponent<MapGenerator>().mode = 20; //20���� ����
                break;
            case BRUSHMODD.W:
                mapGenerator.GetComponent<MapGenerator>().mode = 21;
                break;
            case BRUSHMODD.move:
                mapGenerator.GetComponent<MapGenerator>().mode = 40; //40���� ����
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
