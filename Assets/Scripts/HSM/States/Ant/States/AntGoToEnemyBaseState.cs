using UnityEngine;
using UnityEngine.AI;

public class AntGoToEnemyBaseState : State
{
    NavMeshAgent agent;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Vector3 currentEnemyBase = (Vector3)AntGlobalBlackboard.Instance.GetValue("currentEnemyBase");
        Vector3 dirBaseToMe = (transform.position - currentEnemyBase).normalized;
        Vector3 positionToGo = currentEnemyBase + dirBaseToMe * 0.2f;
        NavMeshHit hit;
        NavMesh.SamplePosition(positionToGo, out hit, 3f, NavMesh.AllAreas);
        agent.SetDestination(hit.position);
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