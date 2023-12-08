using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpen;
    Quaternion quat = Quaternion.identity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                quat = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                quat = Quaternion.Euler(0, 0, 0);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, quat, Time.deltaTime * 2);
    }
}
