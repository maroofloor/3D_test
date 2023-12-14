using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�����۵��� �����ϰ� ����
//���� ���� �����۵��� �˻� �ϰų�, ���ϰų� ���ų�...
public class Inventory //: MonoBehaviour
{
    int slotNum; // �� �κ��丮�� ĭ ��

    public Item[] items;
    //bool[] isEmpty;

    public Inventory(int slotnum = 20)
    {
        GetInventory(slotnum);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slotNum">������� �κ��丮�� ���԰���</param>
    void GetInventory(int slotnum = 20)
    {
        this.slotNum = slotnum;
        items = new Item[slotNum];
        //isEmpty = new bool[slotNum];
        UIManager.Instance.inventoryUI.SetSlotUI(slotnum);

        AllSetInventoryClear();
    }

    public void SetInventoryClear(int index)
    {
        items[index] = new Item();
    }
    public void AllSetInventoryClear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item();
            //isEmpty[i] = true;
        }
    }

    public void SetItemInInventory(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemIndex == item.itemIndex && items[i].itemNum < items[i].itemMaxNum)
            {
                items[i].itemNum += item.itemNum;
                int remain = items[i].itemNum - items[i].itemMaxNum;

                if (items[i].itemNum > items[i].itemMaxNum)
                {
                    items[i].itemNum = items[i].itemMaxNum;
                }
                UIManager.Instance.inventoryUI.slotSpaceTr.GetChild(i).GetComponent<SlotUI>().SetMatching(items[i]);
                return;
            }
            else if (items[i].itemIndex != 0)
                continue;
            else
            {
                items[i] = item;
                UIManager.Instance.inventoryUI.slotSpaceTr.GetChild(i).GetComponent<SlotUI>().SetMatching(items[i]);
                return;
            }
        }
    }
}
