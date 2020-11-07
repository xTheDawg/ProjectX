using UnityEngine;

public class CheckEnergyAction : ActionNode
{
    public override NodeState Execute()
    {
        Debug.Log("Executing Node: CheckEnergyAction");
        return NodeState.SUCCESS;
    }
}
