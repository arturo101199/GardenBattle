using UnityEngine;

public class DieState : State
{
    [SerializeField] GameObject parent = null;
    GlobalBlackboard globalBlackboard;

    protected override void Awake()
    {
        base.Awake();
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        ModifyCharactersNumberOnBlackboards();
        Destroy(parent);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    void ModifyCharactersNumberOnBlackboards()
    {
        int numberOfGlobalCharacters = (int)GameGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters");
        GameGlobalBlackboard.Instance.UpdateValue("totalNumberOfCharacters", numberOfGlobalCharacters - 1);
        int numberOfAllies = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        globalBlackboard.UpdateValue("totalNumberOfCharacters", numberOfAllies - 1);
    }
}
