using UnityEngine;
using UnityEngine.AI;

public class AntBackHomeState : State
{
    NavMeshAgent agent;

    protected override void Awake()
    {
        base.Awake();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override void OnStateEnter()
    {
        Vector3 currentEnemyBase = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
        Vector3 dirBaseToMe = (transform.position - currentEnemyBase).normalized;
        Vector3 positionToGo = currentEnemyBase + dirBaseToMe * 0.2f;
        NavMeshHit hit;
        NavMesh.SamplePosition(positionToGo, out hit, 3f, NavMesh.AllAreas);
        agent.SetDestination(hit.position);
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
}
