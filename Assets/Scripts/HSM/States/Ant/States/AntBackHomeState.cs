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
        Vector3 positionToGo = NavMeshUtilities.SamplePositionNearMe(transform.position, currentEnemyBase);
        agent.SetDestination(positionToGo);
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
