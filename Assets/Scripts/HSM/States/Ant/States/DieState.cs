using System;
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
        RemoveCharacterFromBase();
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

    private void RemoveCharacterFromBase()
    {
        BaseManager baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
        baseManager.RemoveCharacterFromBase(GetComponentInParent<IDamageable>(), (Vector3)globalBlackboard.GetValue("baseLocation"));
    }

    void ModifyCharactersNumberOnBlackboards()
    {
        int numberOfGlobalCharacters = (int)GameGlobalBlackboard.Instance.GetValue("totalNumberOfCharacters");
        GameGlobalBlackboard.Instance.UpdateValue("totalNumberOfCharacters", numberOfGlobalCharacters - 1);
        int numberOfAllies = (int)globalBlackboard.GetValue("totalNumberOfCharacters");
        globalBlackboard.UpdateValue("totalNumberOfCharacters", numberOfAllies - 1);
    }
}
