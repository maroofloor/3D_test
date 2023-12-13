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
                    ( //�þ�üũ
                        new List<Node>
                        {
                            //�þ�üũ ���
                            new CheckSight(owner),

                            //new SequenceNode
                            //    ( //�Ÿ�üũ
                                //new List<Node>
                                //{
                                    //�Ÿ�üũ ���
                                    new CheckDistance(owner),

                                    //������ ����
                                    //new AttackNear(),
                                    ////�߰��̸� ���Ÿ�
                                    //new AttackFar(),
                                    ////�ָ� �߰�
                                    //new Chase()
                                //} //�Ÿ�üũ ��
                            //)
                        } // �þ�üũ ��
                    ),
                new Patrol(owner)
                //new SequenceNode
                //    (//��Ÿ��üũ
                //        new List<Node>
                //        {
                //            //��Ÿ��üũ ���

                //            //������ �ֱ�
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
