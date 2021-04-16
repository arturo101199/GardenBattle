using UnityEngine;
using UnityEngine.AI;

public class GoToATrapPoint : BNode
{
    NavMeshAgent agent;
    Animator anim;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        anim = (Animator)blackboard.GetValue("animator");
    }

    public override NodeState Evaluate()
    {
        Vector3 nextTrapPoint = (Vector3)blackboard.GetValue("currentTrapPointLocation");
        agent.SetDestination(nextTrapPoint);
        agent.isStopped = false;
        anim.SetBool("isMoving", true);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}
