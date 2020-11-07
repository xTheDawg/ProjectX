public abstract class ActionNode : Node {

    // Evaluates action node state by executing the action.
    public override NodeState Evaluate() {
        switch (Execute()) {
            case NodeState.SUCCESS:
                nodeState = NodeState.SUCCESS;
                return nodeState;
            case NodeState.FAILURE:
                nodeState = NodeState.FAILURE;
                return nodeState;
            case NodeState.RUNNING:
                nodeState = NodeState.RUNNING;
                return nodeState;
            default:
                nodeState = NodeState.FAILURE;
                return nodeState;
        }
    }

    public abstract NodeState Execute();

}
