using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2
{
    public int itemIndex { get; private set; }
    public int itemCount { get; private set; }

    public Item2()
    {
        itemIndex = -1;
        itemCount = 0;
    }
    public Item2(int index, int count)
    {
        itemIndex = index;
        itemCount = count;
    }

    public void SetItem(int index, int count)
    {
        itemIndex = index;
        itemCount = count;
    }
    public void SetCount(int count)
    {
        itemCount = count;
    }
    public void AddCount(int count)
    {
        itemCount += count;
    }
    public void SubCount(int count)
    {
        itemCount -= count;
    }
}
