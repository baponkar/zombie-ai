using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string name)
    {
        this.name = name;
    }
    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();

        if (childStatus == Status.Running)
        {
            return Status.Running;
        }

        if(childStatus == Status.Success)
        {
            currentChild = 0;
            return Status.Success;
        }

        if (childStatus == Status.Failure)
        {
            currentChild++;
            if (currentChild >= children.Count)
            {
                currentChild = 0;
                return Status.Failure;
            }
            return Status.Running;
        }
        return Status.Success;
    }
}

