using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObj : MonoBehaviour
{
    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public string TagName;
    public float shortDis;

    public GameObject M;

    private void Awake()
    {
        if (GameObject.Find("M") != null)
        {
            M = GameObject.Find("M");
        }
    }

    private void OnMouseDrag()
    {
        if (M == null)
        {
            return;
        }
        if (M.GetComponent<MapGenerator>().mode == 40)
        {
            if (gameObject.tag == "button")
            {
                gameObject.transform.parent.gameObject.layer = 7;
                Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                transform.parent.gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePostion);
            }
            else if (gameObject.GetComponent<ObjCode>().obj_State == 4)
            {
                gameObject.transform.parent.gameObject.layer = 7;
                Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                transform.parent.gameObject.transform.position = Camera.main.ScreenToWorldPoint(mousePostion);
            }
            else
            {
                gameObject.layer = 7;
                Vector3 mousePostion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                transform.position = Camera.main.ScreenToWorldPoint(mousePostion);
            } 
        }       
    }

    private void OnMouseUp()
    {
        if (M == null)
        {
            return;
        }
        if (M.GetComponent<MapGenerator>().mode == 40)
        {
            FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(TagName));
            shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position); // ù��°�� �������� ����ֱ� 

            enemy = FoundObjects[0]; // ù��°�� ���� 

            foreach (GameObject found in FoundObjects)
            {
                float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis) // ������ ���� �������� �Ÿ� ���
                {
                    enemy = found;
                    shortDis = Distance;
                }
            }
            Debug.Log(enemy.name);

            //���� ����� ���� ��ġ�� �̵�
            if (gameObject.tag == "button")
            {
                transform.parent.gameObject.transform.position = new Vector3(enemy.transform.position.x, 0.01f, enemy.transform.position.z);
            }
            else if(gameObject.GetComponent<ObjCode>().obj_State == 8)
            {
                transform.position = new Vector3(enemy.transform.position.x, 0.3f, enemy.transform.position.z);
            }
            else if (gameObject.GetComponent<ObjCode>().obj_State == 4)
            {
                transform.parent.gameObject.transform.position = new Vector3(enemy.transform.position.x, 0.01f, enemy.transform.position.z);
            }
            else 
            {
                transform.position = new Vector3(enemy.transform.position.x, 0.1f, enemy.transform.position.z);
            }

            //���̾� ���ֱ�
            gameObject.layer = 0;
        } 
    }
}
