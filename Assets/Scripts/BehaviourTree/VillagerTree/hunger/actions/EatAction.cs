using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: EatAction");
        return NodeState.SUCCESS;
    }
}
