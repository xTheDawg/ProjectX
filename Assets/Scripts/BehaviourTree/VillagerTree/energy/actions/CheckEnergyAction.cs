using UnityEngine;

public class CheckEnergyAction : ActionNode
{
    public override NodeState Execute()
    {       
        Debug.LogError("CheckEnergyAction()");
        // Return success if peasant energyLevel is above critical level.
        return GetPeasant().energyLevel >= Globals.energyCritical ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
