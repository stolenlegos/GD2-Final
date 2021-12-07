using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureState : State
{
    public WanderState wanderState;
    public bool escaped;

    public override State RunCurrentState()
    {
        return this;
    }
}
