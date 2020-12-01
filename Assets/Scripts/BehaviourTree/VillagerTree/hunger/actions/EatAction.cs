using UnityEngine;

public class EatAction : ActionNode
{
    private bool isEating = false;
    private float eatStartTime;

    private StorageService storageService = new StorageService();

    public override NodeState Execute()
    {
        if (!isEating)
        {
            isEating = true;
            eatStartTime = Time.time;
            GetPeasant().animator.SetBool("isWalking", false);
            GetPeasant().animator.SetBool("isEating", true);
        }
        
        if (Time.time - eatStartTime > 5f)
        {
            Debug.Log("EatAction...");
            GetPeasant().foodLevel = GetPeasant().maxFoodLevel;
            GetPeasant().animator.SetBool("isEating", false);
            isEating = false;
            Debug.Log("Eating complete! Food Level is now at: " + GetPeasant().foodLevel);
            GetPeasant().foodLevel += storageService.TakeResource(ResourceType.FOOD, (Globals.foodMax - GetPeasant().foodLevel));
            return NodeState.SUCCESS;
        }
        
        return NodeState.RUNNING;
    }
}
