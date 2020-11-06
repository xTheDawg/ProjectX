public class RootSelector : Selector
{
    public RootSelector()
    {
        m_nodes.Add(new EnergySelector());
        m_nodes.Add(new HungerSelector());
        m_nodes.Add(new WorkSelector());
    }
}
