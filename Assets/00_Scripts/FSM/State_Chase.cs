using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Chase : State
{
    Transform targetTr => enemy.target.transform;
    Vector3 targetPos = Vector3.zero;
    public State_Chase(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
    }

    public override void OnStateEnter()
    {
        targetPos = targetTr.position;
        enemy.Move(targetPos);
    }

    public override void OnStateExit()
    {
        enemy.Idle();
    }

    public override void OnStateStay()
    {
        if ((enemy.transform.position - targetTr.position).sqrMagnitude <= 25)
        {
            //АјАн
            StateDel(AllEnum.StateEnum.Attack);
            //StateDel(AllEnum.StateEnum.Idle);
            return;
        }

        enemy.Move(targetTr.position);
    }
}
