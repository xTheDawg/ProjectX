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
            GetPeasant().GetAnimator().SetBool("isWalking", false);
            GetPeasant().GetAnimator().SetBool("isResting", true);
        }

        if (Time.time - restStartTime > 5f)
        {
            GetPeasant().SetEnergylevel(GetPeasant().GetMaxEnergyLevel());
            GetPeasant().GetAnimator().SetBool("isResting", false);
            isRegenerating = false;
            Debug.Log("Resting complete! Energy Level is now at: " + GetPeasant().GetEnergyLevel());
            return NodeState.SUCCESS;
        }

        return NodeState.RUNNING;
    }
}
