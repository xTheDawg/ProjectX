using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: RestAction");
        return NodeState.SUCCESS;
    }
}
