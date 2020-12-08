using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceService
{
    private static ResourceService instance = null;
    private static readonly object padlock = new object();

    private ResourceController[] allResourcesOfType;
    private List<GameObject> activeObjects = new List<GameObject>();

    private Vector3 targetPosition;
    
    public static ResourceService GetInstance() {        
        lock (padlock) {
            if (instance == null)
            {
                instance = new ResourceService();
            }
            return instance;
        }
    }

    public GameObject FindClosestResourceOfType(Vector3 position, ResourceType resourceType)
    {
        GameObject closestObject = null;
        List<GameObject> sameTagList = new List<GameObject>();
        float distanceToClosestResource = Mathf.Infinity;
        
        String tagName = "";
        switch (resourceType)
        {
            case ResourceType.WOOD:
                tagName = "Tree";
                break;
            case ResourceType.STONE:
                tagName = "Stone";
                break;
            case ResourceType.FOOD:
                tagName = "Field";
                break;
        }
        //Get Objects with same Tag in a separate List
        for (int i = 0; i < activeObjects.Count; i++)
        {
            if (activeObjects[i].tag.Equals(tagName))
            {
                sameTagList.Add(activeObjects[i]);
            }
        }

        //If the generated list contained no elements then return null
        if (sameTagList.Count == 0)
        {
            Debug.LogError("No active Objects with Tag: " + tagName);
            return null;
        }

        for (int i = 0; i < sameTagList.Count; i++)
        {
            float distanceToResource = Vector3.Distance(position, sameTagList[i].transform.position);
            
            if (distanceToResource < distanceToClosestResource && distanceToResource != 0)
            {
                distanceToClosestResource = distanceToResource;
                closestObject = sameTagList[i];
            }
        }

        return closestObject;
    }
    
    //Add Object to List of active Objects
    public void AddActiveResource(GameObject resource)
    {
        if (activeObjects.Contains(resource))
        {
            Debug.LogError("GameObject was already in list of active objects!");
        }
        else
        {
            activeObjects.Add(resource);
        }
    }
    
    //Remove Object from List of active Objects
    public void RemoveActiveResource(GameObject resource)
    {
        if (activeObjects.Contains(resource))
        {
            activeObjects.Remove(resource);
        }
        else
        {
            Debug.LogError("GameObject was not in list of active objects!");
        }
    }
}
