using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public ChasedState chaseState;
    public bool playerIsClose;

    public override State RunCurrentState()
    {
        if (playerIsClose)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

}
