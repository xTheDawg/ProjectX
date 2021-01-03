using UnityEngine;

public class EatAction : ActionNode
{
    private bool isEating = false;
    private float eatStartTime;

    private StorageService storageService = StorageService.GetInstance();

    public override NodeState Execute()
    {
        if (!isEating)
        {
            isEating = true;
            eatStartTime = Time.time;
            GetPeasant().animator.SetBool("isEating", true);
        }
        
        if (Time.time - eatStartTime > 5f * Globals.actionCompleteDelay)
        {
            GetPeasant().animator.SetBool("isEating", false);
            isEating = false;
            GetPeasant().foodLevel += storageService.TakeResource(ResourceType.FOOD, (Globals.foodMax - GetPeasant().foodLevel));
            Debug.Log("Eating complete! Food Level is now at: " + GetPeasant().foodLevel);
            Debug.Log("The amount of Food left in storage: " + storageService.resources[ResourceType.FOOD]);
            return NodeState.SUCCESS;
        }
        
        return NodeState.RUNNING;
    }
}
