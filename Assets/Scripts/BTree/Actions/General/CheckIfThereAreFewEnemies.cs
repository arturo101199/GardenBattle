using UnityEngine;

public class CheckIfThereAreFewEnemies : BNode
{
    int minEnemies;
    int nAllies;
    GlobalBlackboard globalBlackboard;
    GameGlobalBlackboard gameGlobalBlackboard;

    [SerializeField] bool desiredBool = true;

    void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        gameGlobalBlackboard = GameGlobalBlackboard.Instance;
    }

    public override NodeState Evaluate()
    {
        nAllies = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        minEnemies = nAllies * 2;
        if (((int)gameGlobalBlackboard.GetValue("totalNumberOfCharacters") <= minEnemies) == desiredBool)
            return NodeState.SUCCESS;
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {

    }
}