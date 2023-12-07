using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ClickFreeLook : MonoBehaviour
{
    CinemachineFreeLook freecam;
    float scrollval = 0;

    private void Start()
    {
        freecam = GetComponent<CinemachineFreeLook>();
        CinemachineCore.GetInputAxis = MyAxis;
    }

    public float MyAxis(string axisname)
    {
        scrollval = Input.GetAxis("Mouse ScrollWheel");

        freecam.m_Lens.FieldOfView += scrollval * Time.deltaTime * 1000;

        if (Input.GetMouseButton(1))
        {
            return Input.GetAxis(axisname);
        }
        else
            return 0;
    }
}
