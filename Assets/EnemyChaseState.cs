using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : StateMachineBehaviour
{
    EnemyManager enemyManager;
    NavMeshAgent agent;
    Transform pointA, pointB, currentTarget, player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyManager = animator.GetComponent<EnemyManager>();
        agent = animator.GetComponent<NavMeshAgent>();
        player = enemyManager.player;
        agent.speed = 7;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToPlayer = enemyManager.distanceToPlayer;
        // Player detected, chase!
        Vector3 direction = player.transform.position;
        direction.y = 0; // Ensure the rotation is only on the horizontal plane
        if (direction.magnitude > 0.01f) // Check if the direction is valid
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = lookRotation;
        }
        agent.SetDestination(player.position);
        if (distanceToPlayer >= enemyManager.chaseRadius)
        {
            animator.SetBool("isChase", false);
            animator.SetBool("isPatrol", true);
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
