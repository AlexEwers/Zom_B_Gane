using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Cause we are using nav Mesh agent

public class EnemyPath : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatisGround, whatisPlayer;

    //Patrolling
    public Vector3 walkPoint;
    public float walkPointRange;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //For Following the path
    public Transform[] target;
    public float speed;

    private int current;
    private void Awake()
    {
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        print(playerInSightRange);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void Patroling()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}