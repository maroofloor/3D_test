using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    Node rootNode;

    void Start()
    {

        //rootNode = new SelectorNode
        //    (
        //    new List<Node>
        //    {
        //        new SequenceNode
        //            (
        //                new List<Node>
        //                {
        //                    new node�� ��ӹ��� �Ÿ�üũ�� ��ũ��Ʈ,
        //                    new node�� ��ӹ��� chase��ũ��Ʈ,
        //                    new node�� ��ӹ��� attack��ũ��Ʈ
        //                }
        //            ),
        //        new node�� ��ӹ��� patrol��ũ��Ʈ
        //    }
        //    );
    }

    void Update()
    {
        if (rootNode == null)
        {
            return;
        }

        rootNode.Evaluate();
    }
}
