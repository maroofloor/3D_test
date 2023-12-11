using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    //float turnSpeed = 4f;
    [SerializeField]
    float moveSpeed = 1f;
    //float xRotate = 0f;
    //float yRotate = 0f;
    //Vector3 rotateVec = Vector3.zero;
    Vector3 jumpVec = Vector3.up;

    float x;
    float z;
    Vector3 moveVec = Vector3.zero;
    Rigidbody rigid;

    Animator anim;
    public SkinnedMeshRenderer bodyRenderer;
    public SkinnedMeshRenderer hairRenderer;
    [SerializeField]
    Material[] bodyMaterials;
    [SerializeField]
    Material[] hairMaterials;

    bool OnGround;
    bool IsDraw = false;
    bool IsStealth = false;

    public Transform handTr;
    public Transform holsterTr;
    public Transform pistolTr;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        OnGround = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsStealth = !IsStealth;
            anim.SetBool("IsStealth", IsStealth);
        }

        if (Input.GetKey(KeyCode.LeftShift) && IsStealth == false)
            moveSpeed = 5f;
        else if (IsStealth)
            moveSpeed = 1f;
        else
            moveSpeed = 2.5f;

        x = Input.GetAxisRaw("Horizontal"); // �¿� �̵�
        z = Input.GetAxisRaw("Vertical"); // �յ� �̵�
        moveVec.x = x;
        moveVec.z = z;

        #region �ִϸ��̼�
        if (x != 0)
            anim.SetFloat("Speed", x > 0 ? moveSpeed : -x * moveSpeed /*Mathf.Abs(x * moveSpeed)*/);
        else
            anim.SetFloat("Speed", z > 0 ? moveSpeed : -z * moveSpeed /*Mathf.Abs(z * moveSpeed)*/);

        anim.SetFloat("PosX", x);
        anim.SetFloat("PosZ", z);
        #endregion

        //if (Input.GetKeyDown(KeyCode.Space) && OnGround && IsStealth == false) // ����
        //{
        //    OnGround = false;
        //    jumpVec.z = transform.position.z + ((z != 0 && z > 0) ? 1f : -1f);
        //    jumpVec.x = transform.position.x + ((x != 0 && x > 0) ? 1f : -1f);
        //    anim.SetBool("IsJump", true);
        //    StartCoroutine(WaitJump());
        //}

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (IsDraw)
            {
                anim.SetTrigger("Holster");
                IsDraw = false;
            }
            else
            {
                anim.SetTrigger("Draw");
                IsDraw = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (IsDraw)
            {
                anim.SetTrigger("Reload");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsDraw)
            {
                anim.SetTrigger("Fire");
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bodyRenderer.material = bodyMaterials[0];
            hairRenderer.material = hairMaterials[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bodyRenderer.material = bodyMaterials[1];
            hairRenderer.material = hairMaterials[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bodyRenderer.material = bodyMaterials[2];
            hairRenderer.material = hairMaterials[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bodyRenderer.material = bodyMaterials[3];
            hairRenderer.material = hairMaterials[3];
        }

        //MouseRotation();
    }

    void FixedUpdate()
    {
        if (OnGround == false)
            return;

        transform.Translate(moveVec.normalized * Time.fixedDeltaTime * moveSpeed);
        //transform.Rotate(0, x, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        anim.SetBool("IsJump", false);
        if (collision.gameObject.CompareTag("Ground"))
            StartCoroutine(WaitLanding());
    }

    //void MouseRotation()
    //{
    //    float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
    //    yRotate = transform.eulerAngles.y + yRotateSize;

    //    float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
    //    xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

    //    rotateVec.x = xRotate;
    //    rotateVec.y = yRotate;

    //    transform.eulerAngles = rotateVec;
    //}
    public void SetDraw(int val)
    {
        if (val == 1)
        {
            pistolTr.SetParent(handTr);
        }
        else if(val == -1)
        {
            pistolTr.SetParent(holsterTr);
        }
        pistolTr.localPosition = Vector3.zero;
        pistolTr.localRotation = Quaternion.identity;
    }

    public void ShootPistol()
    {
        GameManager.Instance.ShootPistol();
    }

    public void ReloadPistol()
    {
        GameManager.Instance.ReloadPistol();
    }

    IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(0.6f);
        rigid.AddForce(jumpVec.normalized * (moveSpeed == 2.5f ? 5f : 7f), ForceMode.Impulse);
    }

    IEnumerator WaitLanding()
    {
        yield return new WaitForSeconds(1.3f);
        OnGround = true;
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