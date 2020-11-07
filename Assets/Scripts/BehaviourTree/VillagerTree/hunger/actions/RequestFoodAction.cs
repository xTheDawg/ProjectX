using UnityEngine;

public class RequestFoodAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: RequestFoodAction");
        return NodeState.SUCCESS;
    }
}
