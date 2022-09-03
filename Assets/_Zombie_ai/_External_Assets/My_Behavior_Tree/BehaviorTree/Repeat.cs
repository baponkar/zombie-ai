using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : Node
{
    public Repeat(string name)
    {
        this.name = name;
    }
    
    public override Status Process()
    {
        return Status.Running;
    }
}

