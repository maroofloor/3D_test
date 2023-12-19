using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenManager : Singleton<InvenManager>
{
    int lastIndex = 0;
    List<Inventory2> inventories = new List<Inventory2>();

    public void GetInventory(int slotcount = 10)
    {
        inventories.Add(new Inventory2(lastIndex, slotcount));
        lastIndex++;
    }
}
