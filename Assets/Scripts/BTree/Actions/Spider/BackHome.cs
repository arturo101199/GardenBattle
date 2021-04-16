using UnityEngine;
using UnityEngine.AI;

public class BackHome : BNode
{
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;
    Animator anim;
    [SerializeField] float distanceHome = 3.5f;

    void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        anim = (Animator)blackboard.GetValue("animator");
    }

    public override NodeState Evaluate()
    {
        Vector3 baseLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
        if (baseLocation != agent.destination)
        {
            agent.SetDestination(NavMeshUtilities.SamplePositionNearMe(transform.position, baseLocation));
            agent.isStopped = false;
            anim.SetBool("isMoving", true);
        }
        if (agent.remainingDistance <= distanceHome && !agent.pathPending)
        {
            agent.isStopped = true;
            anim.SetBool("isMoving", false);
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {

    }
}
