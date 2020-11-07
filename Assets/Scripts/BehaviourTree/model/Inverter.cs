using UnityEngine;
using System.Collections;

public class Inverter : Node {
    // Child node whose result is inverted
    protected Node node;

    // Inverts given node state.
    // SUCCESS -> FAILURE
    // FAILURE -> SUCCESS
    public override NodeState Evaluate() {
        switch (node.Evaluate()) {
            case NodeState.FAILURE:
                nodeState = NodeState.SUCCESS;
                return nodeState;
            case NodeState.SUCCESS:
                nodeState = NodeState.FAILURE;
                return nodeState;
            case NodeState.RUNNING:
                nodeState = NodeState.RUNNING;
                return nodeState;
        }
        nodeState = NodeState.SUCCESS;
        return nodeState;
    }
}
