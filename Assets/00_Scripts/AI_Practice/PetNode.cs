using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PetNodeState
{
    Running,
    Success,
    Failure
}

public abstract class PetNode
{
    protected PetNodeState state;
    public PetNode ParentNode;

    protected List<PetNode> childrenNode = new List<PetNode>();

    public PetNode()
    {
        ParentNode = null;
    }
    public PetNode(List<PetNode> children)
    {
        foreach (var item in children)
        {
            AttachChild(item);
        }
    }
    public void AttachChild(PetNode child)
    {
        childrenNode.Add(child);
        child.ParentNode = this;
    }

    public abstract PetNodeState Evaluate();
}
