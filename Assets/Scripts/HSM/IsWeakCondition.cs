using UnityEngine;

public class IsWeakCondition : Condition
{
    [SerializeField] bool isWeak = false;

    public override bool EvaluateCondition()
    {
        return isWeak;
    }
}