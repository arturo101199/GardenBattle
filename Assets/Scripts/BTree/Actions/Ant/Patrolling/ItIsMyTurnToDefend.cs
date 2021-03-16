using UnityEngine;

public class ItIsMyTurnToDefend : BNode
{


    public override NodeState Evaluate()
    {
        int nAnts = (int)AntGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters");
        int nAntsDefending = (int)AntGlobalBlackboard.Instance.GetValue("antsDefending");
        if (nAntsDefending < nAnts/2) return NodeState.SUCCESS;
        else return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
        
    }
}