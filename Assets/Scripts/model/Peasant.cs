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
    public Vector3 rotation {get; set;}
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
            if (!animator.GetBool("isResting") && !animator.GetBool("isEating"))
            {
                this.energyLevel = energyLevel - 10;
                this.foodLevel = foodLevel - 7;
                Debug.Log("Energy Level: " + energyLevel + " Food level: " + foodLevel);
            }
        }
        Work();        
    }

    public void Work() {
        root.Evaluate();
    }


    public void GoToLocation(Vector3 location) {
        // Calculate looking direction of peasant
        this.rotation = new Vector3(location.x - this.transform.position.x,
            this.transform.position.y, location.z - this.transform.position.z);

        // Set rotation to make sure peasant looks at location.
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(this.rotation),
            this.rotSpeed * Time.deltaTime);

        // Move towards target
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            location,
            this.walkSpeed * Time.deltaTime);
    }
}
