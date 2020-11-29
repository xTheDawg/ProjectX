﻿using UnityEngine;

public class DoJobAction : ActionNode
{
    private bool hasTarget = false;
    private Vector3 target;
    private ResourceHelper resourceHelper = new ResourceHelper();

    public override NodeState Execute()
    {
        if (!hasTarget)
        {
            Debug.Log("Do job, aquiring location...");
            target = resourceHelper.FindClosestResource(GetPeasant(), ResourceType.WOOD);
            hasTarget = true;
        }

        // Set animations accordingly
        GetPeasant().animator.SetBool("isWalking", !GetPeasant().collidedWithTree);
        
        //Move Character unless he's at the Target.
        if (GetPeasant().GoToLocation(target))
        {
            GetPeasant().collidedWithTree = false;
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.RUNNING;
        }

        
    }
}