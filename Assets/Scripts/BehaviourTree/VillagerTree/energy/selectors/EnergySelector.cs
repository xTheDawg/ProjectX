public class EnergySelector : Selector
{
    public EnergySelector()
    {
        nodes.Add(new CheckEnergyAction());
        nodes.Add(new RestAction());
    }
}
