using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public SequenceNode()
    {
    }

    public SequenceNode(List<Node> children) : base(children)
    {
    }

    public override NodeState Evaluate()
    {
        bool isRunning = false;
        foreach (Node node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case NodeState.Running:
                    isRunning = true;
                    return NodeState.Running;

                case NodeState.Success:
                    continue;

                case NodeState.Failure:
                    return NodeState.Failure;
                default:
                    break;
            }
        }

        return state = isRunning ? NodeState.Running : NodeState.Success;
    }
}
