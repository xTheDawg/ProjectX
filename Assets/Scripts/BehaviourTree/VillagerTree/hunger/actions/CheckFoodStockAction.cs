using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFoodStockAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: CheckFoodStockAction");
        return NodeState.SUCCESS;
    }
}
