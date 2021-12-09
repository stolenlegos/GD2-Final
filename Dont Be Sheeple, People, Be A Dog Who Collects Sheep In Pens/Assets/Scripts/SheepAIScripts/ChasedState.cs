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
    private bool captured;
    [SerializeField]
    private bool escaped;

    //private float wanderRadius = 25;
    private float chaseTimer = 1;
    private Transform target;
    private float timer;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        timer = chaseTimer;
    }

    public override State RunCurrentState()
    {
        if (captured)
        {
            return captureState;
        }
        else if (escaped)
        {
            escaped = false;
            return wanderState;
        }
        else
        {
            Debug.Log("Chasing");
            timer += Time.deltaTime;
            target = GameObject.FindGameObjectWithTag("Player").transform;

            if (timer >= chaseTimer)
            {
                Vector3 newPos = (transform.position - target.transform.position);
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
            escaped = true;
        }
    }
}
