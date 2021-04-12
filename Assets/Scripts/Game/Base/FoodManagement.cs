using System.Collections.Generic;
using UnityEngine;

public class FoodManagement : MonoBehaviour
{
    Stack<Vector3> sortedFoodPositions = new Stack<Vector3>();

    public void SetFood(List<Vector3> foodPositions)
    {
        ListUtilities.SortFromDistanceToAnObject(foodPositions, transform.position);
        foodPositions.Reverse();
        foreach (Vector3 position in foodPositions)
        {
            AddFood(position);
        }
        AntGlobalBlackboard.Instance.AddKeyValue("foodManagement", this);
    }

    public Vector3 GetFood()
    {
        if(sortedFoodPositions.Count > 0)
            return sortedFoodPositions.Pop();
        return Vector3.zero;
    }

    public void AddFood(Vector3 position)
    {
        sortedFoodPositions.Push(position);
    }
}