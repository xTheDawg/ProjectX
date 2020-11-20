using UnityEngine;

public class RequestResourceAction : ActionNode
{

    public override NodeState Execute()
    {
        //Debug.Log("Executing Node: RequestResourceAction");
        return NodeState.SUCCESS;
    }
}
