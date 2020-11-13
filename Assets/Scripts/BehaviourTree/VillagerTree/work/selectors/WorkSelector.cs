public class WorkSelector : Selector
{
    public WorkSelector()
    {
        AddChild(new PickJobSequence());
        AddChild(new AddJobSelector());
    }
}
