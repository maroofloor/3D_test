using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{
    Enemy owner;
    public Chase(Enemy _owner)
    {
        owner = _owner;
    }
    public override NodeState Evaluate()
    {
        owner.Move(owner.target.transform.position);
        return NodeState.Success;
    }
}
