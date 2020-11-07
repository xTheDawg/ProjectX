public class ManageResourceSequence : Sequence
{
    public ManageResourceSequence() {
            nodes.Add(new CheckResourceStockAction());
            nodes.Add(new RequestResourceAction());            
    }
}
