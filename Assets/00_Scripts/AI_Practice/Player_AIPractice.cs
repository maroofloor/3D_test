using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AIPractice : MonoBehaviour
{
    float x;
    float z;
    Vector3 moveVec = Vector3.zero;

    float speed = 5f;

    Rigidbody rigid;
    BoxCollider col;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        moveVec.x = x;
        moveVec.z = z;
        rigid.velocity = moveVec.normalized * speed;
    }
}
