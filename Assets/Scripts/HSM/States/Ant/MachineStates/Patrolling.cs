﻿using UnityEngine;
using UnityEngine.AI;

public class Patrolling : SubMachineState
{
    Animator anim;
    NavMeshAgent agent;

    protected override void Awake()
    {
        base.Awake();
        anim = (Animator)blackboard.GetValue("animator");
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override void OnStateEnter()
    {
        anim.SetBool("isMoving", true);
        agent.isStopped = false;
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