using UnityEngine;

public class CheckFoodStockAction : ActionNode
{
    private bool hasTarget = false;

    private StorageService storageService = StorageService.GetInstance();

    public override NodeState Execute()
    {
        if (!hasTarget) {
            Debug.Log("check food stock, aquiring target...");
            GetPeasant().GoToLocation(Globals.storageLocation);
            hasTarget = true;
        }

        bool arrivedAtTarget = Vector3.Distance(GetPeasant().transform.position, Globals.storageLocation) < Globals.radiusStorage;

        // Set animations accordingly
        GetPeasant().animator.SetBool("isWalking", !arrivedAtTarget);

        if (!arrivedAtTarget) {
            // Keep moving
            GetPeasant().GoToLocation(Globals.storageLocation);
            return NodeState.RUNNING;
        } else {            
            // If there is enough food in storage, take it and fill food level.
            if (storageService.resources[ResourceType.FOOD] >= Globals.eatAmount) {
                GetPeasant().foodLevel += storageService.TakeResource(ResourceType.FOOD, Globals.eatAmount);
                return NodeState.SUCCESS;
            }
            // Return failure when there is not enough food in storage
            return NodeState.FAILURE;
        }
    }
}
