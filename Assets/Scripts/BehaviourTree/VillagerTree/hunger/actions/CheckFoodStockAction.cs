using UnityEngine;

public class CheckFoodStockAction : ActionNode
{
    private bool doAction = false;

    private StorageService storageService = StorageService.GetInstance();

    public override NodeState Execute()
    {
        if (!doAction)
        {
            Debug.Log("CheckFoodStockAction...");
            GetPeasant().target = Globals.storageLocation;
            GetPeasant().hasTarget = true;
            doAction = true;
            return NodeState.RUNNING;
        }

        if (GetPeasant().CheckPosition())
        {
            doAction = false;
            // If there is enough food in storage, take it and fill food level.
            return storageService.resources[ResourceType.FOOD] >= (Globals.foodMax - GetPeasant().foodLevel) ? NodeState.SUCCESS : NodeState.FAILURE;
        }

        return NodeState.FAILURE;
    }
}