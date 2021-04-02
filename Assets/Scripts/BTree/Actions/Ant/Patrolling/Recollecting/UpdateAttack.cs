using UnityEngine;

public class UpdateAttack : BNode
{
    float maxAttackDamage;
    float minAttackDamage;
    int maxFood;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        maxAttackDamage = (float)globalBlackboard.GetValue("maxAttackDamage");
        minAttackDamage = (float)globalBlackboard.GetValue("minAttackDamage");
        maxFood = (int)globalBlackboard.GetValue("maxFood");
    }

    public override NodeState Evaluate()
    {
        int foodEaten = (int)globalBlackboard.GetValue("foodEaten");
        float t = Mathf.InverseLerp(0, maxFood, foodEaten);
        float attackDamage = Mathf.Lerp(minAttackDamage, maxAttackDamage, t);
        globalBlackboard.UpdateValue("attackDamage", attackDamage);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}
