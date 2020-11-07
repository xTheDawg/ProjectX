public class GatherFoodSequence : Sequence
{
    public GatherFoodSequence() {
            nodes.Add(new RequestFoodAction());
            nodes.Add(new DoJobInverter());            
    }
}
