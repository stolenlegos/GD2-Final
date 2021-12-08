using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;

    [SerializeField]
    public ChasedState chaseState;
    [SerializeField]
    public bool playerIsClose;

    public float moveSpeed = 1f;
    public float rotSpeed = 50f;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private Vector3 currentDestination;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        currentDestination = new Vector3(Random.Range(445f, 485f), 32f, Random.Range(465f, 500f));
        navMeshAgent.destination = currentDestination;
    }

    public override State RunCurrentState()
    {
        if (playerIsClose)
        {
            Debug.Log("Begin Chased");
            return chaseState;
        }
        else
        {
            if (Vector3.Distance(navMeshAgent.destination, currentDestination) < 0.2f)
            {
                Debug.Log("Changing Destination");
                for (int i = 0; i < 10; i++)
                {
                    currentDestination = new Vector3(Random.Range(445f, 485f), 32f, Random.Range(465f, 500f));
                    Debug.Log("CurrentDestination: " + currentDestination);
                    NavMeshHit h;
                    if (NavMesh.SamplePosition(currentDestination, out h, 10, 0))
                    {
                        currentDestination = h.position;
                        break;
                    }
                }
                navMeshAgent.SetDestination(currentDestination);

                Debug.Log("New Destination: " + navMeshAgent.destination);
            }

            return this;
        }
    }

}