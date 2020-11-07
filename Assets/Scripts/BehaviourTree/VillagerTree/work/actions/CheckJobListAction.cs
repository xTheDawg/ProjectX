using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJobListAction : ActionNode
{

    public override NodeState execute()
    {
        Debug.Log("Executing Node: CheckJobListAction");
        return NodeState.SUCCESS;
    }
}
