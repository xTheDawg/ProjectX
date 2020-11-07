using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestResourceAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: RequestResourceAction");
        return NodeState.SUCCESS;
    }
}
