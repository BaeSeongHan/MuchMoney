using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
   
    private void Awake()
    {
        instance = this;
    }

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public bool dragBoll; //드래그 했는지 안했는지 판단
    public List<Item> items = new List<Item>(); //재료아이템 들어가는곳
    public int itemCount; //아이템 종류 수.


    public Sprite i_Image; //드래그하는 아이템 이미지

    public List<Item> equipment_items = new List<Item>(); //제작 아이템 들어가는곳

    private int slotCount;
    public int SlotCnt
    {
        get=>slotCount;
        set{
            slotCount = value;
            onSlotCountChange.Invoke(slotCount);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        slotCount = 5;
    }
}
