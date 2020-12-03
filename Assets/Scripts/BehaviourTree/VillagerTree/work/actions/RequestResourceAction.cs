using UnityEngine;

public class RequestResourceAction : ActionNode
{

    StorageService storageService = StorageService.GetInstance();
    public override NodeState Execute()
    {
        if (storageService.resources[ResourceType.WOOD] < 1000)
        {
            //Request Wood Gathering Job
            return NodeState.SUCCESS;
        }
        
        if (storageService.resources[ResourceType.STONE] < 500)
        {
            //Request Wood Gathering Job
            return NodeState.SUCCESS;
        }
        //Debug.Log("Executing Node: RequestResourceAction");
        return NodeState.FAILURE;
    }
}
