using System;
using UnityEngine;

public class Peasant : MonoBehaviour
{
    private float walkSpeed = 2f;
    private float rotSpeed = 5f;
    private float fatigueTimer = 0f;
    private int foodLevel {get; set;}
    private int maxFoodLevel = 100;
    private int energyLevel {get; set;}
    private int maxEnergyLevel = 100;
    public int inventoryCapacity {get; set;}
    private Animator animator;
    private Quaternion rotation;
    public RootSequence root;

    private void Start()
    {
        root = new RootSequence(this);
        foodLevel = 100;
        energyLevel = 45;
        inventoryCapacity = 100;
        animator = gameObject.GetComponent<Animator>();
        Work();
    }

    private void Update()
    {
        fatigueTimer += Time.deltaTime;
        if (fatigueTimer > 2f)
        {
            fatigueTimer = fatigueTimer - 2f;
            if (!animator.GetBool("isResting"))
            {
                SetEnergylevel(GetEnergyLevel() - 10);
                Debug.Log("Energy Level is now: " + GetEnergyLevel());
            }
        }
        Work();
    }

    public void Work() {
        root.Evaluate();
    }
    
    public float GetWalkSpeed()
    {
        return walkSpeed;
    }
    
    public float GetRotSpeed()
    {
        return rotSpeed;
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
    
    public Quaternion GetRotation()
    {
        return rotation;
    }
    
    public void SetRotation(Vector3 direction)
    {
        rotation = Quaternion.LookRotation(direction);
    }

    public void SetEnergylevel(int amount)
    {
        energyLevel = amount;
    }
}
