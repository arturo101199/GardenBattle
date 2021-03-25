﻿using UnityEngine;
using UnityEngine.AI;

public class WaspBlackboard : Blackboard
{
    private void Awake()
    {
        initializeBlackboard();
    }

    void initializeBlackboard()
    {
        AddKeyValue("navMeshAgent", GetComponent<NavMeshAgent>());
        AddKeyValue("animator", GetComponentInChildren<Animator>());
        AddKeyValue("closerEnemyBase", Vector3.zero);
        AddKeyValue("health", 100f);
        AddKeyValue("currentEnemy", null);
    }
}