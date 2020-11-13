public class FetchFoodSequence : Sequence
{
    public FetchFoodSequence() {
            AddChild(new CheckFoodStockAction());
            AddChild(new EatAction());            
    }
}
