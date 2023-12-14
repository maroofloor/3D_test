using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCheckDistance : PetNode
{
    Transform Pet;
    Transform Player;

    float dist = 0;

    bool isFollow = false;

    public PetCheckDistance(Transform pet, Transform player)
    {
        Player = player;
        Pet = pet;
    }

    public override PetNodeState Evaluate()
    {
        dist = (Player.position - Pet.position).sqrMagnitude;

        if (dist >= 25f)
        {
            isFollow = true;
            return PetNodeState.Success;
        }
        else if (dist <= 4)
        {
            isFollow = false;
            return PetNodeState.Failure;
        }
        else if (isFollow)
        {
            return PetNodeState.Success;
        }
        else
        {
            if (state != PetNodeState.Failure)
            {
                return PetNodeState.Running;
            }
            else
                return PetNodeState.Failure;
        }
    }
}
