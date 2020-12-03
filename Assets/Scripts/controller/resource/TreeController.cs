using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : ResourceController
{    
    // Start is called before the first frame update
    void Start()
    {
        resource = this.gameObject;
        resourceAmount = Random.Range(100, 200);
    }
}
