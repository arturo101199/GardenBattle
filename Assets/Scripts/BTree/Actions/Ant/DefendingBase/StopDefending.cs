public class StopDefending : BNode
{
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        globalBlackboard.UpdateValue("antsDefending", (int)globalBlackboard.GetValue("antsDefending") - 1);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}