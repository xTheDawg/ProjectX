using UnityEngine;
public static class Globals {

    // Peasant
    public static int foodMax {get; set;} = 100;
    public static int foodCritical {get; set;} = 20;
    public static int foodGameStart {get; set;} = 15;
    public static int energyMax {get; set;} = 100;
    public static int energyCritical {get; set;} = 20;
    public static int energyGameStart {get; set;} = 100;
    public static int inventoryCapacity {get; set;} = 100;
    public static float walkSpeed {get; set;} = 3f;
    public static float rotSpeed {get; set;} = 5f;

    // Resource
    public static int maxSpawnRadius = 130;
    public static int maxStructureDistance {get; set;} = 30;
    public static int minStorageDistance = 10;
    public static float structureCheckDistance = 12f;

    // Storage
    public static Vector3 storageLocation {get; set;} = new Vector3(-1.5f,0,-1);
    public static int storageGameStartWood {get; set;} = 900;
    public static int storageGameStartStone {get; set;} = 400;
    public static int storageGameStartFood {get; set;} = 300;
    
    // Energy Required
    public static int energyRequiredBuildFarm {get; set;} = 30;
    public static int energyRequiredBuildHouse {get; set;} = 50;
    public static int energyRequiredGatherWood {get; set;} = 10;
    public static int energyRequiredGatherStone {get; set;} = 10;
    
    // Food Required
    public static int foodRequiredBuildFarm {get; set;} = 30;
    public static int foodRequiredBuildHouse {get; set;} = 50;
    public static int foodRequiredGatherWood {get; set;} = 10;
    public static int foodRequiredGatherStone {get; set;} = 10;
    
    // Priorities
    public static int priorityBuildFarm {get; set;} = 1;
    public static int priorityBuildHouse {get; set;} = 2;
    public static int priorityGatherWood {get; set;} = 3;
    public static int priorityGatherStone {get; set;} = 4;
    
    //ReplaySpeed
    public static float animationSpeed = 1.0f;
    public static float actionCompleteDelay = 1f;
    public static float dayNightSpeed = 11f;
}