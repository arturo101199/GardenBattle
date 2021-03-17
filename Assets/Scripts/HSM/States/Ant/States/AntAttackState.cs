﻿using UnityEngine;

public class AntAttackState : State
{
    [SerializeField] BTree actionTree = null;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        actionTree.ResetNodes();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
}
