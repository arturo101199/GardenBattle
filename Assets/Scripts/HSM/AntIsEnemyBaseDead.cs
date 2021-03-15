using UnityEngine;

public class AntIsEnemyBaseDead : Condition
{
    BaseManager baseManager;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
    }

    public override bool EvaluateCondition()
    {
        if (baseManager.isBaseAlive((Vector3)AntGlobalBlackboard.Instance.GetValue("currentEnemyBase")))
            return false;
        return true;
    }
}