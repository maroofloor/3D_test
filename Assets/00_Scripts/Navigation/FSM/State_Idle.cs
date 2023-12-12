using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    float currentTime = 0;
    float nextTime = 0;
    public State_Idle(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
    }
    public override void OnStateEnter()
    {
        currentTime = 0;
        nextTime = 3f;
        //enemy.MoveAnim(false);가만히 있는 애니메이션
        //+움직임 멈추기 => enemy의 이동멈추는 함수 콜
        enemy.Idle();
    }

    public override void OnStateExit()
    {
        currentTime = 0;
    }

    public override void OnStateStay()
    {
        if (enemy.CheckSight())
        {
            StateDel(AllEnum.StateEnum.Chase);
            return;
        }

        if (currentTime >= nextTime)
        {
            StateDel(AllEnum.StateEnum.Walk);
            return;
        }

        currentTime += Time.deltaTime;
    }
}
