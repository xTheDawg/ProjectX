using UnityEngine;

public class RequestFoodAction : ActionNode
{
    private JobService jobService = JobService.GetInstance();

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: RequestFoodAction");
        jobService.AddJob(new BuildJob(Globals.priorityBuildFarm, BuildingType.FARM, Globals.energyRequiredBuildFarm, Globals.foodRequiredBuildFarm));
        return NodeState.SUCCESS;
    }
}
