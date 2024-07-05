//Name: Dzann Ku Xin Hui
//File Name: EnemyAi.cs
//File Desc: Controls the behavior of an enemy AI in the game, including patrolling, chasing, and attacking the player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent; // navMeshAgent component for navigation
    public Transform player; // Reference to the player
    public LayerMask whatIsGround, whatIsPlayer; // Layers for ground and player detection

    [Header("Patrolling")]
    public Vector3 walkPoint; // Target point for patrolling
    bool walkPointSet; // Whether a walk point is set
    public float walkPointRange; // Range within which to set walk points

    [Header("Attacking")]
    public float timeBetweenAttacks; // Time between attacks
    bool alreadyAttacked; // Whether the enemy has already attacked
    public int attackDamage; // Amount of damage enemy does

    [Header("States")]
    public float sightRange, attackRange; // Ranges for sight and attack
    public bool playerInSightRange, playerInAttackRange; // Whether player is in sight or attack range

    [Header("Enemy Health")]
    public int health; // Enemy health

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find player by tag
        agent = GetComponent<NavMeshAgent>(); // Get NavMeshAgent component
    }

    private void Update()
    {
        // Check for player in sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling(); // Patrol if player is not in sight or attack range
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer(); // chase player if in sight range but not attack range
        }

        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer(); // Attack player if in both sight and attack range
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint(); // find a new walk point if not set
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint); // move to the walk point
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Check if reached walk point
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false; // Reset walk point if reached
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; // Set walk point if on ground
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position); // Move towards player
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position); // Stop moving

        transform.LookAt(player); // Face player

        if (!alreadyAttacked)
        {
            // Damage player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage); // Apply damage to player
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); // Reset attack after a delay
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false; // Allow attacking again
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f); // Destroy enemy after delay if health is 0 or lesss
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject); // Destroy enemy object
    }

    private void Start()
    {

    }
}