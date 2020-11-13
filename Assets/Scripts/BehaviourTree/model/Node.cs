using UnityEngine;
public abstract class Node {
    // Contains current node state
    protected NodeState nodeState;

    public Node parent {get; set;}

    // Used to evaluate the tree
    public abstract NodeState Evaluate();


    // Invoke Get Peasant method of parent node until root node is reached
     public virtual Peasant GetPeasant() {
        return this.parent.GetPeasant();
    }
}
