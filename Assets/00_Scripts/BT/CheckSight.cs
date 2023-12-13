using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSight : Node
{
    Enemy owner;
    List<Collider> targetList = new List<Collider>();
    Vector3 targetDir = Vector3.zero;
    float targetAngle = 0;

    public CheckSight(Enemy _owner)
    {
        owner = _owner;
    }
    public override NodeState Evaluate()
    {
        targetList.Clear();
        Collider[] cols = Physics.OverlapSphere(owner.transform.position, owner.viewdistance, owner.targetmask);
        if (cols.Length > 0)
        {
            targetDir = (cols[0].transform.position - owner.transform.position).normalized;
            targetAngle = Mathf.Acos(Vector3.Dot(owner.transform.forward, targetDir)) * Mathf.Rad2Deg;
            if (targetAngle <= owner.viewAngle * 0.5f)
            {
                owner.target = cols[0];
                return NodeState.Success;
            }
        }
        return NodeState.Failure;
    }
}
