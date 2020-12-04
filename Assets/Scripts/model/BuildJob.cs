public class BuildJob : Job
{
    private BuildingType buildingType;
    
    public BuildJob(int priority, BuildingType buildingType, int energyRequired, int foodRequired) {
        this.priority = priority;
        this.buildingType = buildingType;
        this.energyRequired = energyRequired;
        this.foodRequired = foodRequired;
    }

    public override void DoJob()
    {
        // TODO Implement this
    }
}
