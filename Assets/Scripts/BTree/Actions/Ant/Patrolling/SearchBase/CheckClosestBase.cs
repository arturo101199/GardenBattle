﻿using UnityEngine;

public class CheckClosestBase : BNode
{
    BaseManager baseManager;
    Vector3 baseLocation;
    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        baseManager = (BaseManager)GameGlobalBlackboard.Instance.GetValue("baseManager");
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        baseLocation = (Vector3)globalBlackboard.GetValue("baseLocation");
    }

    public override NodeState Evaluate()
    {
        Vector3 basePosition = baseManager.findClosestBase(transform.position, baseLocation);
        blackboard.UpdateValue("closerEnemyBase", basePosition);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}