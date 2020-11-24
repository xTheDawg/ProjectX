using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHelper
{
    private float distanceToClosestResource = Mathf.Infinity;
    private TreeController[] allTreeResources = GameObject.FindObjectsOfType<TreeController>();

    // private StoneController[] allStoneResources = GameObject.FindObjectsOfType<StoneController>();

    // private FoodController[] allFoodResources = GameObject.FindObjectsOfType<FoodController>();

    private ResourceController[] allResourcesOfType;

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

        foreach (ResourceController resource in allResourcesOfType)
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
}
