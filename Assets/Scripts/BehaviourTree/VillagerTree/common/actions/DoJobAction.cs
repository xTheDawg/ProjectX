using UnityEngine;

public class DoJobAction : ActionNode
{
    private bool hasTarget = false;
    private Vector3 target;
    private MovementController movementController = new MovementController();
    public override NodeState Execute()
    {
        /*if (!hasTarget)
        {
            target = movementController.FindClosestTarget(GetPeasant());
            hasTarget = true;
            GetPeasant().GetAnimator().SetBool("isWalking", true);
            GetPeasant().GetAnimator().SetBool("isResting", false);
        }

        if (GetPeasant().transform.position != target)
        {
            movementController.Move(GetPeasant(), target);
            hasTarget = false;
            return NodeState.RUNNING;
        }*/
        //Debug.Log("Executing Node: DoJobAction");
        return NodeState.SUCCESS;
    }
}
