public class FetchFoodSequence : Sequence
{
    public FetchFoodSequence() {
            nodes.Add(new CheckFoodStockAction());
            nodes.Add(new EatAction());            
    }
}
