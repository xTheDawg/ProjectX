using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class Sequence : Node {
    // Contains all child nodes
    protected List<Node> nodes = new List<Node>();
    private int runningIndex = 0;

    // Evaluate all child nodes. Only return FAILURE, when all child nodes failed
     // Only returns SUCCESS, when all child nodes succeeded.
    public override NodeState Evaluate() {
        bool anyChildRunning = false;
        int i = 0;
        
        
        if (nodes[runningIndex].GetNodeState() == NodeState.RUNNING)
        {
            switch (nodes[runningIndex].Evaluate()) {
                case NodeState.FAILURE:
                    nodeState = NodeState.FAILURE;
                    return nodeState;                    
                case NodeState.SUCCESS:
                    anyChildRunning = false;
                    break;
                case NodeState.RUNNING:
                    anyChildRunning = true;
                    break;
                default:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
            }
        }

        if (!anyChildRunning)
        {
            foreach(Node node in nodes) {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        nodeState = NodeState.FAILURE;
                        return nodeState;                    
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildRunning = true;
                        runningIndex = i;
                        continue;
                    default:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                }

                i++;
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
