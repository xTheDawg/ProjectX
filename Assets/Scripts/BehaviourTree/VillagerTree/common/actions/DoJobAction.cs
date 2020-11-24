using UnityEngine;

public class DoJobAction : ActionNode
{
    private bool hasTarget = false;
    private Vector3 target;
    private MovementController movementController = new MovementController();
    public override NodeState Execute()
    {
        if (!hasTarget) {
            target = movementController.FindClosestTree(GetPeasant());
            hasTarget = true;
        }

        // Check if peasant is at target location
        bool arrivedAtTarget = Vector3.Distance(GetPeasant().transform.position, target) < 2;

        // Set animations accordingly
        GetPeasant().GetAnimator().SetBool("isWalking", !arrivedAtTarget);
        GetPeasant().GetAnimator().SetBool("isResting", arrivedAtTarget);

        if (!arrivedAtTarget) {
            // Keep moving
            movementController.Move(GetPeasant(), target);
            return NodeState.RUNNING;
        } else {
            // Return success if arrived at target
            return NodeState.SUCCESS;
        }  
    }
}
