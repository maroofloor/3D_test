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
        //                    new node를 상속받은 거리체크용 스크립트,
        //                    new node를 상속받은 chase스크립트,
        //                    new node를 상속받은 attack스크립트
        //                }
        //            ),
        //        new node를 상속받은 patrol스크립트
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
