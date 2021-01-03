using UnityEngine;
using System.Collections.Generic;

public class Peasant : MonoBehaviour
{
    //Peasant stats
    public float walkSpeed { get; set; } = Globals.walkSpeed;
    public float rotSpeed { get; set; } = Globals.rotSpeed;
    public int foodLevel { get; set; } = Globals.foodGameStart;
    public int maxFoodLevel { get; set; } = Globals.foodMax;
    public int energyLevel { get; set; } = Globals.energyGameStart;
    public int maxEnergyLevel { get; set; } = Globals.energyMax;

    public int inventoryCapacity { get; set; } = Globals.inventoryCapacity;
    
    public Dictionary<ResourceType, int> inventory  {get; set;} = new Dictionary<ResourceType, int>();

    //Misc
    public Animator animator { get; set; }
    public Vector3 targetRotation { get; set; }
    public RootSequence rootSequence { get; set; }
    public Vector3 position { get; set; }
    public Quaternion rotation { get; set; }
    public float fatigueTimer { get; set; } = 0f;
    public int woodInStorage { get; set; }
    public int stoneInStorage { get; set; }

    //Fields for Pathfinding
    public float angle { get; set; }
    public float detectionDistance { get; set; }
    public Vector3 directionR { get; set; }
    public Vector3 directionL { get; set; }
    public Vector3 deltaRotation { get; set; }
    public Vector3 rayPosition { get; set; }
    private RaycastHit hit;

    //Fields for controlling Movement
    public Vector3 target { get; set; }

    public Job currentJob { get; set; }

    private void Start()
    {
        angle = 15f;
        detectionDistance = 3f;
        target = Vector3.zero;
        rootSequence = new RootSequence(this);
        animator = gameObject.GetComponent<Animator>();
        
        //Player Camera
        Camera camera = gameObject.GetComponentInChildren<Camera>();
        camera.enabled = false;
        camera.GetComponent<AudioListener>().enabled  =  false;
        
        inventory[ResourceType.FOOD] = 0;
        inventory[ResourceType.WOOD] = 0;
        inventory[ResourceType.STONE] = 0;
        
        EvaluateTree();
    }

    private void Update()
    {
        position = transform.position;
        rotation = transform.rotation;
        fatigueTimer += Time.deltaTime;
        if (fatigueTimer > 10f)
        {
            fatigueTimer = fatigueTimer - 10f;
            if (!animator.GetBool("isResting") && !animator.GetBool("isEating"))
            {
                if (foodLevel <= 0)
                {
                    foodLevel = 0;
                }
                else
                {
                    foodLevel = foodLevel - 7;
                }

                if (energyLevel <= 0)
                {
                    energyLevel = 0;
                }
                else
                {
                    energyLevel = energyLevel - 10;
                }

                // Debug.Log("Energy Level: " + energyLevel + " Food level: " + foodLevel);
            }
        }

        if (target == Vector3.zero && (currentJob == null || currentJob.jobDone))
        {
            EvaluateTree();
        }
        else if (target == Vector3.zero && !currentJob.jobDone)
        {
            currentJob.DoJob();
        }
        else
        {
            GoToLocation();
        }
    }

    private void EvaluateTree()
    {
        rootSequence.Evaluate();
    }

    public void GoToLocation()
    {
        //Set walking Animation for Player
        animator.SetBool("isWalking", true);
        animator.SetBool("isResting", false);
        animator.SetBool("isEating", false);
        animator.SetBool("isPickingUp", false);
        animator.SetBool("isBuilding", false);
        animator.SetBool("isHarvesting", false);
        animator.SetBool("isSwinging", false);

        //Rotate Peasant before moving
        RotatePlayer();

        // Move Peasant forward
        transform.position += transform.forward * ((walkSpeed * Globals.animationSpeed) * Time.deltaTime );

        //Check if Player arrived at the destination
        if (CheckPosition(target))
        {
            //Stop walking Animation for Player
            animator.SetBool("isWalking", false);
            target = Vector3.zero;
        }
    }

    public bool CheckPosition(Vector3 targetPosition)
    {
        //If Peasant Position is within range then return true
        return Vector3.Distance(transform.position, targetPosition) < 3;
    }

    public void RotatePlayer()
    {
        //Setting Direction and Position of Pathfinding Rays
        deltaRotation = Vector3.zero;
        directionR = rotation * Quaternion.AngleAxis(angle, transform.up) * Vector3.forward * detectionDistance;
        directionL = rotation * Quaternion.AngleAxis(-angle, transform.up) * Vector3.forward * detectionDistance;
        rayPosition = new Vector3(transform.position.x, 0.3f, position.z);
        var rayR = new Ray(rayPosition, directionR);
        var rayL = new Ray(rayPosition, directionL);

        //Draw Rays in Scene Windows while Game is playing
        //Debug.DrawRay(rayPosition, directionR, Color.magenta);
        //Debug.DrawRay(rayPosition, directionL, Color.magenta);


        //Add Rotation Away from hit object (left prioritized)
        if (Physics.Raycast(rayL, out hit, detectionDistance))
        {
            deltaRotation -= rotSpeed * directionL;
            //Debug.Log("Ray Left Hit!");
        }
        else if (Physics.Raycast(rayR, out hit, detectionDistance))
        {
            deltaRotation -= rotSpeed * directionR;
            //Debug.Log("Ray Right Hit!");
        }

        //Apply Rotation to Object. Rotate towards Target Location if no Object was hit, otherwise rotate away from obstacle
        if (deltaRotation != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(rotation, Quaternion.LookRotation(deltaRotation),
                rotSpeed * Time.deltaTime);
        }
        else
        {
            // Calculate looking direction of peasant
            targetRotation = new Vector3(target.x - position.x,
                position.y, target.z - position.z);

            // Set rotation to make sure peasant looks at location.
            transform.rotation = Quaternion.Slerp(rotation,
                Quaternion.LookRotation(this.targetRotation),
                this.rotSpeed * Time.deltaTime);
        }
    }
}