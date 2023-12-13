using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour
{
    Node rootNode;
    Enemy owner;

    void Start()
    {
        owner = GetComponent<Enemy>();
        rootNode = new SelectorNode
            (
            new List<Node>
            {
                new SequenceNode
                    ( //시야체크
                        new List<Node>
                        {
                            //시야체크 노드
                            new CheckSight(owner),

                            //new SequenceNode
                            //    ( //거리체크
                                //new List<Node>
                                //{
                                    //거리체크 노드
                                    new CheckDistance(owner),

                                    //가까우면 근접
                                    //new AttackNear(),
                                    ////중간이면 원거리
                                    //new AttackFar(),
                                    ////멀면 추격
                                    //new Chase()
                                //} //거리체크 끝
                            //)
                        } // 시야체크 끝
                    ),
                new Patrol(owner)
                //new SequenceNode
                //    (//쿨타임체크
                //        new List<Node>
                //        {
                //            //쿨타임체크 노드

                //            //가만히 있기
                //        }
                //    )
            }
            );
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
