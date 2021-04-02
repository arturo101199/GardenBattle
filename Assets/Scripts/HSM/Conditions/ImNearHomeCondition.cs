using UnityEngine;

public class ImNearHomeCondition : Condition
{
    float distanceNear = 3f;
    Blackboard blackboard;
    GlobalBlackboard globalBlackboard;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override bool EvaluateCondition()
    {
        return Vector3.Distance((Vector3)globalBlackboard.GetValue("baseLocation"), transform.position) <= distanceNear;
    }
}