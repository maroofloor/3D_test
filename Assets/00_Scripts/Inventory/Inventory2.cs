using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2
{
    int inventoryIndex;
    Dictionary<int, Item2> inventory = new Dictionary<int, Item2>();

    public Inventory2()
    {
    }
    public Inventory2(int index, int slotCount)
    {
        inventoryIndex = index;

        for (int i = 0; i < slotCount; i++)
        {
            inventory.Add(i, new Item2());
        }
    }
    
    public void SetSlotItem(int slotnum, int itemidx, int count = 1)
    {
        inventory[slotnum].SetItem(itemidx, count);
    }
    public void SetSlotClear(int slotnum)
    {
        inventory[slotnum] = new Item2();
    }
    public void AddItemCount(int slotnum, int count)
    {
        inventory[slotnum].AddCount(count);
    }
    public void SetItemCount(int slotnum, int count)
    {
        inventory[slotnum].SetCount(count);
    }
    public bool CheckItem(int itemidx, int count)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemIndex == itemidx)
            {
                count -= inventory[i].itemCount;
            }
        }
        if (count > 0)
            return false;
        else
            return true;
    }
}
