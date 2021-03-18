public class StopDefending : BNode
{
    public override NodeState Evaluate()
    {
        AntGlobalBlackboard.Instance.UpdateValue("antsDefending", (int)AntGlobalBlackboard.Instance.GetValue("antsDefending") - 1);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {

    }
}