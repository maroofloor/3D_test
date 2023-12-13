using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSelectorNode : PetNode
{
    public PetSelectorNode()
    {
    }
    public PetSelectorNode(List<PetNode> children) : base(children)
    {
    }

    public override PetNodeState Evaluate()
    {
        foreach (PetNode node in childrenNode)
        {
            switch (node.Evaluate())
            {
                case PetNodeState.Running:
                    return state = PetNodeState.Running;

                case PetNodeState.Success:
                    return state = PetNodeState.Success;

                case PetNodeState.Failure:
                    continue;

                default:
                    break;
            }
        }
        return state = PetNodeState.Failure;
    }
}
