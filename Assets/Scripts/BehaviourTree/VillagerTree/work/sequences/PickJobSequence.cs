public class PickJobSequence : Sequence
{
    public PickJobSequence() {
            nodes.Add(new CheckJobListAction());
            nodes.Add(new DoJobAction());            
    }
}
