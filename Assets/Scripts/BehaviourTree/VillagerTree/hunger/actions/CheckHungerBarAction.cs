using UnityEngine;

public class CheckHungerBarAction : ActionNode
{

    public override NodeState Execute()
    {
        //Debug.Log("Executing Node: CheckHungerBarAction");
        return GetPeasant().foodLevel >= 20 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
