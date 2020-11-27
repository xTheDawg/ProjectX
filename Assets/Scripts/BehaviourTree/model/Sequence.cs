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

        if (nodes[runningIndex].GetNodeState() == NodeState.RUNNING)
        {
            switch (nodes[runningIndex].Evaluate()) {
                case NodeState.FAILURE:
                    nodeState = NodeState.FAILURE;
                    runningIndex = 0;
                    return nodeState;                    
                case NodeState.SUCCESS:
                    runningIndex++;
                    break;
                case NodeState.RUNNING:
                    nodeState = NodeState.RUNNING;
                    return nodeState;
                default:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
            }
        }


        for (int i = runningIndex; i < nodes.Count; i++)
        {
            switch (nodes[i].Evaluate()) {
                case NodeState.FAILURE:
                    nodeState = NodeState.FAILURE;
                    return nodeState;                    
                case NodeState.SUCCESS:
                    continue;
                case NodeState.RUNNING:
                    nodeState = NodeState.RUNNING;
                    runningIndex = i;
                    return nodeState;
                default:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
            }
        }

        nodeState = NodeState.SUCCESS;
        runningIndex = 0;
        return nodeState;
    }

    public void AddChild(Node child) {
        this.nodes.Add(child);
        child.parent = this;
    }
}
