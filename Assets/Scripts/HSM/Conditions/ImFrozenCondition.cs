public class ImFrozenCondition : Condition
{
    Freezeable freezeable;

    private void Awake()
    {
        freezeable = GetComponentInParent<Freezeable>();
    }

    public override bool EvaluateCondition()
    {
        return freezeable.IsFrozen;
    }
}
