using System.Collections;
using System.Collections.Generic;


public sealed class StorageService
{
    private static StorageService instance = null;
    private static readonly object padlock = new object();

    public Dictionary<ResourceType, int> resources  {get; set;} = new Dictionary<ResourceType, int>();

    // Init game start stock
    public StorageService() {
        resources.Add(ResourceType.WOOD, Globals.storageGameStartWood);
        resources.Add(ResourceType.STONE, Globals.storageGameStartStone);
        resources.Add(ResourceType.FOOD, Globals.storageGameStartFood);
    }

    public static StorageService GetInstance() {        
        lock (padlock) {
            if (instance == null)
            {
                instance = new StorageService();
            }
            return instance;
        }
    }

    public void PutResource(ResourceType resource, int amount) {
        resources[resource] += amount;
    }

    public int TakeResource(ResourceType resource, int amount) {
        resources[resource] -= amount;
        return amount;
    }
}
