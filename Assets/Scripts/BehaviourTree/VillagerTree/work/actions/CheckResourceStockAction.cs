using UnityEngine;

public class CheckResourceStockAction : ActionNode
{
    private StorageService storageService = StorageService.GetInstance();

    public override NodeState Execute()
    {
        GetPeasant().target = Globals.storageLocation;
        if (!GetPeasant().CheckPosition(Globals.storageLocation))
        {
            return NodeState.RUNNING;
        }

        GetPeasant().woodInStorage = storageService.resources[ResourceType.WOOD];
        GetPeasant().stoneInStorage = storageService.resources[ResourceType.STONE];
        
        //Debug.Log("Executing Node: CheckResourceStockAction");
        return NodeState.SUCCESS;
    }
}
