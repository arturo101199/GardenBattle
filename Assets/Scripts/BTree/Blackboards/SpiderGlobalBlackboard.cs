using UnityEngine;

public class SpiderGlobalBlackboard : GlobalBlackboard
{
    protected new static SpiderGlobalBlackboard instance;

    public new static SpiderGlobalBlackboard Instance { get => instance; }

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
        AddKeyValue("baseIsInDanger", false);
        AddKeyValue("currentEnemyBase", Vector3.zero);
        AddKeyValue("baseLocation", Vector3.zero);
        AddKeyValue("enemyBaseFound", false);
        AddKeyValue("maxHealth", 100f);
        AddKeyValue("attackDamage", 15f);
    }
}
