using System;
using UnityEngine;
using UnityEngine.AI;

public class RangedDefendState : State
{
    NavMeshAgent agent;
    bool isRotated = false;
    Vector3 baseToMeDirection;
    Quaternion lookRotation;
    Vector3 baseLocation;
    GlobalBlackboard globalBlackboard;

    protected override void Awake()
    {
        base.Awake();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        baseLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        agent.isStopped = true;
        calculateRotation();
    }

    private void calculateRotation()
    {
        isRotated = false;
        baseToMeDirection = Vector3Utilities.GetDirectionXZFromTo(baseLocation, transform.position);
        lookRotation = Quaternion.LookRotation(baseToMeDirection);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        agent.isStopped = false;
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    protected override void makeUpdate()
    {
        if (isRotated && Vector3.Dot(agent.transform.forward, baseToMeDirection) > 0.997f)
        {
            isRotated = true;
        }
        else
            agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }
}
