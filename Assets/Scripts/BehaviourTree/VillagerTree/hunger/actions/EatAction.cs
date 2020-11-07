using UnityEngine;

public class EatAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: EatAction");
        return NodeState.SUCCESS;
    }
}
