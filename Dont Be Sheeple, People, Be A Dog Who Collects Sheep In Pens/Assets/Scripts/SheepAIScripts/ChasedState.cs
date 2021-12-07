using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasedState : State
{
    public CaptureState captureState;
    public WanderState wanderState;

    public bool captured;
    public bool escaped;

    public override State RunCurrentState()
    {
        if (captured)
        {
            return captureState;
        }
        else if (escaped)
        {
            return wanderState;
        }
        else
        {
            return this;
        }
    }

}
