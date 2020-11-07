using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResourceStockAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: CheckResourceStockAction");
        return NodeState.SUCCESS;
    }
}
