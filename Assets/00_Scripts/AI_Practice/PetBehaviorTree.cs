using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviorTree : MonoBehaviour
{
    PetNode rootNode;

    public Player_AIPractice player;

    private void Start()
    {
        rootNode = new PetSelectorNode
            (
                new List<PetNode>()
                {
                    new PetSequenceNode
                    (
                        new List<PetNode>()
                        {
                            new PetCheckDistance(transform, player.transform),
                            new PetMove(transform, player.transform)
                        }
                    ),
                    new PetWait()
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
