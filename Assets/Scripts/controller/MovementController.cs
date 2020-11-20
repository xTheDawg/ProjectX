using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float distancetoClosestTarget = Mathf.Infinity;
    private TreeController closestTree = null;
    private TreeController[] allTrees = GameObject.FindObjectsOfType<TreeController>();
    private Vector3 lookAtTarget;
    
    private void FindClosestTarget(Peasant peasant)
    {
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
    }
    
    /*public void Move(Peasant peasant, TreeController targetTree)
    {
        peasant.transform.rotation = Quaternion.Slerp(transform.rotation,
            peasant.GetRotation(),
            peasant.GetRotSpeed() * Time.deltaTime);
        peasant.transform.position = Vector3.MoveTowards(transform.position,
            targe,
            walkSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            moving = false;
            animator.SetBool("isWalking", false);
        }
    }*/
}
