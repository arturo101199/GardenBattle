using UnityEngine;

public class StateSelectorSimpleCondition : StateSelector
{
    [SerializeField] Condition condition = null;
    [SerializeField] State stateTrue = null;
    [SerializeField] State stateFalse = null;

    public override State SelectNode()
    {
        return condition.EvaluateCondition() ? stateTrue : stateFalse;
    }
}
