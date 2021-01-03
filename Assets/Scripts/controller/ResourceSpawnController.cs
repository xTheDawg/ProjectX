using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceSpawnController : MonoBehaviour
{
    private GameObject treePrefab;
    private GameObject stonePrefab;
    public GameObject fieldPrefabA;
    public GameObject fieldPrefabB;
    public GameObject housePrefab;
    public GameObject placeHolderPrefab;
    public GameObject peasantPrefab;
    private GameObject spawnedObject;
    
    public ResourceService resourceService = ResourceService.GetInstance();
    
    private int maxSpawnAttemptsPerObject = 30;

    private float timer = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //Resource Prefabs
        treePrefab = Resources.Load("PT_Medieval_Tree_1") as GameObject;
        treePrefab.tag = "Tree";
        stonePrefab = Resources.Load("PT_Medieval_Rock_6") as GameObject;
        stonePrefab.tag = "Stone";
        fieldPrefabA = Resources.Load("CarrotFarm") as GameObject;
        fieldPrefabA.tag = "Field";
        fieldPrefabB = Resources.Load("PotatoFarm") as GameObject;
        fieldPrefabB.tag = "Field";
        
        //Structure Prefabs
        housePrefab = Resources.Load("House_Villager") as GameObject;
        housePrefab.tag = "House";
        placeHolderPrefab = Resources.Load("Placeholder/Placeholder") as GameObject;
        placeHolderPrefab.tag = "temp";
        
        //Player prefab
        peasantPrefab = Resources.Load("Characters/Prefabs/PT_Medieval_Male_Peasant_01_a") as GameObject;
        peasantPrefab.GetComponent<Animator>().runtimeAnimatorController = 
            Resources.Load("Characters/Prefabs/PT_Medieval_Male_Peasant_01_a_Animator Controller") as RuntimeAnimatorController;
        peasantPrefab.tag = "Player";

        //Spawn Initial Peasant
        SpawnObject(peasantPrefab, Globals.storageLocation, GetCenterRotation(Globals.storageLocation));
        //Spawn Groups of Trees and Stones
        SpawnGroup(treePrefab,50, 15, 3.5f);
        SpawnGroup(treePrefab,10, 7, 3f);
        SpawnGroup(treePrefab,10, 7, 3f);
        SpawnGroup(treePrefab,10, 7, 3f);
        SpawnGroup(treePrefab,15, 8, 3f);
        SpawnGroup(treePrefab,60, 25, 5f);
        SpawnGroup(treePrefab,20, 10, 2.5f);
        SpawnGroup(stonePrefab,10, 10, 5f);
        SpawnGroup(stonePrefab,5, 8, 5f);

        //Spawn Single Resource Objects
        SpawnResources(treePrefab, 100);
        SpawnResources(stonePrefab, 50);
    }

    private void LateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 60f)
        {
            SpawnResources(treePrefab, 5);
            SpawnResources(stonePrefab, 3);
            timer = 0f;
        }
    }

    public void SpawnObject(GameObject toSpawn, Vector3 position, Quaternion rotation)
    {
        spawnedObject = Instantiate(toSpawn, position, rotation);
        resourceService.AddActiveResource(spawnedObject);
        if (spawnedObject.tag.Equals("Player"))
        {
            Animator animator = spawnedObject.GetComponent<Animator>();
        }
    }
    
    public GameObject GetSpawnObject()
    {
        return spawnedObject;
    }
    
    public void DestroyObject(GameObject toDestroy)
    {
        resourceService.RemoveActiveResource(toDestroy);
        Destroy(toDestroy);
    }
    
    //Method to spawn resources in Scene
    private void SpawnResources(GameObject toSpawn, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position;
            if (Vector3.zero != (position = GetValidPosition(Vector3.zero, Globals.maxSpawnRadius, 5f, false)))
            {
                SpawnObject(toSpawn, position, new Quaternion(0, Random.Range(0, 360), 0, 0));
            }
        }
    }
    
    public Quaternion GetCenterRotation(Vector3 position)
    {
        //Calculate a directional Vector from position to the center point (Vector3.zero)
        Vector3 direction = (Vector3.zero - position).normalized;
        
        //Create Quaternion and set the rotation to the directional vector
        Quaternion rotation = new Quaternion();
        rotation.SetLookRotation(direction);
        
        return rotation;
    }
    
    //Returns a Position for an object to spawn, returns vector3.zero if no position has been found after several retries
    public Vector3 GetValidPosition(Vector3 spawnPoint, int spawnRadius, float objectCheckRadius, bool isStructure)
    {
        //Create Position variable
        Vector3 position = Vector3.zero;

        //Whether or not we can spawn the Object
        bool validPosition = false;

        //Variable to track spawn attempts
        int spawnAttempts = 0;

        while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObject)
        {
            //Increment Attempt counter and switch validPosition flag
            validPosition = true;
            spawnAttempts++;
                
            //Pick a random position in an Area
            position = new Vector3(spawnPoint.x + Random.Range(-spawnRadius, spawnRadius), 0, spawnPoint.z + Random.Range(-spawnRadius, spawnRadius));
            
            //The position is too close to the center
            if (Vector3.Distance(Vector3.zero, position) < Globals.minStorageDistance)
            {
                validPosition = false;
            }

            //Check if the position was outside of the structure area
            if (isStructure)
            {
                if (Vector3.Distance(position,Vector3.zero) < Globals.maxStructureDistance)
                {
                    validPosition = false;
                }
            }

            if (validPosition)
            {
                //Array of all colliders within our Object check radius
                Collider[] colliders = Physics.OverlapSphere(position, objectCheckRadius);

                //Check valid position based on colliding tags and desired spawn Area
                foreach (var collider in colliders)
                {
                    //A treeCollider is within the Radius
                    if (collider.tag.Equals("Tree"))
                    {
                        validPosition = false;
                    }
                    //A stoneCollider is within the Radius
                    if (collider.tag.Equals("Stone"))
                    {
                        validPosition = false;
                    }
                    //A houseCollider is within the Radius
                    if (collider.tag.Equals("House"))
                    {
                        validPosition = false;
                    }
                    //A playerCollider is within the Radius
                    if (collider.tag.Equals("Player"))
                    {
                        validPosition = false;
                    }
                    //A fieldCollider is within the Radius
                    if (collider.tag.Equals("Field"))
                    {
                        validPosition = false;
                    }
                    //A placeholderCollider is within the Radius
                    if (collider.tag.Equals("temp"))
                    {
                        validPosition = false;
                    }
                }
            }
        }

        if (!validPosition)
        {
            return Vector3.zero;
        }
        return position;
    }
    
    private void SpawnGroup(GameObject toSpawn, int spawnAmount, int radius, float objectCheckRadius)
    {
        Vector3 position;
        Vector3 spawnPosition;
        if (Vector3.zero != (position = GetValidPosition(Vector3.zero, 80, 5f, false)))
        {
            SpawnObject(toSpawn, position, new Quaternion(0, Random.Range(0, 360), 0, 0));
            
            for (int i = 0; i < spawnAmount; i++)
            {
                if (Vector3.zero != (spawnPosition = GetValidPosition(position, radius, objectCheckRadius, false)))
                {
                    SpawnObject(toSpawn, spawnPosition, new Quaternion(0, Random.Range(0, 360), 0, 0));
                }
            }
        }
        else
        {
            Debug.LogError("No valid position found for Forest!");
        }
    }
}
