using UnityEngine;

public class AntImNearHomeCondition : Condition
{
    float distanceNear = 3f;

    public override bool EvaluateCondition()
    {
        return Vector3.Distance((Vector3)AntGlobalBlackboard.Instance.GetValue("baseLocation"), transform.position) <= distanceNear;
    }
}

