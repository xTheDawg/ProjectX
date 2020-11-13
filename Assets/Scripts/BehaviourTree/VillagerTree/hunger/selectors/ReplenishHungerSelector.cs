    public class ReplenishHungerSelector : Selector
    {
        public ReplenishHungerSelector() {
            AddChild(new FetchFoodSequence());
            AddChild(new GatherFoodSequence());
        }
    }
