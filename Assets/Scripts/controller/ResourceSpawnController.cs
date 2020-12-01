using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawnController : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject stonePrefab;
    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        treePrefab = Resources.Load("PT_Medieval_Tree_1") as GameObject;
        treePrefab.AddComponent<TreeController>();
        stonePrefab = Resources.Load("PT_Medieval_Rock_6") as GameObject;
        stonePrefab.AddComponent<StoneController>();

        for (int i = 0; i < 100; i++)
        {
            if (!spawnResources(treePrefab))
            {
                i--;
            }
        }
        for (int i = 0; i < 30; i++)
        {
            if (!spawnResources(stonePrefab))
            {
                i--;
            }
        }
    }
    
    public bool spawnResources(GameObject toSpawn)
    {
        spawnedObject = Instantiate(toSpawn, new Vector3(Random.Range(-130, 130), 0, Random.Range(-130, 130)),
            new Quaternion(0, Random.Range(0, 360), 0, 0));
        if ((spawnedObject.transform.position - Vector3.zero).sqrMagnitude < 900)
        {
            Destroy(spawnedObject);
            return false;
        }

        return true;
    }
}
