public class AddJobSelector : Selector
{
    public AddJobSelector() {
            nodes.Add(new ManageResourceSequence());
            nodes.Add(new RequestBuildingAction());            
    }
}
