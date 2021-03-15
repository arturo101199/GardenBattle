public class IsStrongCondition : Condition
{
    int foodRequiredToBeStrong = 20;

    public override bool EvaluateCondition()
    {
        return (int)AntGlobalBlackboard.Instance.GetValue("foodEaten") >= foodRequiredToBeStrong;
    }
}
