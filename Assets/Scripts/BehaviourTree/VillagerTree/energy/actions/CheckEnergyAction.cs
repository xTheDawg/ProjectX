using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnergyAction : ActionNode
{
    public override NodeStates execute()
    {
        Debug.Log("Executing Node: CheckEnergyAction");
        return NodeStates.SUCCESS;
    }
}
