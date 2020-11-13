using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Sequence : Node {
    // Contains all child nodes
    protected List<Node> nodes = new List<Node>();

     // Evaluate all child nodes. Only return FAILURE, when all child nodes failed
     // Only returns SUCCESS, when all child nodes succeeded.
    public override NodeState Evaluate() {
        bool anyChildRunning = false;
        
        foreach(Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeState.FAILURE:
                    nodeState = NodeState.FAILURE;
                    return nodeState;                    
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    anyChildRunning = true;
                    continue;
                default:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
            }
        }
        nodeState = anyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return nodeState;
    }

    public void AddChild(Node child) {
        this.nodes.Add(child);
        child.parent = this;
    }
}
