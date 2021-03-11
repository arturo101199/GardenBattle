using UnityEngine;

public class FindFood : BNode
{
    public override NodeState Evaluate()
    {
        Vector3 nextFood = (AntGlobalBlackboard.Instance.GetValue("foodManagement") as FoodManagement).GetFood();
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}