using UnityEngine;

public class AntIsEnemyBaseDead : Condition
{
    BaseManager baseManager;
    Blackboard blackboard;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override bool EvaluateCondition()
    {
        if (baseManager.isBaseAlive((Vector3)globalBlackboard.GetValue("currentEnemyBase")))
            return false;
        return true;
    }
}