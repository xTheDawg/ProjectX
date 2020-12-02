using UnityEngine;

public class DoJobAction : ActionNode
{
    private bool doAction = false;
    private ResourceHelper resourceHelper = new ResourceHelper();

    public override NodeState Execute()
    {
        if (!doAction)
        {
            Debug.Log("Do job, aquiring location...");
            GetPeasant().target = resourceHelper.FindClosestResource(GetPeasant().position, ResourceType.WOOD);
            if (!GetPeasant().CheckPosition())
            {
                GetPeasant().hasTarget = true;
            }
            doAction = true;
            return NodeState.RUNNING;
        }
        
        //Check if Player arrived at destination
        if (GetPeasant().CheckPosition())
        {
            doAction = false;
            return NodeState.SUCCESS;
        }
        
        return NodeState.FAILURE;
    }
}