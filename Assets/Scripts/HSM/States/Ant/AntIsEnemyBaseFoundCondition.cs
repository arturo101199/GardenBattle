public class AntIsEnemyBaseFoundCondition : Condition
{
    public override bool EvaluateCondition()
    {
        return (bool)AntGlobalBlackboard.Instance.GetValue("enemyBaseFound");
    }
}