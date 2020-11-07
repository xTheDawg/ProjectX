public class WorkSelector : Selector
{
    public WorkSelector()
    {
        nodes.Add(new PickJobSequence());
        nodes.Add(new AddJobSelector());
    }
}
