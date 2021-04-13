using UnityEngine;
using UnityEngine.AI;

public class GoToATrapPoint : BNode
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        Vector3 nextTrapPoint = (Vector3)blackboard.GetValue("currentTrapPointLocation");
        agent.SetDestination(nextTrapPoint);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}
