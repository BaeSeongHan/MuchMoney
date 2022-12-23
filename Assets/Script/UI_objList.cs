using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_objList : MonoBehaviour
{
    public Button tree; //나무 버튼
    public Button rock; //돌 버튼
    public Button thisButton; //현재 버튼

    public Canvas TREECANVAS; //나무 관련 켄버스

    public Dropdown obj_list; //오브젝트 리스트

    private void Start()
    {
        if (obj_list.value == 0)
        {
            tree.gameObject.SetActive(true);
        }
    }

    public void Tree_Button_Open()
    {
        if (obj_list.value == 0)
        {
            Debug.Log("aa");
            tree.gameObject.SetActive(true);
            rock.gameObject.SetActive(false);
        }
        else if (obj_list.value == 1)
        {
            tree.gameObject.SetActive(false);
            rock.gameObject.SetActive(true);
        }
        else
        {
            tree.gameObject.SetActive(false);
            rock.gameObject.SetActive(false);
        }
        
    }
}
