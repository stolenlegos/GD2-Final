using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureState : State
{
    [SerializeField]
    public WanderState wanderState;
    [SerializeField]
    public bool escaped;

    public override State RunCurrentState()
    {
        return this;
    }
}
