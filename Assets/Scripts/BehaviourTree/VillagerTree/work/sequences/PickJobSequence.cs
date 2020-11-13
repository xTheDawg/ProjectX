public class PickJobSequence : Sequence
{
    public PickJobSequence() {
            AddChild(new CheckJobListAction());
            AddChild(new DoJobAction());            
    }
}
