using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour // ΩÃ±€≈Ê
{
    static UIManager instance = null;
    public static UIManager Instance => instance;

    GraphicRaycaster graphicRay;
    public GraphicRaycaster GraphicRay => graphicRay;

    public InventoryUI inventoryUI;

    public Image FollowDragImg;

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
    public void Start()
    {
        graphicRay = GetComponent<GraphicRaycaster>();
        FollowDragImg.gameObject.SetActive(false);
    }
}
