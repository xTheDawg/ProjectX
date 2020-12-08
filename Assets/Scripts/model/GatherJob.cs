using UnityEngine;

public class GatherJob : Job
{
    private ResourceType resourceType;

    private StorageService storageService = StorageService.GetInstance();
    public ResourceService resourceService = ResourceService.GetInstance();
    private JobService jobService = JobService.GetInstance();
    
    private float timer = 0;
    
    public GatherJob()
    {
    }
    
    public GatherJob(int priority, ResourceType resourceType, int energyRequired, int foodRequired) {
        this.priority = priority;
        this.resourceType = resourceType;
        resourceObject = resourceService.FindClosestResourceOfType(Globals.storageLocation, resourceType);
        this.energyRequired = energyRequired;
        this.foodRequired = foodRequired;
    }

    public override void DoJob()
    {
        // If peasant is not at desired location yet, set target.
        if (resourceObject != null && !peasant.CheckPosition(resourceObject.transform.position) && peasant.inventory[resourceType] < Globals.inventoryCapacity)
        {
            peasant.target = resourceObject.transform.position;
        }
        else
        {
            if (peasant.inventory[resourceType] >= Globals.inventoryCapacity || resourceObject == null)
            {
                peasant.animator.SetBool("isSwinging", false);
                if (!peasant.CheckPosition(Globals.storageLocation))
                {
                    peasant.target = Globals.storageLocation;
                }
                //TODO Turn Peasant towards target
                peasant.animator.SetBool("isPickingUp", true);
                timer += Time.deltaTime;
                if (timer >= 6f)
                {
                    peasant.animator.SetBool("isPickingUp", false);
                    storageService.PutResource(resourceType, peasant.inventory[resourceType]);
                    peasant.inventory[resourceType] = 0;
                    
                    // Lower energy and food level when job execution is done
                    peasant.energyLevel -= energyRequired;
                    peasant.foodLevel -= foodRequired;
                    jobDone = true;
                    jobService.jobList.Remove(this);
                }
            }
            else
            {
                //TODO Turn Peasant towards target
                peasant.animator.SetBool("isSwinging", true);
                timer += Time.deltaTime;
                if (timer >= 3.25f)
                {
                    Debug.Log("Harvesting resource of type: " + resourceType);
                    peasant.inventory[resourceType] += resourceObject.GetComponent<ResourceController>().HarvestResource(50);
                    timer = 0;
                }
            }
        }
    }
}