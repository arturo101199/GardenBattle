using UnityEngine;
using UnityEngine.AI;

public class AntRecollectState : State
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
        actionTree.EvaluateTree();
        base.OnStateUpdate();
    }
}