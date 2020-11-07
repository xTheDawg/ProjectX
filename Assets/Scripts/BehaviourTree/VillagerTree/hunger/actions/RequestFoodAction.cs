using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestFoodAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: RequestFoodAction");
        return NodeState.SUCCESS;
    }
}
