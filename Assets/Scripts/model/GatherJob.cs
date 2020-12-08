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
        //Check if assigned resource still exists
        if (resourceObject != null)
        {
            //Check if Inventory is not yet full
            if (peasant.inventory[resourceType] < Globals.inventoryCapacity)
            {
                //Check if player is at the resource location
                if (peasant.CheckPosition(resourceObject.transform.position))
                {
                    //Start harvesting the resouce
                    //TODO Turn Peasant towards target
                    HarverstResource();
                }
                else
                {
                    //Set players target to the location of the resource
                    peasant.target = resourceObject.transform.position;
                }
            }
            else
            {
                //Check if player has arrived at the Storage Building
                if (peasant.CheckPosition(Globals.storageLocation))
                {
                    //Store the Resource in the players inventory inside the storage building
                    //TODO Turn Peasant towards target
                    StoreInventory();
                    if (peasant.inventory[resourceType] == 0)
                    {
                        // Lower energy and food level when job execution is done
                        peasant.energyLevel -= energyRequired;
                        peasant.foodLevel -= foodRequired;
                        jobDone = true;
                        jobService.jobList.Remove(this);
                    }
                }
                else
                {
                    //Set players target to the Storage Building location
                    peasant.target = Globals.storageLocation;
                }
            }
        }
        else
        {
            //Assign new resource to job
            resourceObject = resourceService.FindClosestResourceOfType(Globals.storageLocation, resourceType);
        }
    }
    
    private void HarverstResource()
    {
        peasant.animator.SetBool("isSwinging", true);
        timer += Time.deltaTime;
        if (timer >= 3.25f)
        {
            Debug.Log("Harvesting resource of type: " + resourceType);
            
            //Check how much the player can harvest based on inventory capacity
            int harvestAmount = 50;
            if ((Globals.inventoryCapacity - peasant.inventory[resourceType]) < harvestAmount)
            {
                harvestAmount = Globals.inventoryCapacity - peasant.inventory[resourceType];
            }
            
            peasant.inventory[resourceType] += resourceObject.GetComponent<ResourceController>().HarvestResource(harvestAmount);
            
            //Reset timer and animation
            timer = 0;
            peasant.animator.SetBool("isSwinging", false);
        }
    }
    
    private void StoreInventory()
    {
        peasant.animator.SetBool("isPickingUp", true);
        timer += Time.deltaTime;
        if (timer >= 6f)
        {
            peasant.animator.SetBool("isPickingUp", false);
            storageService.PutResource(resourceType, peasant.inventory[resourceType]);
            peasant.inventory[resourceType] = 0;
        }
    }
}