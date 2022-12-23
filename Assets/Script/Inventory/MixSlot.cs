using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MixSlot : MonoBehaviour, IDropHandler
{
    public GameObject inventoryObj; //인벤토리 오브젝트 넣는곳


    public void OnDrop(PointerEventData eventData)
    {
        if (gameObject.transform.GetChild(0).GetComponent<Image>().sprite == inventoryObj.GetComponent<Inventory>().i_Image)
        {
            if (gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color.a != 1.0f)
            {
                

                //아이템이 슬롯에 들어갔다고 알려주기
                for (int i = 0; i < Inventory.instance.items.Count; i++)
                {
                    if (Inventory.instance.items[i].itemImage == inventoryObj.GetComponent<Inventory>().i_Image)
                    {
                        if (Inventory.instance.items[i].num != 0)
                        {
                            Color c = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color;

                            c.a = 1.0f;
                            gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = c;

                            Inventory.instance.items[i].num--;
                        }

                        

                        //if (Inventory.instance.items[i].num == 0)  //여기있어야하나?
                        //{
                        //    Inventory.instance.items.RemoveAt(i);
                        //}
                    }
                }
            }

            inventoryObj.GetComponent<Inventory>().i_Image = null;
        }
    }


    public void cancelMixItem() //아이템 재료 다시 돌리기
    {
        if (gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color.a == 1.0f)
        {
            Color c = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color;

            c.a = 0.5f;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = c;

            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (Inventory.instance.items[i].itemImage == gameObject.transform.GetChild(0).GetComponent<Image>().sprite)
                {
                    Inventory.instance.items[i].num++;
                }
            }
        }
    }

    
}
