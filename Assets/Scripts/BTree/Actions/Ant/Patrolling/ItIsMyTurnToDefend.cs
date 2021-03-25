using UnityEngine;

public class ItIsMyTurnToDefend : BNode
{
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override NodeState Evaluate()
    {
        int nAnts = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        int nAntsDefending = (int)globalBlackboard.GetValue("antsDefending");
        if (nAntsDefending < nAnts/2) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}