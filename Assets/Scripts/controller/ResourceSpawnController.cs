using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ResourceSpawnController : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject stonePrefab;
    private GameObject spawnedObject;
    private ResourceHelper resourceHelper = new ResourceHelper();

    // Start is called before the first frame update
    void Start()
    {
        treePrefab = Resources.Load("PT_Medieval_Tree_1") as GameObject;
        treePrefab.AddComponent<TreeController>();
        stonePrefab = Resources.Load("PT_Medieval_Rock_6") as GameObject;
        stonePrefab.AddComponent<StoneController>();

        spawnResources(treePrefab, 100);
        spawnResources(stonePrefab, 50);
    }

    public void spawnResources(GameObject toSpawn, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            spawnedObject = Instantiate(toSpawn, new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
                new Quaternion(0, Random.Range(0, 360), 0, 0));

            //Destroy Object if it was spawned too close to the center
            if (Vector3.Distance(spawnedObject.transform.position,Vector3.zero) < 10)
                // || 
                // Vector3.Distance(spawnedObject.transform.position,resourceHelper.FindClosestResource(spawnedObject.transform.position, ResourceType.WOOD).transform.position) < 4 ||
                // Vector3.Distance(spawnedObject.transform.position,resourceHelper.FindClosestResource(spawnedObject.transform.position, ResourceType.STONE).transform.position) < 4 ||
                // Vector3.Distance(spawnedObject.transform.position,resourceHelper.FindClosestResource(spawnedObject.transform.position, ResourceType.FOOD).transform.position) < 4)
            {
                Debug.Log("Position invalid!");
                Destroy(spawnedObject);
                i--;
            }
        }
    }
}
