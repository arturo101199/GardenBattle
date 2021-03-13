using UnityEngine;
using UnityEngine.AI;

public class CheckFood : BNode
{
    [SerializeField] float distanceToEat = 5f;
    NavMeshAgent agent;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if(agent.remainingDistance <= distanceToEat)
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}