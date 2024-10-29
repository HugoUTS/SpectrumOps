using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform playerTransform;        // Reference to the player's transform
    private NavMeshAgent agent;              // Reference to the NavMeshAgent
    public float activationDistance = 5.0f;  // Distance within which the agent will start moving

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Check if the player transform exists
        if (playerTransform)
        {
            // Calculate the distance between the agent and the player
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Check if the player is within the activation distance
            if (distanceToPlayer <= activationDistance)
            {
                // Set the NavMeshAgent destination to the player's position
                agent.SetDestination(playerTransform.position);
            }
            else
            {
                // Optional: Stop the agent if the player is out of range
                //agent.ResetPath();
            }
        }
    }
}
