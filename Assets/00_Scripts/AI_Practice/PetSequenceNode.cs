using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSequenceNode : PetNode
{
    public PetSequenceNode()
    {
    }
    public PetSequenceNode(List<PetNode> children) : base(children)
    {
    }

    public override PetNodeState Evaluate()
    {
        bool isRunning = false;
        foreach (PetNode node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case PetNodeState.Running:
                    isRunning = true;
                    return PetNodeState.Running;

                case PetNodeState.Success:
                    continue;

                case PetNodeState.Failure:
                    return PetNodeState.Failure;

                default:
                    break;
            }
        }

        return state = isRunning ? PetNodeState.Running : PetNodeState.Success;
    }
}
