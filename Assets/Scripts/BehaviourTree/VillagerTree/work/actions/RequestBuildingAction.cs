﻿using UnityEngine;

public class RequestBuildingAction : ActionNode
{
    JobService jobService = JobService.GetInstance();

    public override NodeState Execute()
    {
        // Returns success, if at least one job is available.
        jobService.AddJob(new BuildJob(Globals.priorityBuildHouse, BuildingType.HOUSE, Globals.energyRequiredBuildHouse, Globals.foodRequiredBuildHouse));
        return NodeState.SUCCESS;
    }
}
