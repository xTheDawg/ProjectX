using UnityEngine;

public class RequestBuildingAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: RequestBuildingAction");
        return NodeState.SUCCESS;
    }
}
