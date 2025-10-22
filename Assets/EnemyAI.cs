using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Reference to the points the enemy will patrol between.
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    // Reference to the NavMeshAgent component for pathfinding.
    private NavMeshAgent agent;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the NavMeshAgent component attached to this object.
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.SetDestination(patrolPoints[currentPointIndex].position);
    }

    // Update is called once per frame.
    void Update()
    {
        // If there's a reference to the player...
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {

            // Set the enemy's destination to the points position.
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
}