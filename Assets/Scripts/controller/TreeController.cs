using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeController : MonoBehaviour
{
    private GameObject tree;
    private int treeWood;
    private float timeToReset = 10.0f;
    private CapsuleCollider collider = new CapsuleCollider();
    private MeshRenderer renderer = new MeshRenderer();
    
    // Start is called before the first frame update
    void Start()
    {
        tree = this.gameObject;
        treeWood = Random.Range(5, 10);
        collider = tree.GetComponent<CapsuleCollider>();
        renderer = tree.GetComponent<MeshRenderer>();
        SetWood(-10);
    }

    // Update is called once per frame
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToReset);
        Debug.Log("Waited " + timeToReset + " seconds!");
        renderer.enabled = true;
        collider.enabled = true;
        treeWood = Random.Range(5, 10);
        Debug.Log("Tree has been activated and contains " + treeWood + " Wood!");
    }
    
    private void ResetTree()
    {
        renderer.enabled = false;
        collider.enabled = false;
        StartCoroutine(Wait());
        Debug.Log("Tree has been deactivated!");
    }

    public int GetWood()
    {
        Debug.Log("Function getWood has been executed.");
        return treeWood;
    }
    
    public void SetWood(int amount)
    {
        treeWood += amount;
        if (treeWood <= 0)
        {
            treeWood = 0;
            ResetTree();
        }
        Debug.Log("Function setWood has been executed.");
    }
}
