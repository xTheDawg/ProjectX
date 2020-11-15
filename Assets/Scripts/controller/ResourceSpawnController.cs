using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawnController : MonoBehaviour
{
    public GameObject treePrefab;

    public GameObject stonePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            spawnResources(treePrefab);
        }
        for (int i = 0; i < 30; i++)
        {
            spawnResources(stonePrefab);
        }
    }
    
    public void spawnResources(GameObject toSpawn)
    {
        Instantiate(toSpawn, new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
            new Quaternion(0, Random.Range(0, 360), 0, 0));
    }
}
