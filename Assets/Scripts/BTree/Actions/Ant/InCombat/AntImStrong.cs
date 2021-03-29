﻿using UnityEngine;

public class AntImStrong : BNode
{
    int foodRequiredToBeStrong = 20;
    [SerializeField] bool desiredBool = true;

    GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = (GlobalBlackboard)blackboard.GetValue("globalBlackboard");
        foodRequiredToBeStrong = (int)globalBlackboard.GetValue("maxFood");
    }

    public override NodeState Evaluate()
    {
        if (((int)globalBlackboard.GetValue("foodEaten") >= foodRequiredToBeStrong) == desiredBool)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
    }
}
