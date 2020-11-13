using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeController : MonoBehaviour
{
    private GameObject tree;
    private int treeWood;
    private Color regularColor;
    private Color alphaColor;
    private float timeToFade = 2.0f;
    private float timeToReset = 10.0f;
    private Collider collider;
    
    // Start is called before the first frame update
    void Start()
    {
        tree = this.gameObject;
        treeWood = Random.Range(5, 10);
        regularColor = alphaColor = tree.GetComponent<MeshRenderer>().material.color;
        alphaColor.a = 0;
        collider = tree.GetComponent<CapsuleCollider>();
        setWood(-10);
    }

    // Update is called once per frame
    public IEnumerable resetTree()
    {
        yield return new WaitForSeconds(timeToReset);
        fadeIn();
        Debug.Log("Function resetTree has been executed.");
    }
    
    private void fadeIn()
    {
        tree.GetComponent<MeshRenderer>().material.color = Color.Lerp(tree.GetComponent<MeshRenderer>().material.color,
            regularColor, timeToFade * Time.deltaTime);
        collider.enabled = true;
        treeWood = Random.Range(5, 10);
        Debug.Log("Function fadeIn has been executed.");
    }
    
    private void fadeOut()
    {
        tree.GetComponent<MeshRenderer>().material.color = Color.Lerp(tree.GetComponent<MeshRenderer>().material.color,
            alphaColor, timeToFade * Time.deltaTime);
        collider.enabled = false;
        resetTree();
        Debug.Log("Function fadeOut has been executed.");
    }
    
    public int getWood()
    {
        Debug.Log("Function getWood has been executed.");
        return treeWood;
    }
    
    public void setWood(int amount)
    {
        treeWood += amount;
        if (treeWood <= 0)
        {
            treeWood = 0;
            fadeOut();
        }
        Debug.Log("Function setWood has been executed.");
    }
}
