using UnityEngine;

public class EatAction : ActionNode
{
    private bool isEating = false;
    private float eatStartTime;

    public override NodeState Execute()
    {
        if (!isEating)
        {
            isEating = true;
            eatStartTime = Time.time;
            
        }
        Debug.Log("Executing Node: EatAction");
        return NodeState.SUCCESS;
    }
}
