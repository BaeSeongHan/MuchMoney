using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBrush : MonoBehaviour
{
    public Camera get_Camera; //ī�޶� �����ð�

    public List<Vector3> clicks = new List<Vector3>(); //Ŭ���Ѱ� ���� vector3����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    RaycastHit obj_hit;

    
    void BrushRay()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = get_Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Ground" || Physics.Raycast(ray, out obj_hit) && obj_hit.transform.tag == "Water")
            {
                Vector3 a = obj_hit.transform.position;

                if (clicks.Contains(a))
                {
                    Debug.Log("������ �ִ�.");
                }
                else
                {
                    clicks.Add(a); //����Ʈ�� ���ϱ�
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //��ġ�� �ش��ϴ� ������Ʈ�� �����ϰ�, ����Ʈ�� �ʱ�ȭ�Ѵ�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))//���콺��ư ������ �ִ� ����
        {
            //���̸� ���� ������Ʈ�� ������ �� ������Ʈ ��ġ ���� ������Ʈ ���� ������Ʈ ��ġ�� �ٸ���
            //������ ������Ʈ �������� ����
            //

            Debug.Log("�����µ���");
        }*/
        BrushRay();
    }

    

}
