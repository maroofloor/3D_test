using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public bool isOn = true;
    public Transform slotSpaceTr;
    
    [SerializeField]
    GameObject slotUIPrefab;

    SlotUI[] slots;

    void Start()
    {
        slotSpaceTr = transform.GetChild(0);
    }

    public void SetSlotUI(int slotnum)
    {
        slots = new SlotUI[slotnum];

        for (int i = 0; i < slotnum; i++)
        {
            GameObject tmp = Instantiate(slotUIPrefab, slotSpaceTr);
            tmp.GetComponent<SlotUI>().slotIndex = i;
            slots[i] = tmp.GetComponent<SlotUI>();
        }

        //for (int i = 0; i < slotnum; i++)
        //{
        //    slots[i].SetMatching(ResourceManager.Instance.inventory.items[i]);
        //}
    }

    public void AllSlotMatching()
    {
        for (int i = 0; i < ResourceManager.Instance.inventory.items.Length; i++)
        {
            UIManager.Instance.inventoryUI.slotSpaceTr.GetChild(i).GetComponent<SlotUI>().SetMatching(ResourceManager.Instance.inventory.items[i]);
        }
    }
}
