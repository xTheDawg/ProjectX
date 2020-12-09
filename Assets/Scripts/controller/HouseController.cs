using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    private ResourceSpawnController resourceSpawnController = GameObject.FindObjectOfType<ResourceSpawnController>();
    // Start is called before the first frame update
    void Awake()
    {
        resourceSpawnController.SpawnObject(resourceSpawnController.peasantPrefab, Globals.storageLocation, resourceSpawnController.GetCenterRotation(Globals.storageLocation));
    }
}
