using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform playerTransform; 
    public float movementDelay = 5.0f; 
    private NavMeshAgent agent;
    private Vector3 targetPosition;    
    private bool canMove = false;      

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPosition = playerTransform.position;
        StartCoroutine(StartMovementAfterDelay());
    }

    IEnumerator StartMovementAfterDelay()
    {
        
        yield return new WaitForSeconds(movementDelay);
        
        
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            
            targetPosition = playerTransform.position;
            agent.destination = targetPosition;
        }
    }
}
