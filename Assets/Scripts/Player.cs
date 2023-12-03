using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 4f;
    [SerializeField]
    float moveSpeed = 2.5f;
    float xRotate = 0f;
    float yRotate = 0f;
    Vector3 rotateVec = Vector3.zero;
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
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 5f;
        else
            moveSpeed = 2.5f;

        x = Input.GetAxisRaw("Horizontal"); // 좌우 이동
        z = Input.GetAxisRaw("Vertical"); // 앞뒤 이동
        moveVec.x = x;
        moveVec.z = z;

        #region 애니메이션
        if (x != 0)
            anim.SetFloat("Speed", x > 0 ? moveSpeed : -x * moveSpeed /*Mathf.Abs(x * moveSpeed)*/);
        else
            anim.SetFloat("Speed", z > 0 ? moveSpeed : -z * moveSpeed /*Mathf.Abs(z * moveSpeed)*/);

        anim.SetFloat("PosX", x);
        anim.SetFloat("PosZ", z);
        #endregion

        if (Input.GetKeyDown(KeyCode.Space) && OnGround) // 점프
        {
            OnGround = false;
            jumpVec.z = z;
            jumpVec.x = x;
            anim.SetBool("IsJump", true);
            StartCoroutine(WaitJump());
        }

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

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        rotateVec.x = xRotate;
        rotateVec.y = yRotate;

        transform.eulerAngles = rotateVec;
    }
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
}



//public class FirstPerson : MonoBehaviour
//{
//    public float turnSpeed = 4.0f; // 마우스 회전 속도
//    public float moveSpeed = 2.0f; // 이동 속도

//    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

//    void Update()
//    {
//        MouseRotation();
//        KeyboardMove();
//    }

//    // 마우스의 움직임에 따라 카메라를 회전 시킨다.
//    void MouseRotation()
//    {
//        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
//        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
//        // 현재 y축 회전값에 더한 새로운 회전각도 계산
//        float yRotate = transform.eulerAngles.y + yRotateSize;

//        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
//        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
//        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
//        // Clamp 는 값의 범위를 제한하는 함수
//        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

//        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
//        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
//    }

//    // 키보드의 눌림에 따라 이동
//    void KeyboardMove()
//    {
//        // WASD 키 또는 화살표키의 이동량을 측정
//        Vector3 dir = new Vector3(
//            Input.GetAxis("Horizontal"),
//            0,
//            Input.GetAxis("Vertical")
//        );
//        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
//        transform.Translate(dir * moveSpeed * Time.deltaTime);
//    }
//}