    public class ReplenishHungerSelector : Selector
    {
        public ReplenishHungerSelector() {
            m_nodes.Add(new FetchFoodSequence());
            m_nodes.Add(new GatherFoodSequence());
        }
    }
