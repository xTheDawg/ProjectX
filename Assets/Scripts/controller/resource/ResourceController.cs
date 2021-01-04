using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceController : MonoBehaviour
{
    private int resourceAmount;
    
    public ResourceService resourceService = ResourceService.GetInstance();

    private void Awake()
    {
        switch (gameObject.tag)
        {
            case "Tree":
                resourceAmount = Random.Range(100, 200);
                break;
            case "Stone":
                resourceAmount = Random.Range(50, 100);
                break;
            case "Field":
                resourceAmount = Random.Range(500, 750);
                break;
        }
    }

    public int HarvestResource(int amount)
    {
        resourceAmount -= amount;
        if (resourceAmount <= 0)
        {
            amount += resourceAmount;
            resourceAmount = 0;
            
            resourceService.RemoveActiveResource(gameObject);
            Destroy(gameObject);
        }

        return amount;
    }
    
    public int GetResourceAmount()
    {
        return resourceAmount;
    }
}
