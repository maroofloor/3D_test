using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetWait : PetNode
{
    public PetWait()
    {
    }

    public override PetNodeState Evaluate()
    {
        return PetNodeState.Success;
    }
}
