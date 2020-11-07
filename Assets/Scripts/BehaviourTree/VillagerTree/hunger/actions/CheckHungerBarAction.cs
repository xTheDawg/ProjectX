using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHungerBarAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: CheckHungerBarAction");
        return NodeState.SUCCESS;
    }
}
