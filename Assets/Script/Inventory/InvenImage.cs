using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenImage : MonoBehaviour
{

    public GameObject[] invenImage;
    public GameObject[] invenText;

    // Update is called once per frame
    void Update()
    {
        //if (Inventory.instance.equipment_items.Count == 0 && gameObject.GetComponent<Image>().sprite == null)
        //{
        //    if (true)
        //    {

        //    }
        //    gameObject.GetComponent<Image>().sprite = Inventory.instance.equipment_items[0].itemImage;
        //}


        if (Inventory.instance.equipment_items.Count == 0)
        {
            invenImage[0].GetComponent<Image>().sprite = null;
            invenText[0].SetActive(false); //text 끄기
        }


        for (int i = 0; i < Inventory.instance.equipment_items.Count; i++)
        {
            if (invenImage[i].GetComponent<Image>().sprite == null)
            {
                invenImage[i].GetComponent<Image>().sprite = Inventory.instance.equipment_items[i].itemImage; //이미지 넣기

                invenText[i].SetActive(true);
                invenText[i].GetComponent<Text>().text = Inventory.instance.equipment_items[i].num.ToString(); //text 넣기
            }
            else if (invenImage[i].GetComponent<Image>().sprite != Inventory.instance.equipment_items[i].itemImage)
            {
                invenImage[i].GetComponent<Image>().sprite = Inventory.instance.equipment_items[i].itemImage; //

                invenText[i].SetActive(true);
                invenText[i].GetComponent<Text>().text = Inventory.instance.equipment_items[i].num.ToString(); //text 넣기

                invenImage[i + 1].GetComponent<Image>().sprite = null;
                invenText[i + 1].SetActive(false);

            }
            else if (invenImage[i].GetComponent<Image>().sprite == Inventory.instance.equipment_items[i].itemImage)
            {
                invenText[i].SetActive(true);
                invenText[i].GetComponent<Text>().text = Inventory.instance.equipment_items[i].num.ToString(); //text 넣기
            }
        }

        if (Inventory.instance.equipment_items.Count != invenImage.Length)
        {
            for (int i = Inventory.instance.equipment_items.Count; i < invenImage.Length; i++)
            {
                invenText[i].SetActive(false);
                invenImage[i].GetComponent<Image>().sprite = null;
            }
        }
        

        
    }
}
