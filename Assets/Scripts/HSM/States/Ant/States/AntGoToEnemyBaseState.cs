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
        Vector3 positionToGo = NavMeshUtilities.SamplePositionNearMe(transform.position, currentEnemyBase);
        agent.SetDestination(positionToGo);
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