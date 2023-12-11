using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Idle()
    {
        anim.SetFloat("Speed", 0);
    }
    public void Walk(float x, float z)
    {
        anim.SetFloat("Speed", 2.5f);
        anim.SetFloat("PosX", x);
        anim.SetFloat("PosZ", z);
    }
    public void Run(float x, float z)
    {
        anim.SetFloat("Speed", 5f);
        anim.SetFloat("PosX", x);
        anim.SetFloat("PosZ", z);
    }
    public void Attack()
    {

    }
}
