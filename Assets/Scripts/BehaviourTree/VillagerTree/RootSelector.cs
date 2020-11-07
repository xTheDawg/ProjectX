public class RootSequence : Sequence
{
    public RootSequence()
    {
        nodes.Add(new EnergySelector());
        nodes.Add(new HungerSelector());
        nodes.Add(new WorkSelector());
    }
}
