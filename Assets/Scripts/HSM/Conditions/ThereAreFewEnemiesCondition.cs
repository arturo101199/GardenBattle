using UnityEngine;

public class ThereAreFewEnemiesCondition : Condition
{
    int minEnemies;
    int nAllies;
    GlobalBlackboard globalBlackboard;
    GameGlobalBlackboard gameGlobalBlackboard;
    Blackboard blackboard;

    [SerializeField] bool desiredBool = true;
    [Tooltip("How many enemies have to be respect to your troops, i.e, a value of 1 means that it has to be the same number as your troops to be considered few enemies")]
    [SerializeField] float fewEnemiesMultiplier = 1;

    private void Awake()
    {
        blackboard = GetComponentInParent<Blackboard>();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        gameGlobalBlackboard = GameGlobalBlackboard.Instance;
    }

    public override bool EvaluateCondition()
    {
        nAllies = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        minEnemies = nAllies +  (int)(nAllies * fewEnemiesMultiplier);
        int nTotalCharacters = (int)gameGlobalBlackboard.GetValue("totalNumberOfCharacters");
        return (nTotalCharacters <= minEnemies) == desiredBool;

    }
}

