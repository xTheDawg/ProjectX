using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class JobService
{
    private static JobService instance = null;
    private static readonly object padlock = new object();

    public List<Job> jobList = new List<Job>();
    
    public static JobService GetInstance() {        
        lock (padlock) {
            if (instance == null)
            {
                instance = new JobService();
            }
            return instance;
        }       
    }

    public void AddJob()
    {
        // TODO Sort here
    }
    
    public Job GetJob(Peasant peasant)
    {
        jobList.Clear();
        // TODO Remove, only for testing purposes
        jobList.Add(new GatherJob(1, ResourceType.WOOD,10 , 5));
        
        Job job = jobList.First();
        job.peasant = peasant;
        return job;
    }
}