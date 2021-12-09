using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaptureState : State
{
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private WanderState wanderState;
    [SerializeField]
    private bool escapedWS;

    private float captureRadius = 5;
    private float captureTimer = 2;

    private float timer;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        timer = captureTimer;
    }

    public override State RunCurrentState()
    {
        timer += Time.deltaTime;

        if (escapedWS)
        {
            return wanderState;
        }

        else
        {
            if (timer >= captureTimer)
            {
                Vector3 newPos = RandomCapSphere(transform.position, captureRadius, -1);
                navMeshAgent.SetDestination(newPos);
                timer = 0;
            }
            return this;
        }
    }

    public static Vector3 RandomCapSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Fence")
        {
            escapedWS = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fence")
        {
            escapedWS = false;
        }
    }
}
