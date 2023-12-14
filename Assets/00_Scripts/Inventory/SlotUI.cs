using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int slotIndex;
    List<RaycastResult> raycastResults = new List<RaycastResult>();


    SlotUI nextSlot;

    Image img;
    Text numTxt;

    Item item;

    void Start()
    {
        img = transform.GetChild(0).GetComponent<Image>();
        numTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
    }

    public void SetMatching(Item item)
    {
        this.item = item;
        SetItemImg();
        SetItemNum();
    }
    public void SetItemImg()
    {
        if (img == null)
            img = transform.GetChild(0).GetComponent<Image>();

        img.sprite = item.itemSprite;
    }
    public void SetItemNum()
    {
        if (numTxt == null)
            numTxt = transform.GetChild(0).GetChild(0).GetComponent<Text>();

        if (item.itemNum <= 1)
        {
            numTxt.gameObject.SetActive(false);
        }
        else
        {
            numTxt.gameObject.SetActive(true);
            numTxt.text = $"{item.itemNum}";
        }
    }

    public void OnBeginDrag(PointerEventData eventData)//드래그 시작
    {
        raycastResults.Clear();
        img.color = Color.clear;
        numTxt.color = Color.clear;
        UIManager.Instance.FollowDragImg.gameObject.SetActive(true);
        UIManager.Instance.FollowDragImg.transform.position = eventData.pressPosition;
        UIManager.Instance.FollowDragImg.sprite = item.itemSprite;
    }

    public void OnDrag(PointerEventData eventData)//드래그중
    {
        UIManager.Instance.FollowDragImg.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)//드래그 끝남
    {
        UIManager.Instance.GraphicRay.Raycast(eventData, raycastResults);

        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.TryGetComponent<SlotUI>(out nextSlot))
            {
                Item tmp = item;
                item = nextSlot.item;
                nextSlot.item = tmp;
                ResourceManager.Instance.inventory.SwapItemsArr(slotIndex, nextSlot.slotIndex);
                SetMatching(item);
                nextSlot.SetMatching(nextSlot.item);
            }
        }
        UIManager.Instance.FollowDragImg.gameObject.SetActive(false);
        img.color = Color.white;
        numTxt.color = Color.white;

        nextSlot = null;

        //for (int i = 0; i < raycastResults.Count; i++)
        //{
        //    raycastResults[i].gameObject.GetComponent<SlotUI>();
        //    if (nextSlot != null)
        //    {
        //        break;
        //    }
        //}

        //if (nextSlot != null)
        //{
        //    //아이템 바꿔끼기
        //    //바뀌는건 똑같이 SlotUI
        //    //
        //}
    }

    public void OnPointerClick(PointerEventData eventData)//클릭
    {
    }
}
