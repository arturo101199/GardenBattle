using UnityEngine;

public class IsWeakCondition : Condition
{
    [SerializeField] bool isWeak;

    public override bool EvaluateCondition()
    {
        return isWeak;
    }
}