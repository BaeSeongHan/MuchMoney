using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private GameObject canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public static Image i_Image; //아이템 이미지


    //public GameObject image; //복제할 이미지

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
        //image = null;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("??? OnBeginDrag"); //??
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("이미지 드래그 하는중 OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("이미지 드래그 끝나는거 OnEndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("이미지 클릭 OnPointerDown");

        i_Image.sprite = gameObject.GetComponent<Image>().sprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
