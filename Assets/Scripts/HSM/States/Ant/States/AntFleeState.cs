using UnityEngine;
using UnityEngine.AI;

public class AntFleeState : State
{
    NavMeshAgent agent = null;
    float deltaMovement = 3f;
    float stoppingdistance = 0.5f;

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
        if (agent.remainingDistance <= stoppingdistance)
            setDestinationToBase();
    }

    void setDestinationToBase()
    {
        Vector3 baseLocation = (Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation");
        Vector3 dirToBase = (baseLocation - transform.position).normalized;
        NavMeshHit hit;
        Vector3 posToMove = (dirToBase * deltaMovement) + transform.position;
        if (NavMesh.SamplePosition(posToMove, out hit, 3f, NavMesh.AllAreas))
            agent.SetDestination(posToMove);
        else
        {
            print("I could not flee");
        }
    }
}