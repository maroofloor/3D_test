using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack_Near : State
{
    public State_Attack_Near(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
        
    }

    public override void OnStateEnter()
    {
        enemy.SetDrawWeapon(false, true);
    }

    public override void OnStateExit()
    {
        enemy.SetDrawWeapon(false, false);
    }

    public override void OnStateStay()
    {

    }
}
