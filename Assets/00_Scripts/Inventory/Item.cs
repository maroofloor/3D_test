using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���Թؿ� �� ������
//�پ��� �����۵��� �Ŀ� �� Ŭ������ ��ӹ޾Ƽ� �����ϵ���

public class Item //: MonoBehaviour
{
    //������ ����
    //�������� ������ȣ - �̸�or����

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