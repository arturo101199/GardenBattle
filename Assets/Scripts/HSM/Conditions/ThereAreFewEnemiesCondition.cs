using UnityEngine;

public class ThereAreFewEnemiesCondition : Condition
{
    int minEnemies;
    int nAllies;
    GlobalBlackboard globalBlackboard;
    GameGlobalBlackboard gameGlobalBlackboard;
    Blackboard blackboard;

    [SerializeField] bool desiredBool = true;

    private void Awake()
    {
        blackboard = GetComponent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        gameGlobalBlackboard = GameGlobalBlackboard.Instance;
    }

    public override bool EvaluateCondition()
    {
        nAllies = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        minEnemies = nAllies * 2;
        int nTotalCharacters = (int)gameGlobalBlackboard.GetValue("totalNumberOfCharacters");
        return (nTotalCharacters <= minEnemies) == desiredBool;

    }
}

