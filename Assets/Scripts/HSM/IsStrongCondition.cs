using UnityEngine;

public class IsStrongCondition : Condition
{
    int foodRequiredToBeStrong = 5;
    [SerializeField] bool desiredBool = true;

    public override bool EvaluateCondition()
    {
        return ((int)AntGlobalBlackboard.Instance.GetValue("foodEaten") >= foodRequiredToBeStrong) == desiredBool;
    }
}
