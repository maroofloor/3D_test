using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : PetNode
{
    Transform Pet;
    Transform Player;
    Vector3 Dir = Vector3.zero;

    public PetMove(Transform pet, Transform player)
    {
        Player = player;
        Pet = pet;
    }

    public override PetNodeState Evaluate()
    {
        Dir = Player.position - Pet.position;
        Pet.Translate(Dir.normalized * Time.deltaTime * 5f);
        return PetNodeState.Success;
    }
}
