using UnityEngine;

public class SettingTrapsState : State
{
    [SerializeField] BTree actionTree = null;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }

    protected override void makeUpdate()
    {
        actionTree.EvaluateTree();
    }
}