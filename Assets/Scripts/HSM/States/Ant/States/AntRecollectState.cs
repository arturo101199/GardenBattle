﻿using UnityEngine;
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
        actionTree.ResetNodes();
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