using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static ResourceManager instance = null;
    public static ResourceManager Instance => instance;

    [SerializeField]
    public Sprite[] itemSprites;

    public Inventory inventory;

    void Awake()
    {
        #region ΩÃ±€≈Ê
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion
    }

    void Start()
    {
        inventory = new Inventory();
        UIManager.Instance.inventoryUI.AllSlotMatching();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.SetItemInInventory(new Item(AllEnum.ItemType.Potion, 1, 8));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.SetItemInInventory(new Item(AllEnum.ItemType.Armor, 2, 2));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.SetItemInInventory(new Item(AllEnum.ItemType.Weapon, 3));
        }
    }

}
