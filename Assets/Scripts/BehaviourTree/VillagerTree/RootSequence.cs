using UnityEngine;

public class RootSequence : Sequence
{
    Peasant peasant;

    public RootSequence(Peasant peasant)
    {
        this.peasant = peasant;
        AddChild(new EnergySelector());
        AddChild(new HungerSelector());
        AddChild(new WorkSelector());
    }
   
     // Returns actual peasant instance associated with this tree
     public override Peasant GetPeasant() {
        return this.peasant;
    }
}