using UnityEngine;

public class InitialStateSelectorSimpleCondition : InitialStateSelector
{
    [SerializeField] Condition condition;
    [SerializeField] State stateTrue;
    [SerializeField] State stateFalse;

    public override State SelectInitialNode()
    {
        return condition.EvaluateCondition() ? stateTrue : stateFalse;
    }
}
