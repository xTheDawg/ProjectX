using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Peasant peasant = new Peasant(100, 15, 100);
        peasant.Work();

        Peasant peasant2 = new Peasant(69, 69, 69);
        peasant2.Work();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


