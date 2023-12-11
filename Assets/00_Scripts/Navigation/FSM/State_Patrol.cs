using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Patrol : State
{
    //State state_idle;
    //State state_walk;
    Dictionary<AllEnum.StateEnum, State> StateDic = new Dictionary<AllEnum.StateEnum, State>();
    AllEnum.StateEnum patrolState;

    public State_Patrol(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
        //this.enemy = enemy;
        //this.StateDel = stateDel;
        StateDic.Add(AllEnum.StateEnum.Idle, new State_Idle(enemy, stateDel));
        StateDic.Add(AllEnum.StateEnum.Walk, new State_Walk(enemy, stateDel));
    }
    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateStay()
    {
    }
}
