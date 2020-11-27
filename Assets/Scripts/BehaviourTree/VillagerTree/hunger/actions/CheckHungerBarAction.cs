using UnityEngine;

public class CheckHungerBarAction : ActionNode
{

    public override NodeState Execute()
    {
        //Debug.Log("Executing Node: CheckHungerBarAction");
        return NodeState.FAILURE;
        return GetPeasant().foodLevel >= Globals.foodCritical ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
