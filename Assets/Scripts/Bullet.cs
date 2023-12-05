using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    public Transform PistolTr;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider collision)
    {
        GameManager.Instance.EnqueueUsedQue(this);
    }

    public void SetInfo(Player player)
    {
        transform.position = player.pistolTr.position;
    }
}
