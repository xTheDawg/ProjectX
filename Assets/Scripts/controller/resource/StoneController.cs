using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : ResourceController
{    
    // Start is called before the first frame update
    void Start()
    {
        resource = this.gameObject;
        resourceAmount = Random.Range(50, 100);
        collider = resource.GetComponent<CapsuleCollider>();
        renderer = resource.GetComponent<MeshRenderer>();
    }
}
