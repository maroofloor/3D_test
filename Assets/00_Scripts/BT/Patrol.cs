using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Node
{
    Enemy owner;

    Vector3 goalPos = Vector3.zero;
    float currentTime = 0f;
    float nextTime = 0f;

    bool isMove = false;
    public Patrol(Enemy _owner)
    {
        owner = _owner;
        SetNextTime();
    }
    void SetNextTime()
    {
        nextTime = Random.Range(3f, 4f);
    }
    public override NodeState Evaluate()
    {
        if (isMove)
        {
            owner.SetMoveAnim();
            if ((owner.transform.position - goalPos).sqrMagnitude <= 1)
            {
                isMove = false;
            }
        }
        else
        {
            owner.Idle();
            if (currentTime >= nextTime)
            {
                currentTime = 0f;
                SetNextTime();
                if ((GameManager.Instance.pos1.position - owner.transform.position).sqrMagnitude 
                    >
                    (GameManager.Instance.pos2.position - owner.transform.position).sqrMagnitude)
                    goalPos = GameManager.Instance.pos1.position;
                else
                    goalPos = GameManager.Instance.pos2.position;

                owner.Move(goalPos);
                isMove = true;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }

        return NodeState.Success;
    }
}
