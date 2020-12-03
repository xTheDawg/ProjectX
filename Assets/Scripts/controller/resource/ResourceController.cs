using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    protected GameObject resource;
    protected int resourceAmount;

    public int HarvestResource(int amount)
    {
        resourceAmount -= amount;
        if (resourceAmount <= 0)
        {
            amount += resourceAmount;
            resourceAmount = 0;
            Destroy(gameObject);
        }

        return amount;
    }
    
    public int GetResourceAmount()
    {
        return resourceAmount;
    }
}
