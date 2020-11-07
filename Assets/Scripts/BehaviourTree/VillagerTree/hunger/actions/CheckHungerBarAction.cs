using UnityEngine;

public class CheckHungerBarAction : ActionNode
{

    public override NodeState Execute()
    {
        Debug.Log("Executing Node: CheckHungerBarAction");
        return NodeState.SUCCESS;
    }
}
