using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float x;
    float z;
    float speed = 7;
    Vector3 moveVec = Vector3.zero;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        moveVec.z = z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveVec * Time.fixedDeltaTime * speed);
        transform.Rotate(0, x, 0);
    }
}

//public class FirstPerson : MonoBehaviour
//{
//    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
//    public float moveSpeed = 2.0f; // �̵� �ӵ�

//    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

//    void Update()
//    {
//        MouseRotation();
//        KeyboardMove();
//    }

//    // ���콺�� �����ӿ� ���� ī�޶� ȸ�� ��Ų��.
//    void MouseRotation()
//    {
//        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
//        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
//        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
//        float yRotate = transform.eulerAngles.y + yRotateSize;

//        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
//        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
//        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
//        // Clamp �� ���� ������ �����ϴ� �Լ�
//        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

//        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
//        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
//    }

//    // Ű������ ������ ���� �̵�
//    void KeyboardMove()
//    {
//        // WASD Ű �Ǵ� ȭ��ǥŰ�� �̵����� ����
//        Vector3 dir = new Vector3(
//            Input.GetAxis("Horizontal"),
//            0,
//            Input.GetAxis("Vertical")
//        );
//        // �̵����� * �ӵ� * �����Ӵ��� �ð��� ���ؼ� ī�޶��� Ʈ�������� �̵�
//        transform.Translate(dir * moveSpeed * Time.deltaTime);
//    }
//}