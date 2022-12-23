using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventCode : MonoBehaviour
{
    public static InventCode instance;

    private void Awake()
    {
        instance = this;
    }

        Inventory inven;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();

        inven.onSlotCountChange += SlotChange;

        


        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }


    public int openSlot = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && GameManager.instance.IsPause == false)
        {
            //Debug.Log("aaaa");
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }

        if (Inventory.instance.dragBoll == false)
        {
            if (Inventory.instance.items.Count == 0)
            {
                slots[0].transform.GetChild(0).gameObject.SetActive(false);
                slots[0].transform.GetChild(1).gameObject.SetActive(false);
            }

            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (slots[i].transform.GetChild(1).gameObject.activeSelf == false)
                {
                    slots[i].transform.GetChild(1).gameObject.SetActive(true);
                    slots[i].transform.GetChild(0).gameObject.SetActive(true);

                    slots[i].transform.GetChild(1).GetComponent<Image>().sprite = Inventory.instance.items[i].itemImage;
                    slots[i].transform.GetChild(0).GetComponent<Text>().text = Inventory.instance.items[i].num.ToString();

                }
                else
                {
                    if (slots[i].transform.GetChild(1).GetComponent<Image>().sprite != Inventory.instance.items[i].itemImage)
                    {
                        slots[i].transform.GetChild(1).GetComponent<Image>().sprite = Inventory.instance.items[i].itemImage;
                    }

                    if (slots[i].transform.GetChild(0).GetComponent<Text>().text != Inventory.instance.items[i].num.ToString())
                    {
                        slots[i].transform.GetChild(0).GetComponent<Text>().text = Inventory.instance.items[i].num.ToString();
                    }
                }
            }

            if (slots[Inventory.instance.items.Count].transform.GetChild(1).gameObject.activeSelf == true)
            {
                slots[Inventory.instance.items.Count].transform.GetChild(0).gameObject.SetActive(false);
                slots[Inventory.instance.items.Count].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }
}
