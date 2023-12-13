using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFar : Node
{
    Enemy owner;
    float time = 0;
    public AttackFar(Enemy _owner)
    {
        owner = _owner;
    }
    public override NodeState Evaluate()
    {
        if (time >= 3f)
        {
            time = 0f;
            owner.Idle();
            owner.SetDrawWeapon(true, true);
            owner.Shoot();

            return NodeState.Running;
        }

        time += Time.deltaTime;
        return NodeState.Success;
    }
}
