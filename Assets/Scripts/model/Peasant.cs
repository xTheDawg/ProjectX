using UnityEngine;

public class Peasant : MonoBehaviour
{
    private int foodLevel {get; set;}
    private int maxFoodLevel = 100;
    private int energyLevel {get; set;}
    private int maxEnergyLevel = 100;
    public int inventoryCapacity {get; set;}
    private Animator animator;

    public RootSequence root;

    private void Start()
    {
        root = new RootSequence(this);
        foodLevel = 100;
        energyLevel = 15;
        inventoryCapacity = 100;
        animator = gameObject.GetComponent<Animator>();
        Work();
    }

    public void Work() {
        root.Evaluate();
    }
    
    public int GetEnergyLevel()
    {
        return energyLevel;
    }
    
    public int GetMaxFoodlevel()
    {
        return maxFoodLevel;
    }
    
    public int GetMaxEnergyLevel()
    {
        return maxEnergyLevel;
    }
    
    public Animator GetAnimator()
    {
        return animator;
    }

    public void AddEnergylevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > maxEnergyLevel)
        {
            energyLevel = maxEnergyLevel;
        }
    }
}
