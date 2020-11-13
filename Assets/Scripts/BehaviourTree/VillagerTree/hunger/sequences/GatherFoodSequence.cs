public class GatherFoodSequence : Sequence
{
    public GatherFoodSequence() {
            AddChild(new RequestFoodAction());
            AddChild(new DoJobInverter());            
    }
}
