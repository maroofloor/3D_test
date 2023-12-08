using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTr;

    float xRotate = 0f;
    float yRotate = 0f;

    Vector3 rotateVec = Vector3.zero;

    private void Start()
    {
        transform.parent = playerTr;
        transform.localPosition = new Vector3(0, 0, -3);
        transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        xRotate += Input.GetAxis("Mouse X");
        //rotateVec.y = xRotate;

        yRotate = Input.GetAxis("Mouse Y");
        //rotateVec.x = yRotate;

        playerTr.parent.eulerAngles = new Vector3(playerTr.parent.rotation.x, xRotate, playerTr.parent.rotation.z);
        transform.eulerAngles = new Vector3(yRotate, transform.rotation.y, transform.rotation.z);
        transform.localRotation = Quaternion.identity;
    }
}
