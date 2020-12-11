using System.Collections;
using UnityEngine;

public class RestAction : ActionNode
{
    private bool isRegenerating = false;
    private float restStartTime;

    public override NodeState Execute()
    {
        if (!isRegenerating)
        {
            isRegenerating = true;
            restStartTime = Time.time;
            GetPeasant().animator.SetBool("isResting", true);
        }

        if (Time.time - restStartTime > 5f * Globals.actionCompleteDelay)
        {
            GetPeasant().energyLevel = GetPeasant().maxEnergyLevel;
            GetPeasant().animator.SetBool("isResting", false);
            isRegenerating = false;
            Debug.Log("Resting complete! Energy Level is now at: " + GetPeasant().energyLevel);
            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }
}
