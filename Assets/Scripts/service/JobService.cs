using System.Collections;
using System.Collections.Generic;

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
}