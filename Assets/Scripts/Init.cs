﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
        RootSequence rs = new RootSequence();
        rs.Evaluate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


