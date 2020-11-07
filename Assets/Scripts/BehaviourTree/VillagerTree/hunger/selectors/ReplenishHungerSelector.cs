    public class ReplenishHungerSelector : Selector
    {
        public ReplenishHungerSelector() {
            nodes.Add(new FetchFoodSequence());
            nodes.Add(new GatherFoodSequence());
        }
    }
