using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Instance => instance;

    Queue<Bullet> magQue = new Queue<Bullet>();
    Queue<Bullet> usedQue = new Queue<Bullet>();
    public GameObject bullet;

    public Player player;

    public Transform pos1, pos2;

    void Awake()
    {
        #region �̱��� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        #endregion
    }

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject tmp = Instantiate(bullet, transform);
            magQue.Enqueue(tmp.GetComponent<Bullet>());
            tmp.SetActive(false);
        }
    }

    public void ShootPistol()
    {
        if (magQue.Count > 0)
        {
            Bullet tmp = magQue.Dequeue();
            tmp.SetInfo(player);
            tmp.gameObject.SetActive(true);
            Debug.Log($"���� ź�� : {magQue.Count} / 12");
        }
        else
        {
            Debug.Log("ź�� ���ڶ��ϴ�, �������ϼ���.");
        }
    }

    public void ReloadPistol()
    {
        //for (int i = 0; i < usedQue.Count; i++)
        //{
        //    magQue.Enqueue(usedQue.Dequeue());
        //}

        for (int i = 0; i < 12; i++)
        {
            if (usedQue.Count <= 0)
                return;
            magQue.Enqueue(usedQue.Dequeue());
        }
        Debug.Log($"���� ź�� : {magQue.Count} / 12");
    }

    public void EnqueueUsedQue(Bullet bullet)
    {
        usedQue.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
