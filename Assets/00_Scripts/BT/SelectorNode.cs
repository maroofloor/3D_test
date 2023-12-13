using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : Node
{
    public SelectorNode()
    {
    }

    public SelectorNode(List<Node> children) : base(children)
    {
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    return state = NodeState.Running;

                case NodeState.Success:
                    return state = NodeState.Success;

                case NodeState.Failure:
                    continue;

                default:
                    break;
            }
        }
        return state = NodeState.Failure;
    }

}
