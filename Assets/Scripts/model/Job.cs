using UnityEngine;

public abstract class Job {
    public int priority {get; set;}
    public GameObject resourceObject {get; set;}
    public int energyRequired {get; set;}
    public int foodRequired {get; set;}
    public bool jobDone {get; set;}
    public Peasant peasant {get; set;}


    public Job()
    {
    }

    public abstract void DoJob();
}
