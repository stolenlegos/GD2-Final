using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private ChasedState chaseState;
    [SerializeField]
    public CaptureState captureState;
    [SerializeField]
    private bool playerIsClose;
    [SerializeField]
    private bool selfCapture;

    //private Vector3 currentDestination;

    private float wanderRadius = 25;
    private float wanderTimer = 3;

    private Transform target;
    private float timer;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        timer = wanderTimer;
        //currentDestination = new Vector3(Random.Range(328f, 399f), 40f, Random.Range(492f, 561f));
        //navMeshAgent.destination = currentDestination;
    }

    public override State RunCurrentState()
    {
        if (playerIsClose)
        {
            Debug.Log("Begin Chased");
            return chaseState;
        }
        else if (selfCapture)
        {
            return captureState;
        }
        else
        {
            Debug.Log("Fuck");
            //StartCoroutine("Wander");

            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                navMeshAgent.SetDestination(newPos);
                timer = 0;
            }

            return this;
        }
    }


    /*IEnumerator Wander()
    {
        yield return new WaitForSeconds(3);
        if (Vector3.Distance(navMeshAgent.destination, currentDestination) < 5f)
        {
            Debug.Log("Changing Destination");
            for (int i = 0; i < 10; i++)
            {
                currentDestination = new Vector3(Random.Range(328f, 399f), 40f, Random.Range(492f, 561f));
                Debug.Log("CurrentDestination: " + currentDestination);
                /*NavMeshHit h;
                if (NavMesh.SamplePosition(currentDestination, out h, 5, 1))
                {
                    currentDestination = h.position;
                    break;
                }
            }

            if(navMeshAgent.destination.x >= 360f && navMeshAgent.destination.x <= 374f)
            {
                Debug.Log("New Destination fucked");
                float left = Random.Range(328f, 337f);
                float right = Random.Range(390f, 399f);
                currentDestination.x = Random.Range(left, right);            
            }
            if (navMeshAgent.destination.y >= 520f && navMeshAgent.destination.x <= 533f)
            {
                Debug.Log("New Destination also fucked");
                float up = Random.Range(550f, 560f);
                float down = Random.Range(492f, 501f);
                currentDestination.y = Random.Range(down, up);
            }
            navMeshAgent.SetDestination(currentDestination);

            yield return new WaitForSeconds(3);
            Debug.Log("New Destination: " + navMeshAgent.destination);
        }
    }*/

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsClose = true;
        }
        if (other.gameObject.tag == "Fence")
        {
            selfCapture = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsClose = false;
        }
        if (other.gameObject.tag == "Fence")
        {
            selfCapture = false;
        }
    }
}