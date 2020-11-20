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
    }

    // Update is called once per frame
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToReset);
        renderer.enabled = true;
        collider.enabled = true;
        treeWood = Random.Range(5, 10);
    }
    
    private void ResetTree()
    {
        renderer.enabled = false;
        collider.enabled = false;
        StartCoroutine(Wait());
    }

    public int GetWood()
    {
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
    }
}
