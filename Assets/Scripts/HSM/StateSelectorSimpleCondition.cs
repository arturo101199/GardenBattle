using UnityEngine;

public class StateSelectorSimpleCondition : StateSelector
{
    [SerializeField] Condition condition;
    [SerializeField] State stateTrue;
    [SerializeField] State stateFalse;

    public override State SelectNode()
    {
        return condition.EvaluateCondition() ? stateTrue : stateFalse;
    }
}
