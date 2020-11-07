public class RootSequence : Sequence
{
    public RootSequence()
    {
        m_nodes.Add(new EnergySelector());
        m_nodes.Add(new HungerSelector());
        m_nodes.Add(new WorkSelector());
    }
}
