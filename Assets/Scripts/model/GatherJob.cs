using UnityEngine;

public class GatherJob : Job
{
    public ResourceType resourceType;
    
    public ResourceHelper resourceHelper = new ResourceHelper();
    
    public GatherJob()
    {
    }
    
    public GatherJob(int priority, ResourceType resourceType, int energyRequired, int foodRequired) {
        this.priority = priority;
        this.resourceType = resourceType;
        this.resourceObject = resourceHelper.FindClosestResource(Globals.storageLocation, resourceType);
        this.energyRequired = energyRequired;
        this.foodRequired = foodRequired;
    }

    public override void DoJob()
    {
        // If peasant is not at resource location yet, set target.
        if (!peasant.CheckPosition(resourceObject.transform.position))
        {
            Debug.Log("settings position of job location");
            peasant.target = resourceObject.transform.position;
        }
        else
        {
            Debug.Log("Harvesting resource");
            peasant.inventory[resourceType] += resourceObject.HarvestResource(5);
            
            // TODO Implement in progress job
            // if (scho aues gsammlet) {
            //     joblist.remove(this);
            // } else {
            //     this.resourceAmount -= 10;
            // }
            
            // Lower energy and food level when job execution is done
            peasant.energyLevel -= energyRequired;
            peasant.foodLevel -= foodRequired;
            jobDone = true;
        }
    }
}