using UnityEngine;

public class AntImStrong : BNode
{
    int foodRequiredToBeStrong = 5;
    [SerializeField] bool desiredBool = true;

    public override NodeState Evaluate()
    {
        if (((int)AntGlobalBlackboard.Instance.GetValue("foodEaten") >= foodRequiredToBeStrong) == desiredBool)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAIL;
    }

    public override void OnTreeEnded()
    {
    }
}
