using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_objList : MonoBehaviour
{
    public Button tree; //���� ��ư
    public Button rock; //�� ��ư
    public Button thisButton; //���� ��ư

    public Canvas TREECANVAS; //���� ���� �˹���

    public Dropdown obj_list; //������Ʈ ����Ʈ

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
