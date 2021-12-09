using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaptureState : State
{
    [SerializeField]
    public WanderState wanderState;
    [SerializeField]
    public bool escaped;


    private void Awake()
    {
        //navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        //timer = wanderTimer;
    }

    public override State RunCurrentState()
    {
        return this;
    }
}
