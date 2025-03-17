using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;
public class EnemyPatrolState : StateMachineBehaviour
{
    EnemyManager enemyManager;
    NavMeshAgent agent;
    Transform pointA, pointB,currentTarget,player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyManager = animator.GetComponent<EnemyManager>();
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 3.5f;
        pointA = enemyManager.pointA;
        pointB = enemyManager.pointB;
        player = enemyManager.player;
        agent.SetDestination(pointA.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public async void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyManager.distanceToPlayer <= enemyManager.chaseRadius)
        {
            animator.SetBool("isChase", true);
            animator.SetBool("isPatrol", false);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //Switch target
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
                enemyManager.currentTarget = currentTarget;
                animator.speed = 0;
                await Task.Delay(1000);
                GoToDestination();
            }
        }

        if (currentTarget == null) return;
        Vector3 direction = currentTarget.transform.position;
        if (agent.velocity.magnitude > 0.01f) // Check if the agent is moving
        {
            direction.y = 0; // Ensure the rotation is only on the horizontal plane
            if (direction.magnitude > 0.01f) // Check if the direction is valid
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                enemyManager.transform.rotation = lookRotation;
            }
        }
        void GoToDestination()
        {
            animator.speed = 1;
            agent.SetDestination(currentTarget.position);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
