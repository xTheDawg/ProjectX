using System.Collections;
using System.Collections.Generic;


public sealed class StorageService
{
    private static StorageService instance = null;
    private static readonly object padlock = new object();

    Dictionary<ResourceType, int> goods = new Dictionary<ResourceType, int>();

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
        goods[resource] += amount;
    }

    public void TakeResource(ResourceType resource, int amount) {
        goods[resource] -= amount;
    }
}
