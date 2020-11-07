using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Sequence : Node {
    /** Chiildren nodes that belong to this sequence */
    protected List<Node> m_nodes = new List<Node>();

    /** Must provide an initial set of children nodes to work */
    public Sequence() {}

    /* If any child node returns a failure, the entire node fails. Whence all 
     * nodes return a success, the node reports a success. */
    public override NodeState Evaluate() {
        bool anyChildRunning = false;
        
        foreach(Node node in m_nodes) {
            switch (node.Evaluate()) {
                case NodeState.FAILURE:
                    m_nodeState = NodeState.FAILURE;
                    return m_nodeState;                    
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    m_nodeState = NodeState.SUCCESS;
                    return m_nodeState;
            }
        }
        m_nodeState = anyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return m_nodeState;
    }
}
