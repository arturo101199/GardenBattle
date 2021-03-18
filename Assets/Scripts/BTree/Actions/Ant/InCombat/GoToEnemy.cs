﻿using UnityEngine;
using UnityEngine.AI;

public class GoToEnemy : BNode
{
    float timer = 1f;
    float timeBetweenDestinations = 1f;
    [SerializeField] float stoppingDistance = 1.5f;
    NavMeshAgent agent;
    Transform enemy;
    bool firstTime = true;

    private void Start()
    {
        agent = (NavMeshAgent)blackboard.GetValue("navMeshAgent");
    }

    public override NodeState Evaluate()
    {
        if (firstTime)
        {
            agent.isStopped = false;
            enemy = (Transform)blackboard.GetValue("currentEnemy");
            Vector3 positionToGo = NavMeshUtilities.SamplePositionNearMe(transform.position, enemy.position);
            agent.SetDestination(positionToGo);
            firstTime = false;
        }
        if(agent.remainingDistance <= stoppingDistance)
        {
            return NodeState.SUCCESS;
        }
        if(timer >= timeBetweenDestinations)
        {
            agent.SetDestination(enemy.position);
        }
        return NodeState.RUNNING;
    }

    public override void OnTreeEnded()
    {
        firstTime = true;
        timer = 1f;
    }
}