using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnergyAction : ActionNode
{
    public override NodeState execute()
    {
        Debug.Log("Executing Node: CheckEnergyAction");
        return NodeState.FAILURE;
    }
}
