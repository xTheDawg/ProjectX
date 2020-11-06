public abstract class ActionNode : Node {

    /* Evaluates the node using the passed in delegate and 
     * reports the resulting state as appropriate */
    public override NodeState Evaluate() {
        switch (execute()) {
            case NodeState.SUCCESS:
                m_nodeState = NodeState.SUCCESS;
                return m_nodeState;
            case NodeState.FAILURE:
                m_nodeState = NodeState.FAILURE;
                return m_nodeState;
            case NodeState.RUNNING:
                m_nodeState = NodeState.RUNNING;
                return m_nodeState;
            default:
                m_nodeState = NodeState.FAILURE;
                return m_nodeState;
        }
    }

    public abstract NodeState execute();

}
