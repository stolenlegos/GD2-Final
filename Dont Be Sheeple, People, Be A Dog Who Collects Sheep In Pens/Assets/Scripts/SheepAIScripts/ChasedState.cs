using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasedState : State
{
    [SerializeField]
    public CaptureState captureState;
    [SerializeField]
    public WanderState wanderState;

    [SerializeField]
    public bool captured;
    [SerializeField]
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
