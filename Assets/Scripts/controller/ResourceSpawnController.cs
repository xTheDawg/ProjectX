using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ResourceSpawnController : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject stonePrefab;
    private GameObject spawnedObject;
    private List<GameObject> activeObjects = new List<GameObject>();

    private float objectCheckRadius = 5f;
    private int maxSpawnAttemptsPerObject = 5;
    private int maxSpawnRadius = 130;

    // Start is called before the first frame update
    void Start()
    {
        treePrefab = Resources.Load("PT_Medieval_Tree_1") as GameObject;
        treePrefab.AddComponent<TreeController>();
        stonePrefab = Resources.Load("PT_Medieval_Rock_6") as GameObject;
        stonePrefab.AddComponent<StoneController>();

        SpawnResources(treePrefab, 100);
        SpawnResources(stonePrefab, 50);
    }

    //Method to spawn Object in Scene
    public void SpawnResources(GameObject toSpawn, int amount)
    {
        for (int i = 0; i < amount; i++)
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
                position = new Vector3(Random.Range(-maxSpawnRadius, maxSpawnRadius), 0, Random.Range(-maxSpawnRadius, maxSpawnRadius));

                //Array of all colliders within our Object check radius
                Collider[] colliders = Physics.OverlapSphere(position, objectCheckRadius);

                //Check valid position based on colliding tags
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
                    if (Vector3.Distance(position,Vector3.zero) < 50)
                    {
                        validPosition = false;
                    }
                }
            }
            
            if (validPosition)
            {
                spawnedObject = Instantiate(toSpawn, position, new Quaternion(0, Random.Range(0, 360), 0, 0));
                activeObjects.Add(spawnedObject);
            }
        }
    }
}
