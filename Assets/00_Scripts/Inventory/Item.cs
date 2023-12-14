using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//슬롯밑에 들어갈 아이템
//다양한 아이템들은 후에 이 클래스를 상속받아서 구현하도록

public class Item //: MonoBehaviour
{
    //아이템 개수
    //아이템의 고유번호 - 이름or숫자

    public AllEnum.ItemType itemType;
    public int itemIndex;
    public Sprite itemSprite;
    public int itemNum;
    public Dictionary<AllEnum.ItemType, int> itemMaxNumDic = new Dictionary<AllEnum.ItemType, int>() 
    { 
        { AllEnum.ItemType.Potion, 10 },
        { AllEnum.ItemType.Armor, 1 },
        { AllEnum.ItemType.Weapon, 1 },
        {AllEnum.ItemType.Scrap, 5 } 
    };
    public int itemMaxNum => itemMaxNumDic[itemType];

    public Item()
    {
        itemType = AllEnum.ItemType.End;
        itemIndex = 0;
        itemSprite = ResourceManager.Instance.itemSprites[0];
        itemNum = 0;
    }
    public Item(AllEnum.ItemType type, int index, int num = 1)
    {
        itemType = type;
        itemIndex = index;
        itemSprite = ResourceManager.Instance.itemSprites[index];
        itemNum = num;
    }
    
}