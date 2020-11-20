using UnityEngine;

public class CheckJobListAction : ActionNode
{

    public override NodeState Execute()
    {
        //Debug.Log("Executing Node: CheckJobListAction");
        return NodeState.SUCCESS;
    }
}
