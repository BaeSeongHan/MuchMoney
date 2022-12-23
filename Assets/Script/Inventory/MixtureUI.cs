using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixtureUI : MonoBehaviour
{
    public GameObject[] Panel; //판넬

    public bool open; //열려있는지 아닌지


    public GameObject[] kkkkImage; //칼판넬 재료이미지

    public GameObject[] wwwwImage; //판자판넬 재료이미지

    public GameObject[] mixImage;  //제작아이템 이미지


    public bool kMixbool;
    public Sprite k_image; //칼
    public Sprite w_image; //판자


    public GameObject player; //플레이어 오브젝트 가져올거

    private void Start()
    {
        open = true;
        kMixbool = false;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        for (int i = 0; i < kkkkImage.Length; i++)
        {
            if (kkkkImage[i].GetComponent<Image>().color.a == 1.0f)
            {
                mixImage[0].gameObject.SetActive(true);
            }
            else if (kkkkImage[i].GetComponent<Image>().color.a != 1.0f)
            {
                mixImage[0].gameObject.SetActive(false);
            }  
        }

        for (int i = 0; i < wwwwImage.Length; i++)
        {
            if (wwwwImage[i].GetComponent<Image>().color.a == 1.0f)
            {
                mixImage[1].gameObject.SetActive(true);
            }
            else if (wwwwImage[i].GetComponent<Image>().color.a != 1.0f)
            {
                mixImage[1].gameObject.SetActive(false);
            }
        }
    }

    public void openKUI() //칼 UI open
    {
        for (int i = 0; i < Panel.Length; i++)
        {
            if (i == 0)
            {
                if (Panel[i].activeSelf == true)
                {
                    Panel[i].SetActive(false);
                }
                else if (Panel[i].activeSelf == false)
                {
                    Panel[i].SetActive(true);
                }
            }
            else
            {
                Panel[i].SetActive(false);
            }
        }

          
    }

    public void openBUI() //판자 UI open
    {
        for (int i = 0; i < Panel.Length; i++)
        {
            if (i == 1)
            {
                if (Panel[i].activeSelf == true)
                {
                    Panel[i].SetActive(false);
                }
                else if (Panel[i].activeSelf == false)
                {
                    Panel[i].SetActive(true);
                }
            }
            else
            {
                Panel[i].SetActive(false);
            }
        }
    } 


    public void mixItem() //칼 아이템 제작하기
    {
        for (int i = 0; i < kkkkImage.Length; i++)
        {
            if (kkkkImage[i].GetComponent<Image>().color.a == 1.0f)
            {
                kMixbool = true;
                continue;
            }
            else if (kkkkImage[i].GetComponent<Image>().color.a != 1.0f)
            {
                kMixbool = false;
                break;
            }  
        }


        if (kMixbool == true)
        {
            for (int i = 0; i < kkkkImage.Length; i++)
            {
                Color c = kkkkImage[i].GetComponent<Image>().color;
                c.a = 0.5f;
                kkkkImage[i].GetComponent<Image>().color = c;
            }

            Item _item = new Item();

            _item.itemName = "칼";
            _item.itemImage = k_image;
            _item.itemType = ItemType.Equipment;


            if (Inventory.instance.equipment_items.Count == 0)
            {
                Inventory.instance.equipment_items.Add(_item);

                if (player != null)
                {
                    //제작시 소모 HP
                    player.GetComponent<PlayerMove>().actionPoint -= 3;
                }
            }

            for (int i = 0; i < Inventory.instance.equipment_items.Count; i++)
            {
                if (Inventory.instance.equipment_items[i].itemName == _item.itemName)
                {
                    Inventory.instance.equipment_items[i].num++;
                    //Debug.Log("break");
                    break;
                }
                else if (Inventory.instance.equipment_items[i].itemName != _item.itemName)
                {
                    if (i < Inventory.instance.equipment_items.Count - 1)
                    {
                        //Debug.Log("continue");
                        continue;
                    }
                }
                Inventory.instance.equipment_items.Add(_item);
                if (player != null)
                {
                    //제작시 소모 HP
                    player.GetComponent<PlayerMove>().actionPoint -= 3;
                }
            }


            mixImage[0].gameObject.SetActive(false); // 칼 이미지 꺼주기


            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (Inventory.instance.items[i].num == 0)  //아이템을 사용해서 재료 인벤토리 슬롯 삭제
                {
                    Inventory.instance.items.RemoveAt(i);
                }
            }
        }

        else if (kMixbool == false)
        {
            for (int i = 0; i < kkkkImage.Length; i++)
            {
                if (kkkkImage[i].GetComponent<Image>().color.a == 1.0f)
                {
                    Color c = kkkkImage[i].GetComponent<Image>().color;
                    c.a = 0.5f;
                    kkkkImage[i].GetComponent<Image>().color = c;

                    for (int j = 0; j < Inventory.instance.items.Count; j++)
                    {
                        if (Inventory.instance.items[j].itemImage == kkkkImage[j].GetComponent<Image>().sprite)
                        {
                            Inventory.instance.items[j].num++;
                        }
                    }
                }
            }
        }
    }


    public void mixItem_W() //판자 아이템 제작하기
    {
        for (int i = 0; i < wwwwImage.Length; i++)
        {
            if (wwwwImage[i].GetComponent<Image>().color.a == 1.0f)
            {
                kMixbool = true;
                continue;
            }
            else if (wwwwImage[i].GetComponent<Image>().color.a != 1.0f)
            {
                kMixbool = false;
                break;
            }
        }


        if (kMixbool == true)
        {
            for (int i = 0; i < wwwwImage.Length; i++)
            {
                Color c = wwwwImage[i].GetComponent<Image>().color;
                c.a = 0.5f;
                wwwwImage[i].GetComponent<Image>().color = c;
            }

            Item _item = new Item();

            _item.itemName = "판자";
            _item.itemImage = w_image;
            _item.itemType = ItemType.Equipment;

           

            if (Inventory.instance.equipment_items.Count == 0)
            {
                Inventory.instance.equipment_items.Add(_item);
                if (player != null)
                {
                    //제작시 소모 HP
                    player.GetComponent<PlayerMove>().actionPoint -= 1;
                }
            }

            for (int i = 0; i < Inventory.instance.equipment_items.Count; i++)
            {
                if (Inventory.instance.equipment_items[i].itemName == _item.itemName)
                {
                    Inventory.instance.equipment_items[i].num++;
                    //Debug.Log("break");
                    break;
                }
                else if (Inventory.instance.equipment_items[i].itemName != _item.itemName)
                {
                    if (i < Inventory.instance.equipment_items.Count - 1)
                    {
                        //Debug.Log("continue");
                        continue;
                    }
                }
                Inventory.instance.equipment_items.Add(_item);

                if (player != null)
                {
                    //제작시 소모 HP
                    player.GetComponent<PlayerMove>().actionPoint -= 1;
                }
            }

            for (int i = 0; i < Inventory.instance.items.Count; i++)
            {
                if (Inventory.instance.items[i].num == 0)  //아이템을 사용해서 재료 인벤토리 슬롯 삭제
                {
                    Inventory.instance.items.RemoveAt(i);
                }
            }
        }

        else if (kMixbool == false)
        {
            for (int i = 0; i < wwwwImage.Length; i++)
            {
                if (wwwwImage[i].GetComponent<Image>().color.a == 1.0f)
                {
                    Color c = wwwwImage[i].GetComponent<Image>().color;
                    c.a = 0.5f;
                    wwwwImage[i].GetComponent<Image>().color = c;

                    for (int j = 0; j < Inventory.instance.items.Count; j++)
                    {
                        if (Inventory.instance.items[j].itemImage == wwwwImage[j].GetComponent<Image>().sprite)
                        {
                            Inventory.instance.items[j].num++;
                        }
                    }
                }
            }
        }
    }
}
