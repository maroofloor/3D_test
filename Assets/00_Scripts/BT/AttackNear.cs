using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNear : Node
{
    Enemy owner;
    float time = 0;
    public AttackNear(Enemy _owner)
    {
        owner = _owner;
    }
    public override NodeState Evaluate()
    {
        if (time >= 2f)
        {
            time = 0f;
            owner.Idle();
            owner.SetDrawWeapon(false ,true);
            Debug.Log("근접 공격!");

            return NodeState.Running;
        }

        time += Time.deltaTime;
        return NodeState.Success;
    }
}
