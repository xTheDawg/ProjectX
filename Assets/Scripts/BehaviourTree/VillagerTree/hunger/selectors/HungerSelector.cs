public class HungerSelector : Selector
{
    public HungerSelector()
    {
        AddChild(new CheckHungerBarAction());
        AddChild(new ReplenishHungerSelector());
    }
}
