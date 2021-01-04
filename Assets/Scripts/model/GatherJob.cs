using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GatherJob : Job
{
    private ResourceType resourceType;

    public GatherJob()
    {
    }
    
    public GatherJob(int priority, ResourceType resourceType, int energyRequired, int foodRequired) {
        this.priority = priority;
        this.resourceType = resourceType;
        resourceObject = resourceService.FindClosestResourceOfType(new Vector3(Random.Range(-15, 15),0,Random.Range(-15, 15)), resourceType);
        this.energyRequired = energyRequired;
        this.foodRequired = foodRequired;
        timer = 0;
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
            if (resourceType == ResourceType.FOOD)
            {
                Debug.LogError("Adding Gather FOOD Job from GatherJob");
                jobService.AddJob(new BuildJob(Globals.priorityBuildFarm, BuildingType.FARM, Globals.energyRequiredBuildFarm, Globals.foodRequiredBuildFarm));
                jobDone = true;
                jobService.jobList.Remove(this);
            }
            //Assign new resource to job
            resourceObject = resourceService.FindClosestResourceOfType(Globals.storageLocation, resourceType);
        }
    }
    
    private void HarverstResource()
    {
        peasant.animator.SetBool("isSwinging", true);
        timer += Time.deltaTime;
        if (timer >= 3.25f * Globals.actionCompleteDelay)
        {
            //Check how much the player can harvest based on inventory capacity
            int harvestAmount = 25;
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
}