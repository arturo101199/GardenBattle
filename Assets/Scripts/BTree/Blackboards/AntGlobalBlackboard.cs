using System;
using UnityEngine;

public class AntGlobalBlackboard : GlobalBlackboard
{
    protected new static AntGlobalBlackboard instance;

    public new static AntGlobalBlackboard Instance { get => instance; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public override void InitializeBlackboard()
    {
        base.InitializeBlackboard();
        AddKeyValue("foodEaten", 0);
        AddKeyValue("antsPatrolling", 0);
        AddKeyValue("baseIsInDanger", false);
        AddKeyValue("currentEnemyBase", Vector3.zero);
        AddKeyValue("baseLocation", Vector3.zero);
        AddKeyValue("enemyBaseFound", false);
        AddKeyValue("antsDefending", 0);
        AddKeyValue("maxHealth", 100f);
        AddKeyValue("attackDamage", 5f);
        AddKeyValue("minAttackDamage", 5f);
        AddKeyValue("maxAttackDamage", 30f);
        AddKeyValue("maxFood", 20);
    }
}
