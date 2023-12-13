using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack_Far : State
{
    float ShootCool = 0f;
    int ShootCount = 0;
    public State_Attack_Far(Enemy enemy, SetStateDel stateDel) : base(enemy, stateDel)
    {
    }
    public override void OnStateEnter()
    {
        enemy.SetDrawWeapon(true, true);
    }

    public override void OnStateExit()
    {
        enemy.SetDrawWeapon(true, false);
    }

    public override void OnStateStay()
    {
        //if (ShootCount >= 12) // ÀçÀåÀü
        //{
        //    enemy.
        //}

        ShootCool += Time.deltaTime;
        enemy.transform.LookAt(enemy.target.transform);
        if (ShootCool >= 3f)
        {
            enemy.Shoot();
            ShootCool = 0f;
            ShootCount++;
        }
    }
}
