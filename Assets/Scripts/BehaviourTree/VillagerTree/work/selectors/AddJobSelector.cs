public class AddJobSelector : Selector
{
    public AddJobSelector() {
            AddChild(new ManageResourceSequence());
            AddChild(new RequestBuildingAction());            
    }
}
