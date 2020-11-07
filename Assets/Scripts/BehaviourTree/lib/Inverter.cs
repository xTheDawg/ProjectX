using UnityEngine;
using System.Collections;

public class Inverter : Node {
    /* Child node to evaluate */
    protected Node m_node;

    /* The constructor requires the child node that this inverter  decorator
     * wraps*/
    public Inverter() {}

    /* Reports a success if the child fails and
     * a failure if the child succeeeds. Running will report
     * as running */
    public override NodeState Evaluate() {
        switch (m_node.Evaluate()) {
            case NodeState.FAILURE:
                m_nodeState = NodeState.SUCCESS;
                return m_nodeState;
            case NodeState.SUCCESS:
                m_nodeState = NodeState.FAILURE;
                return m_nodeState;
            case NodeState.RUNNING:
                m_nodeState = NodeState.RUNNING;
                return m_nodeState;
        }
        m_nodeState = NodeState.SUCCESS;
        return m_nodeState;
    }
}
