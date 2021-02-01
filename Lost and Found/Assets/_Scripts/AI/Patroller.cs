using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patroller : MonoBehaviour
{
    public Transform[] points = null;
    private int destPoint = 0;
    private NavMeshAgent agent;


    public void Initialise()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    private void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        //RotateEnemy();
    }

    private void RotateEnemy()
    {
        Vector3 lookAtVector = Camera.main.transform.position;
        lookAtVector.y = transform.position.y;
        transform.LookAt(lookAtVector);
    }
}