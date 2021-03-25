public class AntIsEnemyBaseFoundCondition : Condition
{
    GlobalBlackboard globalBlackboard;
    Blackboard blackboard;

    private void Start()
    {
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override bool EvaluateCondition()
    {
        return (bool)globalBlackboard.GetValue("enemyBaseFound");
    }
}