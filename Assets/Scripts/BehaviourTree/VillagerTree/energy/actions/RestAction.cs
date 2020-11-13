using UnityEngine;

public class RestAction : ActionNode
{

    public override NodeState Execute()
    {
        /*while (Peasant.getEnergyLevel() < 100)
        {
            animator.SetBool("isResting", true);
            peasant.setEnergyLevel(peasant.getEnergylevel() + 1);
        }
        animator.SetBool("isResting", false);*/
        Debug.Log("Executing Node: RestAction");
        return NodeState.SUCCESS;
    }
}
