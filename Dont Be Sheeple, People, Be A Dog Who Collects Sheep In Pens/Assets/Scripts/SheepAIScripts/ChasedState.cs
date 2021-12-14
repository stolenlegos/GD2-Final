using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasedState : State
{
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private CaptureState captureState;
    [SerializeField]
    private WanderState wanderState;
    [SerializeField]
    private FallOffState fallOffState;

    [SerializeField]
    private bool capturedChS;
    [SerializeField]
    private bool escapedChS;
    [SerializeField]
    private bool fallOff;

    //private float wanderRadius = 25;
    private float chaseTimer = .1f;
    private Transform target;
    private float timer;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        timer = chaseTimer;
    }

    public override State RunCurrentState()
    {
        if (fallOff)
        {
            return fallOffState;
        }
        else if (escapedChS)
        {
            //Debug.Log("ESCAPED");
            escapedChS = false;
            return wanderState;
        }
        else if (capturedChS)
        {
            capturedChS = false;
            return captureState;
        }
        else
        {
            //Debug.Log("Chasing");
            timer += Time.deltaTime;
            target = GameObject.FindGameObjectWithTag("Player").transform;

            if (timer >= chaseTimer)
            {
                Vector3 dirToPlayer = (transform.position - target.transform.position);
                Vector3 newPos = transform.position + dirToPlayer;
                navMeshAgent.SetDestination(newPos);
                timer = 0;
            }

            return this;
        }
    }

    /*public static Vector3 RandomChasePoint(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }*/

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            escapedChS = true;
        }
        if (other.gameObject.tag == "Boundary")
        {
            fallOff = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            escapedChS = true;
        }
        if (other.gameObject.tag == "Fence")
        {
            capturedChS = true;
        }
    }
}
