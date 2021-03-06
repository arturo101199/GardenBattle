﻿using UnityEngine;
using UnityEngine.AI;

public class AntBackHomeState : State
{
    NavMeshAgent agent;
    GlobalBlackboard globalBlackboard;
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        anim = (Animator)blackboard.GetValue("animator");
    }

    public override void OnStateEnter()
    {
        agent.isStopped = false;
        anim.SetBool("isMoving", true);
        Vector3 homeLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
        Vector3 positionToGo = NavMeshUtilities.SamplePositionNearMe(transform.position, homeLocation);
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
