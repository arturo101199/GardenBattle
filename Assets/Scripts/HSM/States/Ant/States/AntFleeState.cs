using UnityEngine;
using UnityEngine.AI;

public class AntFleeState : State
{
    NavMeshAgent agent = null;
    float deltaMovement = 3f;
    float stoppingdistance = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        setDestinationToBase();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        
    }

    void setDestinationToBase()
    {
        Vector3 baseLocation = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
        Vector3 dirToBase = (baseLocation - transform.position).normalized;
        NavMeshHit hit;
        Vector3 posToMove = (dirToBase * deltaMovement) + transform.position;
        if (NavMesh.SamplePosition(posToMove, out hit, 3f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
        else
        {
            print("I could not flee");
        }
    }

    protected override void makeUpdate()
    {
        if (agent.remainingDistance <= stoppingdistance)
            setDestinationToBase();
    }
}