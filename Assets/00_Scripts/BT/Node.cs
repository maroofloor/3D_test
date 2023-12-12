using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Running, //������
    Success, //����
    Failure //����
}
public abstract class Node
{
    protected NodeState state;
    public Node ParentNode;

    protected List<Node> childrenNode = new List<Node>();

    public Node()
    {
        ParentNode = null;
    }
    
    public Node(List<Node> children)
    {
        foreach (var item in children)
        {
            AttachChild(item);
        }
    }
    public void AttachChild(Node child)
    {
        childrenNode.Add(child);
        child.ParentNode = this;
    }
    public abstract NodeState Evaluate();
}
