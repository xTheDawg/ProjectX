public class AddJobSelector : Selector
{
    public AddJobSelector() {
            AddChild(new CheckResourcesStockAction());
            AddChild(new RequestBuildingAction());            
    }
}
