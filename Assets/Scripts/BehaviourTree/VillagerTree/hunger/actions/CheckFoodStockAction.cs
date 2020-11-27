using UnityEngine;

public class CheckFoodStockAction : ActionNode
{
    private bool hasTarget = false;

    private StorageService storageService = StorageService.GetInstance();

    public override NodeState Execute()
    {
        if (!hasTarget)
        {
            Debug.Log("check food stock, aquiring target...");
            GetPeasant().GoToLocation(Globals.storageLocation);
            hasTarget = true;
        }

        // Set animations accordingly
        GetPeasant().animator.SetBool("isWalking", !GetPeasant().collidedWithStorage);

        if (!GetPeasant().collidedWithStorage)
        {
            // Keep moving
            Debug.Log("keep moving");
            GetPeasant().GoToLocation(Globals.storageLocation);
            return NodeState.RUNNING;
        }

        // If there is enough food in storage, take it and fill food level.
        return storageService.resources[ResourceType.FOOD] >= Globals.eatAmount ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}