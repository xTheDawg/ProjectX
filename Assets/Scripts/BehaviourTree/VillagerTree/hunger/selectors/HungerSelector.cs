public class HungerSelector : Selector
{
    public HungerSelector()
    {
        nodes.Add(new CheckHungerBarAction());
        nodes.Add(new ReplenishHungerSelector());
    }
}
