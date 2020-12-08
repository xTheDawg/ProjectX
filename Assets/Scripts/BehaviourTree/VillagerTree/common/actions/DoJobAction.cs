using UnityEngine;

public class DoJobAction : ActionNode
{
    private JobService jobService = JobService.GetInstance();

    public override NodeState Execute()
    {
        if (GetPeasant().currentJob == null)
        {
            GetPeasant().currentJob = jobService.GetJob(GetPeasant());
            return NodeState.RUNNING;
        }
        GetPeasant().currentJob.jobDone = false;
        GetPeasant().currentJob = null;
        return NodeState.SUCCESS;
    }
}