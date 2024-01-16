using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAi : MonoBehaviour
{
    public NavMeshAgent agent;  // Reference to the NavMeshAgent component for navigation.

    public Transform player;  // Reference to the player's transform.

    public LayerMask whatIsGround, whatIsPlayer;  // Layer masks for identifying ground and player.

    // Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float WalkPointRange;  // Range for selecting random patrol points.

    public Transform centrePoint;  // Center point for random patrol destinations.

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;
    public GameObject MeleeBox;  // Melee attack hitbox.

    // States
    public float sightRange, attackRange;  // Detection ranges for sight and attack.
    public bool playerInSightRange, playerInAttackRange;  // Flags indicating player presence in sight and attack ranges.

    private void Awake()
    {
        player = GameObject.Find("Player").transform;  // Find the player's transform.
        agent = GetComponent<NavMeshAgent>();  // Get the NavMeshAgent component on this GameObject.
    }

    // Update is called once per frame
    void Update()
    {
        // Check Sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
            Patroling();  // Patrol if the player is neither in sight nor in attack range.
        if (playerInSightRange && !playerInAttackRange)
            ChasePlayer();  // Chase the player if in sight but not in attack range.
        if (playerInAttackRange && playerInSightRange)
            AttackPlayer();  // Attack the player if in both sight and attack range.
    }

    private void Patroling()
    {
        // Check if the agent has reached its destination
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            // Generate a random point within a specified range around a center point
            if (RandomPoint(centrePoint.position, WalkPointRange, out point))
            {
                walkPointSet = true;
                // Draw a debug ray to visualize the selected random point
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                // Set the agent's destination to the random point
                agent.SetDestination(point);
            }
            walkPointSet = false;
        }
    }

    // Generate a random point within a specified range on the NavMesh
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        // Check if the random point is on the NavMesh and get the closest valid position
        if (NavMesh.SamplePosition(randomPoint, out hit, 25.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    // Search for a random walk point within a certain range around the enemy
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        // Set a new walk point based on the random X and Z values
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Check if the walk point is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    // Set the agent's destination to the player's position for chasing
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    // Set the agent's destination to its own position and attack the player
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        // Make the enemy face the player
        transform.LookAt(player);

        // Check if the enemy can attack and initiate the attack
        if (!alreadyAttack)
        {
            StartCoroutine(MeleeTimeBox());
            alreadyAttack = true;
            // Reset the attack after a specified time
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    // Coroutine to activate and deactivate the melee attack box
    IEnumerator MeleeTimeBox()
    {
        MeleeBox.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        MeleeBox.SetActive(false);
    }

    // Reset the attack state after a specified time
    private void ResetAttack()
    {
        alreadyAttack = false;
    }

    // Visualize attack and sight ranges in the Unity editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
