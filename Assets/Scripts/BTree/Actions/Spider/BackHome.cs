using UnityEngine;
using UnityEngine.AI;

public class BackHome : BNode
{
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;
    [SerializeField] float distanceHome = 3.5f;

    void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        Vector3 baseLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
        if (baseLocation != agent.destination)
            agent.SetDestination(NavMeshUtilities.SamplePositionNearMe(transform.position, baseLocation));
        if (Vector3.Distance(transform.position, baseLocation) <= distanceHome)
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        agent.isStopped = false;
    }
}
