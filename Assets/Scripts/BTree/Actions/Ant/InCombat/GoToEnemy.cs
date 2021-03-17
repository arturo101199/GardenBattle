using UnityEngine;
using UnityEngine.AI;

public class GoToEnemy : BNode
{
    float timer = 1f;
    float timeBetweenDestinations = 1f;
    [SerializeField] float stoppingDistance = 0.5f;
    NavMeshAgent agent;
    Transform enemy;
    bool firstTime = true;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("NavMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if (firstTime)
        {
            enemy = (Transform)blackboard.GetValue("currentEnemy");
            firstTime = false;
        }
        if(agent.remainingDistance <= stoppingDistance)
        {
            return NodeState.SUCCESS;
        }
        if(timer >= timeBetweenDestinations)
        {
            agent.SetDestination(enemy.position);
        }
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        firstTime = true;
        timer = 1f;
    }
}