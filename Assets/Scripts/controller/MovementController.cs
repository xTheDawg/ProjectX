using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private float distanceToClosestTarget = Mathf.Infinity;
    private TreeController[] allTrees = GameObject.FindObjectsOfType<TreeController>();
    private Vector3 targetPosition;
    
    // Find the tree that is closest to the peasant.
    public Vector3 FindClosestTree(Peasant peasant)
    {
        TreeController closestTree = null;
        foreach (TreeController currentTree in allTrees)
        {
            float distanceToTree = Vector3.Distance(currentTree.transform.position, peasant.transform.position);
            
            if (distanceToTree < distanceToClosestTarget)
            {
                distanceToClosestTarget = distanceToTree;
                closestTree = currentTree;
            }
        }

        // Return position of closest tree
        return closestTree.transform.position;
    }
    
    // Moves the tiven peasant towards the target location.
    public void Move(Peasant peasant, Vector3 target)
    {
        // Calculate looking direction of peasant
        peasant.SetRotation(new Vector3(target.x - peasant.transform.position.x, 
            peasant.transform.position.y, target.z - peasant.transform.position.z));

        // Set rotation to make sure peasant looks at target.
        peasant.transform.rotation = Quaternion.Slerp(peasant.transform.rotation,
            peasant.GetRotation(),
            peasant.GetRotSpeed() * Time.deltaTime);

        // Move towards target
        peasant.transform.position = Vector3.MoveTowards(peasant.transform.position,
            target,
            peasant.GetWalkSpeed() * Time.deltaTime);
    }
}
