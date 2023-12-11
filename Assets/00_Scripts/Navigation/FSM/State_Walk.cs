using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Walk : State
{
    Vector3 goalPos = Vector3.zero;
    public State_Walk(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
    }
    
    public override void OnStateEnter()
    {
        Vector3 pos1, pos2;
        pos1 = GameManager.Instance.pos1.position;
        pos2 = GameManager.Instance.pos2.position;

        if ((enemy.transform.position - pos1).sqrMagnitude < (enemy.transform.position - pos2).sqrMagnitude)
            goalPos = pos2;
        else
            goalPos = pos1;

        enemy.Move(goalPos);
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateStay()
    {
        if (enemy.CheckSight())
        {
            StateDel(AllEnum.StateEnum.Chase);
            return;
        }

        if ((enemy.transform.position - goalPos).sqrMagnitude <= 0.5f)
        {
            StateDel(AllEnum.StateEnum.Idle);
            return;
        }
        enemy.SetMoveAnim();
    }
}
