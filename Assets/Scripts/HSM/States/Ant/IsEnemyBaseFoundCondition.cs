
public class IsEnemyBaseFoundCondition : Condition
{
    GlobalBlackboard globalBlackboard;
    Blackboard blackboard;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        print(globalBlackboard + " " + transform.root.GetInstanceID());
    }

    public override bool EvaluateCondition()
    {
        return (bool)globalBlackboard.GetValue("enemyBaseFound");
    }
}