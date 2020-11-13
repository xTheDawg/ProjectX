public class EnergySelector : Selector
{
    public EnergySelector()
    {
        AddChild(new CheckEnergyAction());
        AddChild(new RestAction());
    }
}
