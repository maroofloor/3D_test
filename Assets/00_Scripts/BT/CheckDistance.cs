using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : Node
{
    Enemy owner;
    float dist = 0f;

    public CheckDistance(Enemy _owner)
    {
        owner = _owner;
        childrenNode.Add(new AttackNear(owner));
        childrenNode.Add(new AttackFar(owner));
        childrenNode.Add(new Chase(owner));
    }
    public override NodeState Evaluate()
    {
        if (owner.target == null)
            return NodeState.Failure;

        dist = Vector3.Distance(owner.target.transform.position, owner.transform.position);
        if (dist <= 1)
        {
            childrenNode[0].Evaluate(); // 근접
        }
        else if(dist <= 5)
        {
            childrenNode[1].Evaluate(); // 원거리
        }
        else
        {
            childrenNode[2].Evaluate(); // 추격
        }

        return NodeState.Success;
    }
}
