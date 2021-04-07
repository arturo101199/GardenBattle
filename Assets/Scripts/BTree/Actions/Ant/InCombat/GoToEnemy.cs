using UnityEngine;
using UnityEngine.AI;

public class GoToEnemy : BNode
{
    protected float timer = 1f;
    protected float timeBetweenDestinations = 1f;
    [SerializeField] protected float stoppingDistance = 1.5f;
    protected NavMeshAgent agent;
    protected Transform enemy;
    protected bool firstTime = true;

    protected void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if (firstTime)
        {
            agent.isStopped = false;
            enemy = (Transform)blackboard.GetValue("currentEnemy");
            if (enemy == null)
                return NodeState.FAIL;
            Vector3 positionToGo = NavMeshUtilities.SamplePositionNearMe(transform.position, enemy.position);
            agent.SetDestination(positionToGo);
            firstTime = false;
        }
        else
        {
            if (enemy == null)
                return NodeState.FAIL;
        }
        if(imNearTheEnemy())
        {
            return NodeState.SUCCESS;
        }
        if(timer >= timeBetweenDestinations)
        {
            agent.SetDestination(enemy.position);
            timer = 0f;
        }
        timer += Time.deltaTime;
        return NodeState.RUNNING;
    }

    protected virtual bool imNearTheEnemy()
    {
        return agent.remainingDistance <= stoppingDistance;
    }

    public override void OnTreeEnded()
    {
        firstTime = true;
        timer = 1f;
    }
}
