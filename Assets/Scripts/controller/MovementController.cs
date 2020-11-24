using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    private float distanceToClosestResource = Mathf.Infinity;
    private TreeController[] allTreeResources = GameObject.FindObjectsOfType<TreeController>();

    // private StoneController[] allStoneResources = GameObject.FindObjectsOfType<StoneController>();

    // private FoodController[] allFoodResources = GameObject.FindObjectsOfType<FoodController>();

    private MonoBehaviour[] allResourcesOfType;

    private Vector3 targetPosition;
    
    // Find the closest resource of a specific type that is closest to the peasant.
    public Vector3 FindClosestResource(Peasant peasant, ResourceType resourceType)
    {
        MonoBehaviour closestResource = null;

        switch(resourceType) {
            case ResourceType.WOOD:
                allResourcesOfType = allTreeResources;
                break;
            /*
            case ResourceType.STONE:
                allResourcesOfType = allStoneResources;
                break;
            case ResourceType.FOOD:
                allResourcesOfType = allFoodResources;
                break;*/
            default:
                break;
        }

        foreach (MonoBehaviour resource in allResourcesOfType)
        {
            float distanceToResource = Vector3.Distance(resource.transform.position, peasant.transform.position);
            
            if (distanceToResource < distanceToClosestResource)
            {
                distanceToClosestResource = distanceToResource;
                closestResource = resource;
            }
        }

        // Return position of closest resource
        return closestResource.transform.position;
    }
    
    // Moves the tiven peasant towards the target location.
    public void Move(Peasant peasant, Vector3 target)
    {
        // Calculate looking direction of peasant
        peasant.SetRotation(new Vector3(target.x - peasant.transform.position.x, 
            peasant.transform.position.y, target.z - peasant.transform.position.z));

        // Set rotation to make sure peasant looks at target.
        peasant.transform.rotation = Quaternion.Slerp(peasant.transform.rotation,
            peasant.rotation,
            peasant.rotSpeed * Time.deltaTime);

        // Move towards target
        peasant.transform.position = Vector3.MoveTowards(peasant.transform.position,
            target,
            peasant.walkSpeed * Time.deltaTime);
    }
}
