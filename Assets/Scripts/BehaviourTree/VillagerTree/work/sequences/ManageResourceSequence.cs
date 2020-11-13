public class ManageResourceSequence : Sequence
{
    public ManageResourceSequence() {
            AddChild(new CheckResourceStockAction());
            AddChild(new RequestResourceAction());            
    }
}
