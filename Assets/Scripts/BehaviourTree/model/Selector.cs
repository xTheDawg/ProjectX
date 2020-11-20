using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Selector : Node {
    // Contains all child nodes
    protected List<Node> nodes = new List<Node>();

    // Evaluate all child nodes. Only return FAILURE, when all child nodes failed
    public override NodeState Evaluate()
    {
        foreach (Node node in nodes)
        {
            if (node.GetNodeState() == NodeState.RUNNING)
            {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                    case NodeState.RUNNING:
                        nodeState = NodeState.RUNNING;
                        return nodeState;
                    default:
                        continue;
                }
            }
        }
        foreach (Node node in nodes) {
            switch (node.Evaluate()) {
                case NodeState.FAILURE:
                    continue;
                case NodeState.SUCCESS:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
                case NodeState.RUNNING:
                    nodeState = NodeState.RUNNING;
                    return nodeState;
                default:
                    continue;
            }
        }
        nodeState = NodeState.FAILURE;
        return nodeState;
    }

    public void AddChild(Node child) {
        this.nodes.Add(child);
        child.parent = this;
    }
}
