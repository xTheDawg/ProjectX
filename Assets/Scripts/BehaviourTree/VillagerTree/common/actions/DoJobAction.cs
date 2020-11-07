using UnityEngine;

public class DoJobAction : ActionNode
{
    public override NodeState Execute()
    {
        Debug.Log("Executing Node: DoJobAction");
        return NodeState.SUCCESS;
    }
}
