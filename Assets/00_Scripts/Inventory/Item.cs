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
    public int itemMaxNum = 20;

    public Item()
    {
        itemType = AllEnum.ItemType.End;
        itemIndex = 0;
        itemSprite = ResourceManager.Instance.itemSprites[0];
        itemNum = 0;
    }

    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="type"></param>
    /// <param name="index"></param>
    /// <param name="num">�Է����� ������ 1</param>
    public Item(AllEnum.ItemType type, int index, int num = 1)
    {
        itemType = type;
        itemIndex = index;
        itemSprite = ResourceManager.Instance.itemSprites[index];
        itemNum = num;
    }
    
}