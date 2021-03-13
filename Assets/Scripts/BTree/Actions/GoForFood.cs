using UnityEngine;
using UnityEngine.AI;

public class GoForFood : BNode
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        Vector3 nextFood = (Vector3)blackboard.GetValue("currentFoodLocation");
        agent.SetDestination(nextFood);
        print("SetDestination");
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}