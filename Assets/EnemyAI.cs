using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    // Reference to the points the enemy will patrol between.
    public Transform[] patrolPoints;
    private int currentPointIndex = 0;

    public float patrolSpeed = 1f;
    public float chaseSpeed = 2f;

    public float detectionRange;
    private bool detected = false;


    private bool lostPlayer;
    private float lostTimer = 10f;
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
        if (detectionRange > 50f)
        {
            detected = false;
            Patrol();
        }
        else if (detectionRange <= 50f)
        {
            detected = true;
            Chase();
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {

            // Set the enemy's destination to the points position.
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed*Time.deltaTime);
    }
}