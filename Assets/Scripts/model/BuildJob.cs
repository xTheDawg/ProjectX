using UnityEngine;

public class BuildJob : Job
{
    private BuildingType buildingType;
    private Vector3 position;
    private Quaternion rotation;
    private GameObject toSpawn;
    private ResourceSpawnController resourceSpawnController = GameObject.FindObjectOfType<ResourceSpawnController>();

    private int woodRequired;
    private int stoneRequired;
    private bool spawnPlaceholder = true;
    private bool buildingDone = false;

    public BuildJob(int priority, BuildingType buildingType, int energyRequired, int foodRequired) {
        this.priority = priority;
        this.buildingType = buildingType;
        this.energyRequired = energyRequired;
        this.foodRequired = foodRequired;
        position = resourceSpawnController.GetValidPosition(Vector3.zero, Globals.maxStructureDistance,
            Globals.structureCheckDistance, true);
        rotation = resourceSpawnController.GetCenterRotation(position);
        timer = 0;

        switch (buildingType)
        {
            case BuildingType.HOUSE:
                woodRequired = 100;
                stoneRequired = 100;
                toSpawn = resourceSpawnController.housePrefab;
                break;
            case BuildingType.FARM:
                woodRequired = 100;
                stoneRequired = 50;
                if (Random.Range(0f,1f) >= 0.5f)
                {
                    
                    toSpawn = resourceSpawnController.fieldPrefabA;
                    break;
                }

                toSpawn = resourceSpawnController.fieldPrefabB;
                break;
        }
    }

    public override void DoJob()
    {
        //Spawn placeholder
        if (spawnPlaceholder)
        {
            if (Vector3.zero != position)
            {
                resourceSpawnController.SpawnObject(resourceSpawnController.placeHolderPrefab, position, rotation);
                resourceObject = resourceSpawnController.GetSpawnObject();
                spawnPlaceholder = false;
            }
            else
            {
                Debug.LogError("No valid position for structure found!");
            }
            
        }

        //If flag is true then the structure can't be spawned
        if (!spawnPlaceholder)
        {
            if (buildingDone)
            {
                if (peasant.CheckPosition(Globals.storageLocation))
                {
                    //Store inventory in storage
                    StoreInventory();
                    
                    //Remove Placeholder
                    resourceSpawnController.DestroyObject(resourceObject);
                    
                    //Spawn finished structure
                    resourceSpawnController.SpawnObject(toSpawn, position, rotation);
                    
                    //Spawn new Peasant
                    resourceSpawnController.SpawnObject(resourceSpawnController.peasantPrefab, 
                        resourceSpawnController.GetValidPosition(position,30,5,false), rotation);
                    
                    //finish Job
                    peasant.energyLevel -= energyRequired;
                    peasant.foodLevel -= foodRequired;
                    jobDone = true;
                    jobService.jobList.Remove(this);
                }
                else
                {
                    //Walk to Storage
                    peasant.target = Globals.storageLocation;
                }
            }
            else
            {
                //If the peasant does not have a full inventory
                if (peasant.inventory[ResourceType.WOOD] < Globals.inventoryCapacity || peasant.inventory[ResourceType.STONE] < Globals.inventoryCapacity)
                {
                    if (peasant.CheckPosition(Globals.storageLocation))
                    {
                        TakeFromStorage();
                    }
                    else
                    {
                        //Walk to Storage
                        peasant.target = Globals.storageLocation;
                    }
                }
                else
                {
                    if (peasant.CheckPosition(position))
                    {
                        BuildStructure();
                    }
                    else
                    {
                        peasant.target = position;
                    }
                }
            }
        }
        else
        {
            //End Job without reducing values
            Debug.LogError("Job could not be executed properly!");
            jobDone = true;
            jobService.jobList.Remove(this);
        }
    }
    
    private void TakeFromStorage()
    {
        peasant.animator.SetBool("isPickingUp", true);
        timer += Time.deltaTime;
        if (timer >= 6f * Globals.actionCompleteDelay)
        {
            peasant.animator.SetBool("isPickingUp", false);
            
            int currentResourceAmount = peasant.inventory[ResourceType.WOOD];
            storageService.TakeResource(ResourceType.WOOD, Globals.inventoryCapacity - currentResourceAmount);
            peasant.inventory[ResourceType.WOOD] += Globals.inventoryCapacity - currentResourceAmount;
            currentResourceAmount = peasant.inventory[ResourceType.STONE];
            storageService.TakeResource(ResourceType.STONE, Globals.inventoryCapacity - currentResourceAmount);
            peasant.inventory[ResourceType.STONE] += Globals.inventoryCapacity - currentResourceAmount;

            //Reset the timer
            timer = 0f;
        }
    }
    
    private void BuildStructure()
    {
        peasant.animator.SetBool("isBuilding", true);
        timer += Time.deltaTime;
        if (timer >= 8f * Globals.actionCompleteDelay)
        {
            peasant.animator.SetBool("isBuilding", false);

            if (woodRequired > Globals.inventoryCapacity)
            {
                woodRequired -= peasant.inventory[ResourceType.WOOD];
                peasant.inventory[ResourceType.WOOD] = 0;
            }
            else
            {
                peasant.inventory[ResourceType.WOOD] -= woodRequired;
                woodRequired = 0;
            }
            
            if (stoneRequired > Globals.inventoryCapacity)
            {
                stoneRequired -= peasant.inventory[ResourceType.STONE];
                peasant.inventory[ResourceType.STONE] = 0;
            }
            else
            {
                peasant.inventory[ResourceType.STONE] -= stoneRequired;
                stoneRequired = 0;
            }

            if (woodRequired == 0 && stoneRequired == 0)
            {
                buildingDone = true;
            }

            //Reset the timer
            timer = 0f;
        }
    }
}
