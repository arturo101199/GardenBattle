using UnityEngine;

public class WaspImNearHomeCondition : Condition
{
    float distanceNear = 3f;

    public override bool EvaluateCondition()
    {
        return Vector3.Distance((Vector3)WaspGlobalBlackboard.Instance.GetValue("baseLocation"), transform.position) <= distanceNear;
    }
}