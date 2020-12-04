﻿using System.Collections;
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

    // Add job to joblist and order it by priority.
    public void AddJob(Job jobToAd)
    {
        jobList.Add(jobToAd);
        jobList = jobList.OrderBy(job => job.priority).ToList();
    }
    
    public Job GetJob(Peasant peasant)
    {
        Job job = jobList.First();
        job.peasant = peasant;
        return job;
    }
}