using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHelper
{
    private float distanceToClosestResource = Mathf.Infinity;

    private ResourceController[] allResourcesOfType;

    private Vector3 targetPosition;
    
    // Find the closest resource of a specific type that is closest to the input position.
    public Vector3 FindClosestResource(Vector3 position, ResourceType resourceType)
    {
        MonoBehaviour closestResource = null;

        switch(resourceType) {
            case ResourceType.WOOD:
                allResourcesOfType = GameObject.FindObjectsOfType<TreeController>();
                break;
            
            case ResourceType.STONE:
                allResourcesOfType = GameObject.FindObjectsOfType<StoneController>();
                break;
            
            case ResourceType.FOOD:
                allResourcesOfType = GameObject.FindObjectsOfType<FoodController>();
                break;
        }
                

        foreach (ResourceController resource in allResourcesOfType)
        {
            float distanceToResource = Vector3.Distance(resource.transform.position, position);
            
            if (distanceToResource < distanceToClosestResource && distanceToResource != 0)
            {
                distanceToClosestResource = distanceToResource;
                closestResource = resource;
            }
        }

        // Return position of closest resource
        if (!(closestResource is null)) return closestResource.transform.position;
        return Vector3.zero;
    }
}
