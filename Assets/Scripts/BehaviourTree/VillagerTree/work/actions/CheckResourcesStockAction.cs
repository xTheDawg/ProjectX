using UnityEngine;

public class CheckResourcesStockAction : ActionNode
{

    StorageService storageService = StorageService.GetInstance();
    JobService jobService = JobService.GetInstance();
    
    public override NodeState Execute()
    {
        bool anyResourceNeeded = false;
        if (storageService.resources[ResourceType.WOOD] < 1000)
        {
            Debug.Log("Adding Gather WOOD Job.");
            jobService.AddJob(new GatherJob(1, ResourceType.WOOD, 10, 10));
            anyResourceNeeded = true;
        }
        
        if (storageService.resources[ResourceType.STONE] < 500)
        {
            Debug.Log("Adding Gather STONE Job.");
            jobService.AddJob(new GatherJob(2, ResourceType.STONE, 10, 10));
            anyResourceNeeded = true;
        }
        return anyResourceNeeded ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
