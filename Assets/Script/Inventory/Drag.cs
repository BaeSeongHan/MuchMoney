using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;


    public Transform _startParent; //시작할때의 부모
  

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        _startParent = transform.parent; //시작부모
        //image = null;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("??? OnBeginDrag"); //??
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        Inventory.instance.dragBoll = true;

        transform.SetParent(GameObject.Find("Canvas").transform); //변경할 부모
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Debug.Log("이미지 드래그 하는중 OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("이미지 드래그 끝나는거 OnEndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        

        transform.SetParent(_startParent);
        rectTransform.anchoredPosition = Vector2.zero;

        Inventory.instance.dragBoll = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("이미지 클릭 OnPointerDown");

        Inventory.instance.i_Image = gameObject.GetComponent<Image>().sprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }


    private void Update()
    {
        //if (image.GetComponent<Image>().sprite == null)
        //{
        //    image.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        //}
    }
}
