public class Peasant {
    public int foodLevel {get; set;}
    public int energyLevel {get; set;}
    public int inventoryCapacity {get; set;}

    public RootSequence root {get; set;}

    public Peasant(int foodLevel, int energyLevel, int inventoryCapacity) {
        this.foodLevel = foodLevel;
        this.energyLevel = energyLevel;
        this.inventoryCapacity = inventoryCapacity;

        root = new RootSequence(this);
    }

    public void Work() {
        root.Evaluate();
    }
}
