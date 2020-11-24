using System;
using UnityEngine;

public class Peasant : MonoBehaviour
{
    public float walkSpeed {get; set;} = 2f;
    public float rotSpeed {get; set;} = 5f;
    public float fatigueTimer {get; set;} = 0f;
    public int foodLevel {get; set;}
    public int maxFoodLevel {get; set;} = 100;
    public int energyLevel {get; set;}
    public int maxEnergyLevel {get; set;} = 100;
    public int inventoryCapacity {get; set;}
    public Animator animator {get; set;}
    public Quaternion rotation {get; set;}
    public RootSequence root {get; set;}

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
                this.energyLevel = energyLevel - 10;
                Debug.Log("Energy Level is now: " + energyLevel);
            }
        }
        Work();        
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("collided");
    }

    public void Work() {
        root.Evaluate();
    }    
   
    public void SetRotation(Vector3 direction)
    {
        rotation = Quaternion.LookRotation(direction);
    }
}
