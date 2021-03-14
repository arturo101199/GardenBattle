using UnityEngine;

public class ItIsMyTurnToDefend : BNode
{
    [SerializeField] bool isMyTurnToDefend = false;

    public override NodeState Evaluate()
    {
        if (isMyTurnToDefend) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}