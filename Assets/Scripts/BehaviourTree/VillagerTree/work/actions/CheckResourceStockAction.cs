using UnityEngine;

public class CheckResourceStockAction : ActionNode
{

    public override NodeState Execute()
    {
        //Debug.Log("Executing Node: CheckResourceStockAction");
        return NodeState.SUCCESS;
    }
}
