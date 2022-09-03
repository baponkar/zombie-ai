using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : Node
{
    public BehaviorTree()
    {
        name = "Tree";
    }

    public BehaviorTree(string name)
    {
        this.name = name;
    }

    public override Status Process()
    {
        return children[currentChild].Process();
    }




    struct NodeLevel
    {
        public int level;
        public Node node;
    }

    public void PrintTree()
    {
        string treePrintOut = "";
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
        Node currentNode = this;

        nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

        while(nodeStack.Count > 0)
        {
            NodeLevel nextNode = nodeStack.Pop();
            treePrintOut += new string('-',nextNode.level) + nextNode.node.name + "\n";

            for (int i = nextNode.node.children.Count - 1; i >= 0; i--)
            {
                nodeStack.Push(new NodeLevel {level = nextNode.level + 1 ,node = nextNode.node.children[i]});
            }
        }
        Debug.Log(treePrintOut);
    }
}
