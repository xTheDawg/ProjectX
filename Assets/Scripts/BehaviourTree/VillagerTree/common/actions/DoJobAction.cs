using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoJobAction : ActionNode
{
    public override NodeState execute()
    {
        Debug.Log("Executing Node: DoJobAction");
        return NodeState.SUCCESS;
    }
}
