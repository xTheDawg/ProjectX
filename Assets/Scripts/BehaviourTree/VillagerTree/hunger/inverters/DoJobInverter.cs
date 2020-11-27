public class DoJobInverter : Inverter
{
    public DoJobInverter()
    {
        AddChild(new DoJobAction());
    }
}
