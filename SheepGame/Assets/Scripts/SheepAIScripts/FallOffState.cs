using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FallOffState : State
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private float catapult = 2f;
    private bool startcatapult = true;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    public override State RunCurrentState()
    {
        if (startcatapult)
        {
            Destroy(navMeshAgent);
            rb.AddForce(transform.forward * catapult);
            startcatapult = false;
        }
        return this;
    }
}
