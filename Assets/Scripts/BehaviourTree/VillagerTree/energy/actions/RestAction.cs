using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAction : ActionNode
{

    public override NodeStates execute()
    {
        Debug.Log("Executing Node: RestAction");
        return NodeStates.SUCCESS;
    }
}
