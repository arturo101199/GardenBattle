using UnityEngine;
using UnityEngine.AI;

public class CheckDistanceToNextPoint : BNode
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if (agent.remainingDistance < 1f || agent.remainingDistance == Mathf.Infinity)
            return NodeState.SUCCESS;
        else
            return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }

}