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
        #region 싱글톤 생성
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
        CreateBullet();
    }

    public void CreateBullet()
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
            tmp.SetInfo(player.pistolTr.position, player.pistolTr.rotation);
            tmp.gameObject.SetActive(true);
            Debug.Log($"남은 탄수 : {magQue.Count} / 12");
        }
        else
        {
            Debug.Log("탄이 모자랍니다, 재장전하세요.");
        }
    }

    public void EnemyShoot(Enemy enemy)
    {
        Bullet tmp = magQue.Dequeue();
        tmp.SetInfo(enemy.pistolTr.position, enemy.pistolTr.rotation);
        tmp.gameObject.SetActive(true);
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
            {
                GameObject tmp = Instantiate(bullet, transform);
                usedQue.Enqueue(tmp.GetComponent<Bullet>());
                tmp.SetActive(false);
            }
            magQue.Enqueue(usedQue.Dequeue());

            if (magQue.Count >= 12)
                return;
        }
        Debug.Log($"남은 탄수 : {magQue.Count} / 12");
    }

    public void EnqueueUsedQue(Bullet bullet)
    {
        usedQue.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
