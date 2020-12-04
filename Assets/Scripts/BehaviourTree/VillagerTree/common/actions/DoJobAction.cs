using UnityEngine;

public class DoJobAction : ActionNode
{
    private ResourceHelper resourceHelper = new ResourceHelper();
    private JobService jobService = JobService.GetInstance();

    public override NodeState Execute()
    {
        if (GetPeasant().currentJob == null)
        {
            Debug.Log("DoJobAction(), no current job");
            GetPeasant().currentJob = jobService.GetJob(GetPeasant());
            return NodeState.RUNNING;
        }
        GetPeasant().currentJob.jobDone = false;
        GetPeasant().currentJob = null;
        Debug.Log("DoJobAction() SUCCESS");
        return NodeState.SUCCESS;
    }
}