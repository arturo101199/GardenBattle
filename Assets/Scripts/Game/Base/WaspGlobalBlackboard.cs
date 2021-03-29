using UnityEngine;

public class WaspGlobalBlackboard : GlobalBlackboard
{
    protected new static WaspGlobalBlackboard instance;

    public new static WaspGlobalBlackboard Instance { get => instance; }

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
        AddKeyValue("baseIsInDanger", false);
        AddKeyValue("currentEnemyBase", Vector3.zero);
        AddKeyValue("baseLocation", Vector3.zero);
        AddKeyValue("enemyBaseFound", false);
        AddKeyValue("maxHealth", 100f);
        AddKeyValue("attackDamage", 20f);
    }
}
