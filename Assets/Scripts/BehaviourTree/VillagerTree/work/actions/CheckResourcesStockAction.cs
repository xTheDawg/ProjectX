using UnityEngine;

public class CheckResourcesStockAction : ActionNode
{

    StorageService storageService = StorageService.GetInstance();
    JobService jobService = JobService.GetInstance();

    private bool doAction = false;
    
    public override NodeState Execute()
    {
        
        
        if (!doAction)
        {
            GetPeasant().target = Globals.storageLocation;
            doAction = true;
            return NodeState.RUNNING;
        }

        if (GetPeasant().CheckPosition(Globals.storageLocation))
        {
            doAction = false;
            bool anyResourceNeeded = false;
            if (storageService.resources[ResourceType.WOOD] < 500)
            {
                //Debug.LogError("Adding Gather WOOD Job.");
                jobService.AddJob(new GatherJob(Globals.priorityGatherWood, ResourceType.WOOD, Globals.energyRequiredGatherWood, Globals.foodRequiredGatherWood));
                anyResourceNeeded = true;
            }
        
            if (storageService.resources[ResourceType.STONE] < 250)
            {
                //Debug.LogError("Adding Gather STONE Job.");
                jobService.AddJob(new GatherJob(Globals.priorityGatherStone, ResourceType.STONE, Globals.energyRequiredGatherStone, Globals.foodRequiredGatherStone));
                anyResourceNeeded = true;
            }
            
            if (storageService.resources[ResourceType.FOOD] < 100)
            {
                Debug.LogError("Adding Gather FOOD Job.");
                jobService.AddJob(new GatherJob(Globals.priorityGatherFood, ResourceType.FOOD, Globals.energyRequiredGatherFood, Globals.foodRequiredGatherFood));
                anyResourceNeeded = true;
            }
            return anyResourceNeeded ? NodeState.SUCCESS : NodeState.FAILURE;
        }

        return NodeState.FAILURE;
    }
}
