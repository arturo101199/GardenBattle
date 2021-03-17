using System;
using UnityEngine;

public class AntGlobalBlackboard : GlobalBlackboard
{
    protected new static AntGlobalBlackboard instance;

    public new static AntGlobalBlackboard Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected override void initializeBlackboard()
    {
        base.initializeBlackboard();
        AddKeyValue("foodEaten", 0);
        AddKeyValue("antsPatrolling", 0);
        AddKeyValue("baseIsInDanger", false);
        AddKeyValue("currentEnemyBase", Vector3.zero);
        AddKeyValue("baseLocation", Vector3.zero);
        AddKeyValue("enemyBaseFound", false);
        AddKeyValue("antsDefending", 0);
    }
}
