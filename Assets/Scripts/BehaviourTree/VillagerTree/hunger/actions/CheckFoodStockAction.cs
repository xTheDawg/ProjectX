using UnityEngine;

public class CheckFoodStockAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: CheckFoodStockAction");
        return NodeState.SUCCESS;
    }
}
