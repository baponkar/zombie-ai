using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();
    public Tick processMethod;

    public Leaf() { }

    public Leaf(string name, Tick processMethod)
    {
        this.name = name;
        this.processMethod = processMethod;
    }
 

    public override Status Process()
    {
        if(processMethod != null)
        {
            return processMethod();
        }
        return Status.Failure;
    }
}
