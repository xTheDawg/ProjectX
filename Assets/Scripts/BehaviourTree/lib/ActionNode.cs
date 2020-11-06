public abstract class ActionNode : Node {

    /* Evaluates the node using the passed in delegate and 
     * reports the resulting state as appropriate */
    public override NodeStates Evaluate() {
        switch (execute()) {
            case NodeStates.SUCCESS:
                m_nodeState = NodeStates.SUCCESS;
                return m_nodeState;
            case NodeStates.FAILURE:
                m_nodeState = NodeStates.FAILURE;
                return m_nodeState;
            case NodeStates.RUNNING:
                m_nodeState = NodeStates.RUNNING;
                return m_nodeState;
            default:
                m_nodeState = NodeStates.FAILURE;
                return m_nodeState;
        }
    }

    public abstract NodeStates execute();

}
