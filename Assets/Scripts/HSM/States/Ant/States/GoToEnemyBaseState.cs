using UnityEngine;
using UnityEngine.AI;

public class GoToEnemyBaseState : State
{
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Vector3 currentEnemyBase = (Vector3)globalBlackboard.GetValue("currentEnemyBase");
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