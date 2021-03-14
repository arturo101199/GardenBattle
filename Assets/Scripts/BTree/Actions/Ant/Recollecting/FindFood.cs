using UnityEngine;

public class FindFood : BNode
{
    FoodManagement foodManagement;

    private void Start()
    {
        foodManagement = (FoodManagement)AntGlobalBlackboard.Instance.GetValue("foodManagement");
    }

    public override NodeState Evaluate()
    {
        Vector3 nextFood = foodManagement.GetFood();
        blackboard.UpdateValue("currentFoodLocation", nextFood);
        return NodeState.SUCCESS;
    }

    public override void OnTreeEnded()
    {
        
    }
}