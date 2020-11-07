using UnityEngine;

public class RestAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: RestAction");
        return NodeState.SUCCESS;
    }
}
