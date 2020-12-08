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
    private GameObject fieldPrefabA;
    private GameObject fieldPrefabB;
    private GameObject housePrefab;
    private GameObject spawnedObject;
    
    public ResourceService resourceService = ResourceService.GetInstance();
    
    private int maxSpawnAttemptsPerObject = 5;
    private int maxSpawnRadius = 130;
    private int minStorageDistance = 10;
    private int maxStructureDistance = 50;

    // Start is called before the first frame update
    void Start()
    {
        treePrefab = Resources.Load("PT_Medieval_Tree_1") as GameObject;
        treePrefab.AddComponent<ResourceController>();
        treePrefab.tag = "Tree";
        stonePrefab = Resources.Load("PT_Medieval_Rock_6") as GameObject;
        stonePrefab.AddComponent<ResourceController>();
        stonePrefab.tag = "Stone";
        fieldPrefabA = Resources.Load("CarrotFarm") as GameObject;
        fieldPrefabA.AddComponent<ResourceController>();
        fieldPrefabA.tag = "Field";
        fieldPrefabB = Resources.Load("PotatoFarm") as GameObject;
        fieldPrefabB.AddComponent<ResourceController>();
        fieldPrefabB.tag = "Field";
        housePrefab = Resources.Load("House_Villager") as GameObject;
        //TODO Add Scriptcomponent to house Prefab
        housePrefab.tag = "House";
        
        SpawnGroup(treePrefab,50, 15, 2.5f);
        SpawnGroup(treePrefab,10, 7, 2f);
        SpawnGroup(treePrefab,10, 7, 2f);
        SpawnGroup(treePrefab,10, 7, 2f);
        SpawnGroup(treePrefab,15, 8, 2f);
        SpawnGroup(treePrefab,60, 25, 5f);
        SpawnGroup(treePrefab,20, 10, 1.5f);
        SpawnGroup(stonePrefab,10, 10, 8f);
        SpawnGroup(stonePrefab,5, 8, 10f);

        SpawnResources(treePrefab, 50);
        SpawnResources(stonePrefab, 30);
    }
    
    public void SpawnObject(GameObject toSpawn, Vector3 position, Quaternion rotation)
    {
        spawnedObject = Instantiate(toSpawn, position, rotation);
        resourceService.AddActiveResource(spawnedObject);
    }
    
    //Method to spawn resources in Scene
    private void SpawnResources(GameObject toSpawn, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position;
            if (Vector3.zero != (position = GetValidPosition(Vector3.zero, maxSpawnRadius, 5f, false)))
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
                //The position is too close to the center
                if (Vector3.Distance(position,Vector3.zero) < minStorageDistance)
                {
                    validPosition = false;
                }

                if (isStructure)
                {
                    if (Vector3.Distance(position,Vector3.zero) > maxStructureDistance)
                    {
                        validPosition = false;
                    }
                }
            }
        }

        if (position == Vector3.zero)
        {
            Debug.LogError("No position has been found");
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
                if (position != (spawnPosition = GetValidPosition(position, radius, objectCheckRadius, false)))
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
