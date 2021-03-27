
public class IsEnemyBaseFoundCondition : Condition
{
    GlobalBlackboard globalBlackboard;
    Blackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override bool EvaluateCondition()
    {
        print((bool)globalBlackboard.GetValue("enemyBaseFound"));
        return (bool)globalBlackboard.GetValue("enemyBaseFound");
    }
}