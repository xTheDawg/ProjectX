using UnityEngine;

public class CheckEnergyAction : ActionNode
{
    public override NodeState Execute()
    {        
        Debug.Log("Executing Node: CheckEnergyAction");
        // Return success if peasant energyLevel is above 20.
        return GetPeasant().GetEnergyLevel() >= 20 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
