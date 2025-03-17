using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
public class EnemyManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public float chaseRadius = 5f;
    public float attackRadius = 3f;
    public float normalSpeed = 3.5f;
    public float chaseSpeed = 6f;

    public Animator animator;

    public NavMeshAgent agent;
    public Transform currentTarget;
    public bool isChasing = false;

    public float distanceToPlayer;
     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();    
        //agent.speed = 0;

        //StartPatrolling();

    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
    }
    //void Update()
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    //    if (distanceToPlayer <= chaseRadius)
    //    {
    //         Player detected, chase!

    //        isChasing = true;
    //        agent.speed = chaseSpeed;
    //        agent.SetDestination(player.position);
    //    }
    //    else
    //    {
    //        if (isChasing)
    //        {
    //             Player lost, resume patrol
    //            isChasing = false;

    //            agent.speed = normalSpeed;
    //            agent.SetDestination(currentTarget.position);
    //        }

    //         Patrol behavior when NOT chasing
    //        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
    //        {

    //             Switch target
    //            currentTarget = (currentTarget == pointA) ? pointB : pointA;
    //            agent.SetDestination(currentTarget.position);
    //        }
    //    }
    //}

    //async void StartPatrolling()
    //{
    //    await Task.Delay(10000);

    //    agent.speed = normalSpeed;
    //    currentTarget = pointA;
    //    agent.SetDestination(currentTarget.position);
    //}
    void OnDrawGizmos()
    {
        // Draw the chase radius in the scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius); 
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
