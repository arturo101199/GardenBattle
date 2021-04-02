using UnityEngine;
using UnityEngine.AI;

public class MeeleeDefendState : State
{
    float baseOffset = 3f;
    float stoppingDistance = 1f;
    float deltaAngle = 90f;

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
        setDestination();
        base.OnStateEnter();
    }

    void setDestination()
    {
        Vector3 basePos = (Vector3)globalBlackboard.GetValue("baseLocation");
        Vector3 dirToMe = (transform.position - basePos).normalized * baseOffset;
        Vector3 directionToMove = Quaternion.Euler(0, deltaAngle, 0) * dirToMe;
        Vector3 posToMove = basePos + directionToMove;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(posToMove, out hit, 3f, NavMesh.AllAreas))
            agent.SetDestination(hit.position);
        else
        {
            posToMove = basePos - directionToMove;
            if (NavMesh.SamplePosition(posToMove, out hit, 3f, NavMesh.AllAreas))
                agent.SetDestination(hit.position);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    protected override void makeUpdate()
    {
        if (agent.remainingDistance <= stoppingDistance)
            setDestination();
    }
}