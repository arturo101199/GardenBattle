using UnityEngine;
using UnityEngine.AI;

public class FreezeState : State
{
    Freezeable freezeable;
    NavMeshAgent agent;
    [SerializeField] Transform turnAroundPivot = null;

    protected override void Awake()
    {
        base.Awake();
        freezeable = GetComponentInParent<Freezeable>();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        agent.isStopped = true;
        turnAround();

    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        freezeable.IsFrozen = false;
        agent.isStopped = false;
        turnAround();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    void turnAround()
    {
        turnAroundPivot.Rotate(0, 0, 180f);
        turnAroundPivot.Translate(0f, 0.5f, 0f, Space.Self);
    }
}