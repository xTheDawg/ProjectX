using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Selector : Node {
    // Contains all child nodes
    protected List<Node> nodes = new List<Node>();
    //This is used to remember the position of the current RUNNING Node
    private int runningIndex = 0;

    // Evaluate all child nodes. Only return FAILURE, when all child nodes failed
    public override NodeState Evaluate()
    {
        bool runningFailed = false;

        //Check if the last running Node still had the State RUNNING
        if (nodes[runningIndex].GetNodeState() == NodeState.RUNNING)
        {
            switch (nodes[runningIndex].Evaluate()) {
                case NodeState.FAILURE:
                    runningFailed = true;
                    break;
                case NodeState.SUCCESS:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
                case NodeState.RUNNING:
                    nodeState = NodeState.RUNNING;
                    return nodeState;
            }
        }

        //If a RUNNING Node Failed then continue on the next Node
        if (runningFailed)
        {
            for (int i = runningIndex + 1; i < nodes.Count; i++)
            {
                switch (nodes[runningIndex].Evaluate()) {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                    case NodeState.RUNNING:
                        nodeState = NodeState.RUNNING;
                        runningIndex = i;
                        return nodeState;
                    default:
                        continue;
                }
            }
        }
        //No Node was RUNNING so iterate from the beginning
        else
        {
            int i = 0;
            foreach (Node node in nodes) {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        i++;
                        continue;
                    case NodeState.SUCCESS:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                    case NodeState.RUNNING:
                        nodeState = NodeState.RUNNING;
                        runningIndex = i;
                        return nodeState;
                    default:
                        continue;
                }
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
