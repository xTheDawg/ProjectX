using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    protected GameObject resource;
    protected int resourceAmount;
    protected float timeToReset = 10.0f;
    protected CapsuleCollider collider;
    protected MeshRenderer renderer = new MeshRenderer();

    // Update is called once per frame
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToReset);
        renderer.enabled = true;
        collider.enabled = true;
        resourceAmount = Random.Range(5, 10);
    }
    
    private void Reset()
    {
        renderer.enabled = false;
        collider.enabled = false;
        StartCoroutine(Wait());
    }

    public int GetResourceAmount()
    {
        return resourceAmount;
    }
    
    public void SetResourceAmount(int amount)
    {
        resourceAmount += amount;
        if (resourceAmount <= 0)
        {
            resourceAmount = 0;
            Reset();
        }
    }
}
