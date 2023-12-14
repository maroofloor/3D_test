using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance = null;
    public static InputManager Instance => instance;

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
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (UIManager.Instance.inventoryUI.isOn)
            {
                UIManager.Instance.inventoryUI.isOn = !UIManager.Instance.inventoryUI.isOn;
                UIManager.Instance.inventoryUI.gameObject.SetActive(false);
            }
            else
            {
                UIManager.Instance.inventoryUI.isOn = !UIManager.Instance.inventoryUI.isOn;
                UIManager.Instance.inventoryUI.gameObject.SetActive(true);
            }
        }
    }
}
