using UnityEngine;

public abstract class Job {
    public int priority {get; set;}
    public GameObject resourceObject {get; set;}
    public int energyRequired {get; set;}
    public int foodRequired {get; set;}
    public bool jobDone {get; set;}
    public Peasant peasant {get; set;}
    
    protected float timer {get; set;}
    
    protected JobService jobService = JobService.GetInstance();
    protected StorageService storageService = StorageService.GetInstance();
    protected ResourceService resourceService = ResourceService.GetInstance();

    public Job()
    {
    }

    public abstract void DoJob();
    
    protected void StoreInventory()
    {
        peasant.animator.SetBool("isPickingUp", true);
        timer += Time.deltaTime;
        if (timer >= 6f)
        {
            peasant.animator.SetBool("isPickingUp", false);
            storageService.PutResource(ResourceType.WOOD, peasant.inventory[ResourceType.WOOD]);
            peasant.inventory[ResourceType.WOOD] = 0;
            storageService.PutResource(ResourceType.STONE, peasant.inventory[ResourceType.STONE]);
            peasant.inventory[ResourceType.STONE] = 0;

            timer = 0;
        }
    }
}
