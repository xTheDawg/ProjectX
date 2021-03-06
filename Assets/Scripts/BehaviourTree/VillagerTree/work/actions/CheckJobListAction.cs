﻿using UnityEngine;

public class CheckJobListAction : ActionNode
{
    JobService jobService = JobService.GetInstance();

    public override NodeState Execute()
    {
        // Returns success, if at least one job is available.
        return jobService.jobList.Count > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
