using UnityEngine;
using UnityEngine.AI;

public class AntBackHomeState : State
{
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;

    protected override void Awake()
    {
        base.Awake();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override void OnStateEnter()
    {
        Vector3 currentEnemyBase = (Vector3)globalBlackboard.GetValue("baseLocation");
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
