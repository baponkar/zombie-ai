using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Node
{
    public float duration = 1f;
    float startTime;

    public Wait(string name)
    {
        this.name = name;
    }
    
    public override Status Process()
    {
        if (Time.time - startTime > duration)
        {
            return Status.Success;
        }
        return Status.Running;
    }

}
