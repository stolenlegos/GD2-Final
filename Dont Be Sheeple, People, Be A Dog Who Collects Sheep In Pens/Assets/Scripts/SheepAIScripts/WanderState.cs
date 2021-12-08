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

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponentInParent<NavMeshAgent>();
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
            StartCoroutine("Wander");
            if (isRotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            }
            if (isRotatingLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            }
            if(isWalking == true)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }

            navMeshAgent.destination = this.transform.position;
            return this;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        yield return new WaitForSeconds(.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            playerIsClose = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsClose = false;
        }
    }
}
