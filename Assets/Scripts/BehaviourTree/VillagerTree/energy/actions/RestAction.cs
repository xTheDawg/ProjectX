using System.Collections;
using UnityEngine;

public class RestAction : ActionNode
{

    public override NodeState Execute()
    {
        GetPeasant().GetAnimator().SetBool("isWalking", false);
        Debug.Log("Setting walking to false");
        GetPeasant().GetAnimator().SetBool("isResting", true);
        Debug.Log("Setting resting to true");
        GetPeasant().StartCoroutine(RegenerateEnergy());
        Debug.Log("Executing Node: RestAction");
        return GetPeasant().GetEnergyLevel() == GetPeasant().GetMaxEnergyLevel() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
    private IEnumerator RegenerateEnergy() {
        GetPeasant().SetActiveTask(true);
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (GetPeasant().GetEnergyLevel() < GetPeasant().GetMaxEnergyLevel())
        {
            GetPeasant().AddEnergylevel(1);
            yield return wait;
            Debug.Log("The Peasants Energy Level is at: " + GetPeasant().GetEnergyLevel());
        }
        GetPeasant().GetAnimator().SetBool("isResting", false);
        GetPeasant().SetActiveTask(false);
        Debug.Log("Setting resting to false");
    }
}
