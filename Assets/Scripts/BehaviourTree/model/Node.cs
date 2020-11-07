public abstract class Node {
    // Contains current node state
    protected NodeState nodeState;

    // Used to evaluate the tree
    public abstract NodeState Evaluate();

}
