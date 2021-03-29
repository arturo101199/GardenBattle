using UnityEngine;

public class ImStrongCondition : Condition
{
    int foodRequiredToBeStrong = 20;
    [SerializeField] bool desiredBool = true;

    private void Start()
    {
        foodRequiredToBeStrong = (int)AntGlobalBlackboard.Instance.GetValue("maxFood");
    }

    public override bool EvaluateCondition()
    {
        return ((int)AntGlobalBlackboard.Instance.GetValue("foodEaten") >= foodRequiredToBeStrong) == desiredBool;
    }
}