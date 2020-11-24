using UnityEngine;

public class DoJobAction : ActionNode
{
    private bool hasTarget = false;
    private Vector3 target;
    private MovementController movementController = new MovementController();
    public override NodeState Execute()
    {
        // TODO: I think this should be moved to a method in movement controller.

        if (!hasTarget) {
            target = movementController.FindClosestResource(GetPeasant(), ResourceType.WOOD);
            hasTarget = true;
        }

        // Check if peasant is at target location
        bool arrivedAtTarget = Vector3.Distance(GetPeasant().transform.position, target) < 2;

        // Set animations accordingly
        GetPeasant().animator.SetBool("isWalking", !arrivedAtTarget);
        // GetPeasant().animator.SetBool("isResting", arrivedAtTarget);

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
