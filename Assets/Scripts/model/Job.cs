public class Job {
    private int priority {get; set;}
    private Location location {get; set;}
    private int energyNeeded {get; set;}

    public Job(int priority, Location location, int energyNeeded) {
         this.priority = priority;
         this.location = location;
         this.energyNeeded = energyNeeded;
     }
}
