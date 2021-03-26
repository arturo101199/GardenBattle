﻿using UnityEngine;

public class Die : State
{
    [SerializeField] GameObject parent = null;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
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
}