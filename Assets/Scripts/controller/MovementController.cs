using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private float distancetoClosestTarget = Mathf.Infinity;
    private TreeController[] allTrees = GameObject.FindObjectsOfType<TreeController>();
    private Vector3 lookAtTarget;
    private Vector3 targetPosition;
    
    public Vector3 FindClosestTarget(Peasant peasant)
    {
        TreeController closestTree = null;
        foreach (TreeController currentTree in allTrees)
        {
            float distanceToTree = (currentTree.transform.position - peasant.transform.position).sqrMagnitude;
            if (distanceToTree < distancetoClosestTarget)
            {
                distancetoClosestTarget = distanceToTree;
                closestTree = currentTree;
            }
        }
        lookAtTarget = new Vector3(closestTree.transform.position.x - peasant.transform.position.x, 
            peasant.transform.position.y, closestTree.transform.position.z - peasant.transform.position.z);
        peasant.SetRotation(lookAtTarget);
        targetPosition = new Vector3(closestTree.transform.position.x - 2, 0, closestTree.transform.position.z - 2);

        return targetPosition;
    }
    
    public void Move(Peasant peasant, Vector3 target)
    {
        peasant.transform.rotation = Quaternion.Slerp(peasant.transform.rotation,
            peasant.GetRotation(),
            peasant.GetRotSpeed() * Time.deltaTime);
        peasant.transform.position = Vector3.MoveTowards(peasant.transform.position,
            target,
            peasant.GetWalkSpeed() * Time.deltaTime);
    }
}
